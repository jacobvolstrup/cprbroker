﻿/* ***** BEGIN LICENSE BLOCK *****
 * Version: MPL 1.1/GPL 2.0/LGPL 2.1
 *
 * The contents of this file are subject to the Mozilla Public License
 * Version 1.1 (the "License"); you may not use this file except in
 * compliance with the License. You may obtain a copy of the License at
 * http://www.mozilla.org/MPL/
 *
 * Software distributed under the License is distributed on an "AS IS"basis,
 * WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License
 * for the specific language governing rights and limitations under the
 * License.
 *
 * The CPR Broker concept was initally developed by
 * Gentofte Kommune / Municipality of Gentofte, Denmark.
 * Contributor(s):
 * Steen Deth
 *
 *
 * The Initial Code for CPR Broker and related components is made in
 * cooperation between Magenta, Gentofte Kommune and IT- og Telestyrelsen /
 * Danish National IT and Telecom Agency
 *
 * Contributor(s):
 * Beemen Beshara
 * Niels Elgaard Larsen
 * Leif Lodahl
 * Steen Deth
 *
 * The code is currently governed by IT- og Telestyrelsen / Danish National
 * IT and Telecom Agency
 *
 * Alternatively, the contents of this file may be used under the terms of
 * either the GNU General Public License Version 2 or later (the "GPL"), or
 * the GNU Lesser General Public License Version 2.1 or later (the "LGPL"),
 * in which case the provisions of the GPL or the LGPL are applicable instead
 * of those above. If you wish to allow use of your version of this file only
 * under the terms of either the GPL or the LGPL, and not to allow others to
 * use your version of this file under the terms of the MPL, indicate your
 * decision by deleting the provisions above and replace them with the notice
 * and other provisions required by the GPL or the LGPL. If you do not delete
 * the provisions above, a recipient may use your version of this file under
 * the terms of any one of the MPL, the GPL or the LGPL.
 *
 * ***** END LICENSE BLOCK ***** */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Data;
using System.Data.SqlClient;

namespace PersonMasterTestClient
{
    [TestFixture]
    class Tests
    {
        public static string[] RandomCprNumbers(int count)
        {
            var cprNumbers = new List<string>();
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                var day = random.Next(1, 29).ToString("00");
                var month = random.Next(1, 13).ToString("00");
                var year = random.Next(1, 100).ToString("00");
                var part1 = random.Next(1000, 9999).ToString();
                cprNumbers.Add(day + month + year + part1);
            }
            return cprNumbers.ToArray();
        }

        public static string[] SerialCprNumbers(int count)
        {
            var cprNumbers = new List<string>();

            for (int iDay = 1; iDay <= 28; iDay++)
            {
                for (int iMonth = 1; iMonth <= 12; iMonth++)
                {
                    for (int iYear = 1; iYear <= 99; iYear++)
                    {
                        for (int iPart = 1; iPart <= 9999; iPart++)
                        {
                            var day = iDay.ToString("00");
                            var month = iMonth.ToString("00");
                            var year = iYear.ToString("00");
                            var part1 = iPart.ToString("0000");

                            if (cprNumbers.Count < count)
                            {
                                cprNumbers.Add(day + month + year + part1);
                            }
                            else
                            {
                                return cprNumbers.ToArray();
                            }
                        }
                    }
                }
            }
            return cprNumbers.ToArray();
        }

        private string[] InvalidCprNumbers(int count)
        {
            string[] ret = new string[count];
            Random r = new Random();
            for (int i = 0; i < count; i++)
            {
                string cprNumber = r.Next().ToString() + r.Next().ToString();
                if (cprNumber.Length == 10)
                {
                    cprNumber = "99" + cprNumber.Substring(2);
                }
                ret[i] = cprNumber;
            }
            return ret;
        }

        private const string PersonMasterConnectionString = "";
        public int[] CprCounts = new[] { 0, 1, 2, 4, 8, 16, 32, 64, 128, 256, 512/*, 1024, 2048, 4096, 8192, 16384, 32768, 65536*/ };

        [Test]
        public void TestGetUuidArrayOfRandomCpr(
            [ValueSource("CprCounts")] int count)
        {
            var cprNumbers = RandomCprNumbers(count);
            PersonMasterServiceLibrary.BasicOpClient client = new PersonMasterServiceLibrary.BasicOpClient();
            string aux = null;

            var ret = client.GetObjectIDsFromCprArray("", cprNumbers.ToArray(), ref aux);
            ValidateOutput(cprNumbers, ret);
        }

        public String[] uuIDs = new[] { "", "" };

        [Test]
        public void TestGetUuidArrayOfCprSequence(
            [ValueSource("CprCounts")] int count)
        {
            var cprNumbers = SerialCprNumbers(count);
            PersonMasterServiceLibrary.BasicOpClient client = new PersonMasterServiceLibrary.BasicOpClient();
            string aux = null;

            var ret = client.GetObjectIDsFromCprArray("", cprNumbers.ToArray(), ref aux);
            ValidateOutput(cprNumbers, ret);
        }

        [Test]
        public void TestInvalidCprNumbers(
            [ValueSource("CprCounts")] int count)
        {
            var cprNumbers = InvalidCprNumbers(count);

            PersonMasterServiceLibrary.BasicOpClient client = new PersonMasterServiceLibrary.BasicOpClient();
            string aux = null;
            var ret = client.GetObjectIDsFromCprArray("", cprNumbers.ToArray(), ref aux);
            Assert.NotNull(aux, "Aux is null");
            Console.WriteLine(aux);
            if (count > 0)
            {
                Assert.Greater(aux.Length, 0, "Aux is empty");
            }
            for (int i = 0; i < count; i++)
            {
                Assert.IsNull(ret[i], string.Format("Cpr number {0} did not fail", cprNumbers[i]));
            }
        }

        [Test]
        public void TestNullValues(
            [ValueSource("CprCounts")] int count)
        {
            string[] cprNumbers = new string[count];
            PersonMasterServiceLibrary.BasicOpClient client = new PersonMasterServiceLibrary.BasicOpClient();
            string aux = null;
            var ret = client.GetObjectIDsFromCprArray("", cprNumbers.ToArray(), ref aux);
            Assert.NotNull(ret, "Output array is null");
            Assert.AreEqual(count, ret.Length);
        }

        public void ValidateOutput(string[] cprNumbers, Guid?[] objectIds)
        {
            Assert.IsNotNull(objectIds, "Return value is null");
            Assert.AreEqual(cprNumbers.Length, objectIds.Length, "Return value length does not equal input length");
            foreach (var uuid in objectIds)
            {
                Assert.AreNotEqual(Guid.Empty, uuid, "UUID is empty");
                Assert.AreEqual(1, objectIds.Where((id) => id == uuid).Count(), "Repeated UUID : " + uuid.ToString());
            }
        }

        public static string[] RandomObjectIDs(int count)
        {
            /*
             * Creating 512 fake object IDs  will be a quite difficult task, so instead I have put 512 of our fake UUIDs in a string an use that as the ID pool.
             */
            Random r = new Random();
            var objectIDs = new List<string>();
            String testIDs = "C2D07DEB-4C4C-46C2-8737-000912B87B88,A1FE2AB0-8A8C-4F11-A5B7-000BA50FC875,35E9E356-437B-4260-8E56-002E35573BA4,A12CEA33-6B69-40F9-BD13-00333157DE7C,03BC77D2-8309-4C04-81BA-0035858679EA,F35FD4E5-D423-439B-9188-0041D384503F,F63C9493-C50B-4355-A6C5-004945E006CD,1AA67D50-A2E5-4BAC-94E4-00CB5B991E07,77917995-E099-4E42-9128-00FDCEE90DC0,A1F0B5A3-F09E-422F-9926-010EC2B90D0C,A1041291-A84D-4257-913E-01421FE0334A,B540CDBE-4132-4F8F-8418-015A93F0FA72,C06CE3C5-D3C7-4B31-A498-017477AEEDF9,31AFB1AB-A397-40F1-BFCE-0183B4D42940,07F34FC9-6107-4CFC-B46D-018435FE1E0E,A84956D9-2B67-4A55-A0A8-019EDB7F9851,7EDA25A7-9D33-4713-A2FC-01A9A35833DD,D46CB00E-E066-40EE-A366-01B829520C09,ED689102-DC87-4263-813D-01C13F991F0F,FE26937B-BECB-4280-A1BD-01C92ABD2B06,FCFCB280-02E3-4E0A-B505-01CA4C947D76,FEBC1F27-AEDA-40D8-BAC6-01E8F2B9B6DB,9F78D6FF-EF10-413B-B464-020DC72117E4,182C3664-7C53-446C-9ED0-0215AD00F2B7,4A937E1A-C022-42F7-8788-0223B2526235,C6952F1F-6C4A-4E37-91DF-022B8E262301,64FF0F19-1222-4C04-A0BD-0231EE8E40F0,69565D58-AEF5-4735-B71A-023941CA2CA8,33C1C0C5-D547-488B-A38B-023FDE5D892B,BF4EABE9-C7B8-4F27-943D-0251CB3B740F,A91BB499-504D-4D58-A395-0270F19DB1D0,3D86FC0B-10D3-4412-90A3-027C3829C0FD,BCED3B0A-1B36-41AE-9B7B-0281C4FDB56C,A1FD9265-A19C-49A4-B41E-02A9943F7A2B,023F5377-7A10-46F1-B3F0-02ADE8306D98,EDA0449A-5B4D-46FF-98D0-02B9D4C051A8,589E809F-5360-4414-8568-02C6E8909C25,E0964661-2C06-47BC-A1B3-02CE5E5125C2,D0D51840-71AC-4467-8F96-02DDD7906192,E6BE027B-377A-4E86-9F65-03128F3A237B,13C877D2-821F-4A21-8DBC-033C2899FBDD,89B4283F-1B02-429F-A869-03655664AE73,990D2814-42CB-43D8-A636-036826D9E3CC,D0F7A328-FF39-4038-8FA7-039364551A2D,F37779C4-358A-4C89-87E4-03A235A87F5F,61BCD157-7057-4135-ACB0-03A7D94641A8,3862829E-05B4-4912-8080-03BC5271FD5E,E2AE8FDD-1F86-4F13-ACB3-03C122EF1EC0,FB058DEF-DA05-45CD-9B78-03D2E6B9E889,0F6D478C-32E6-4B15-8097-03F47DA1491E,D03C57D6-9F6C-46FD-8BF2-0400407E7D19,369A1ED9-0935-40A4-ACA4-046AA115608A,7825AFFB-ABEB-40D0-A74B-04A285906CED,5A5D1615-C9FA-4610-AB05-04ACD3345A29,8BCCC93B-395D-43BD-AA29-04CFDFA75538,A5F0076A-7FBB-4EAD-A645-05035E6677E6,628567F8-64A2-4034-A371-05210F891B0A,5B628E15-E602-4A35-ADA7-052DCA87E02D,608F508D-9E21-4837-A5DE-05360F079DC0,84D7EBDB-9032-45A1-BAE5-0567C226F501,3BEF6516-A07A-4B6D-89D9-0574FE20A075,D371F3B3-2872-4BCC-9D89-058F5AFFBC77,888DB8E6-A4B5-4320-AE10-05CF12492108,4349E90B-C746-41DC-B590-05EDF0308EEC,1619C77A-D2C9-4845-B965-05F7AC108931,3DA16375-3CBF-4C93-8DB1-05FE8CBA646C,1F17210F-AED3-43BF-BA03-063C5152E9D9,D866C9B3-A94E-4B05-A359-063E8DF2E0B8,5FA0D447-CBDA-49CA-9032-065758C069FC,631BAFC4-C453-4A41-87D5-0661FABB8CA2,3504AA69-D9C6-4D28-867E-0662C803FC4A,D957544E-1E1D-4565-AC46-06696BCD992B,D98D2603-B446-4C90-8E98-066B045F4F7B,08FAB74E-4AA1-4D62-94C6-06A985D1B921,06349A4C-3D21-4CF9-B302-06D484F351B9,27E8B099-F2D5-44B7-AAE7-06FBBEBAFE23,B3E4327C-E213-4219-8C46-071501CEA5D2,3986FE88-07A2-41C8-851F-072545E53A70,2E8A8FD7-5709-4E4A-9A0E-074DADB25E0F,532DD2D7-FFBB-46BE-BD3F-074EF7C4E6B7,0963CC1A-429F-4A84-B1B3-077C65417048,18903977-E380-451D-8C2D-079810A0AB17,A6E80431-C172-4195-B711-07CD87CD3B29,33540062-242C-4FA9-96F8-07D3DB084528,F3DBE88D-06AE-4C10-A742-07FA103F653F,905449A3-0D87-4D58-892F-07FBDAFC0B87,5EB7787C-7A0D-4FDC-815D-0802DA7844CC,F6FEA4EA-9A5D-44B8-A22D-08198B93FDF6,6C41885B-4508-49CF-81AC-081CC776500C,E4B85C5C-1935-4A50-BDFA-082E543145B7,11BFA979-2386-4D8E-9904-084E0E0263AA,66FFB5B9-B580-48DD-8D99-0871BAF1408A,676C0EFA-6977-44F9-9377-08864ABC5DB0,302401AB-8687-40B5-845B-08B0DB357408,F9CCD1CB-0BB9-46EC-A678-08CDF2C031C3,364D34E1-47BA-4757-9CD4-08D7E80D0472,6AF2FA6A-194E-4E8E-9549-090B3026A9E5,0440BC93-3C11-430F-B68C-093A22935A70,1BF8C994-47D2-4B82-B3E4-0956191A5A52,EC983F3C-B0E4-45E9-9D3A-09859F203FCF,2CBECA96-BBF2-4CA1-9A98-099F72CEBBF0,916F78BA-5C41-41DA-BE9D-09A9A2C37FF0,A99F1085-FCC6-4521-8588-09AE54D75CF0,D2D8C0B3-EBA6-47E2-9A69-09BEE344EE45,8E80AFCC-458A-4AC5-A004-09C1F7C4257B,BE6B4867-5509-40F1-96C2-09C84E1586A5,78F2FB93-FAC7-47F0-916A-09DDFF9A7C91,860EEA69-962E-4E46-BA7C-09E6AAFCF338,CFE58AC6-7B39-4E64-9E22-0A29B6AFFF0B,6188917B-4ADE-4CC9-9A51-0A32F3857903,395CF298-438D-498E-A369-0A37484A7CB0,FCDF86EF-0E6C-4D7D-99AB-0A426C34F3FA,4D2D7E64-5D6A-4900-BA5F-0A6AF3D2E83E,6FD7A187-B954-439B-BBD1-0A6B008A9D7B,7327A3B5-DAB6-4568-A244-0A81107F7781,7210D68A-D4E8-4DC3-963A-0A832DF14A7A,539CB450-E8D9-4F7A-950B-0AA2DA0A6298,90BB60DB-9C88-4F16-B5F2-0AB1B732082E,550EAEF9-DA46-4FBE-A03D-0AB22B2C720C,C8582F94-163F-4DF8-A47D-0ABCD8CC1E15,F062406E-B58F-4092-823F-0AC4F77F48CB,82E19D78-265D-4912-A0CA-0AC98C5BA0AE,2F913F24-26C2-4492-AC3E-0AEA8B4C39D9,13D8DEDC-82D1-409A-B60E-0B01660B4283,7D433C09-FBA6-4C79-95A9-0B0428A82D47,2D9FFCD3-B44D-4DF3-B6CB-0B480D8A431F,56C6C7A0-D633-41FA-B40A-0B50877213CC,33777446-E72C-4643-8346-0B6FC910D5E1,3DBB7392-98BD-461C-96CD-0B7FE44DD8A0,1E7B0B4E-ABB5-4E0E-B041-0B853919ED38,A41A7F3D-A9D4-4E29-9C09-0BBBABC47F11,24213F92-70EF-4BAC-BCC8-0BC629209B38,BB849488-6E11-4F39-AB0E-0BEF7915CED1,F7861515-8A4E-4740-92E4-0BF2D992F6B2,832860D6-34C2-4FDE-8BDB-0BF9A99F6603,A5296FC1-515A-4470-B0CC-0C0BCB577AA4,5D7B00C2-A040-4410-A4C8-0C3AADDF341E,33FE023F-637B-4DE6-8243-0C40CD5EBF77,4F0F0334-E75C-4291-8567-0C51AF7172F7,26D7B6AF-EB47-47A2-9E8F-0C6E130D2729,51BB8FFC-4E53-4EC3-BF94-0C82FC5E0D78,CCDB51E8-DEAC-470F-925A-0C9AFF7A3330,0813319C-46F1-402F-A6CD-0CA5D957B990,02601AB1-2E10-4C72-8AD6-0CBC708D63CE,801F7F52-C46E-4D73-A68D-0CBE25F7D6E9,AF6B3149-EDA3-4D37-83DA-0CD54DCD0702,9A34373B-FB64-4357-B04D-0D56890BA7CE,605B4871-4E0C-41C9-9371-0D5C591F0DD5,CE42940C-CD8F-4438-8FE6-0D6418C6CE3E,3D3F941F-0356-40BF-92B2-0DE12B3F2A73,BF78902A-28E0-4D39-A7FB-0DF77B9EDE76,BC539429-4B42-4BFB-A18C-0DF81BCF26B0,D8602FB4-842E-4FE3-811C-0E192B0ED10A,C1FACF6D-FB63-4E94-AA5D-0E4A800C24CD,C7E28FB7-6D05-48BD-A522-0E8BCCD1294F,6CE7A887-5EC5-40CC-B024-0E9B6AEE6410,F8D5DA30-71B5-44E6-AEA6-0EA258E92E36,573F63AC-B476-4186-85B6-0EA391446816,A01BD176-3806-4017-9207-0EFC24854AC6,8E6BB5A8-910E-4004-97CB-0EFCB24A85DB,C8E3E164-08ED-4368-9809-0F4E299B2017,E8EAD09E-745C-4B55-A9C1-0F5AFB16439F,936F5FCE-4F81-4CB8-BF5D-0F61AAFC63FE,85C68D04-B2FA-4156-9173-0F65C5BD16F0,D1CEAAEC-85B7-480D-A435-0F70A676CF9B,E3AE70FE-C502-4F14-A9D1-0F86D5BFDFE3,A72206B5-A926-46F6-BCEA-0FAD13B58E5D,7E98B623-8BB5-4716-862E-0FB1B2C37C25,DACCE174-DF3B-4BEC-A83C-0FB357CD4629,C4B7C163-802B-47F8-9550-0FC438EF52C1,F84F9F71-89B2-4655-9EFC-0FEB9BA2DE67,C62A6F82-2DAE-4479-AD59-100B11368A60,1E1D99D1-0273-49C3-AEEF-106813FD565A,A0E51DE0-FCA1-4D64-A397-1082EF667E8D,243E65A1-5E40-43C3-AC43-1088A579CA16,5B94B150-B179-4EB9-A2EC-109CBC5373ED,AE59B9D0-4CA5-4AF9-95B6-10A7EB70DA47,E56A33BD-E692-4513-9271-10B5345F46ED,807EFAE6-3E78-492A-92E6-10B669735DEA,02C3EBBD-2171-40E5-A657-10CA6C06164F,738DAE1E-2A15-4D9A-BF1D-10F1A1E450A7,7E823A0C-7D45-4CA8-8E79-10F2AA59BC31,D021EFC3-84D2-44A6-912D-10F7F2D64726,66D18656-2CED-4024-9461-10FD0BA1881C,54AB3382-5AB3-459C-A1C7-111B599871D6,B6431981-9FF4-4F89-88F3-1124D20F5034,5805D418-132B-4645-844F-112873A2FF32,3F6A788E-CD61-4274-A06A-11388FE6CB94,720AB3AF-0254-48D9-B3C9-1141F6E55B38,2094E97C-707E-49D3-B7DB-116606CC5928,C646194D-1FFA-430F-B661-1166A5888403,E94FB1A6-0A1F-4DA9-AA00-11766F2C6570,63971F6E-989B-4BC6-B776-1186EE6117C6,770239D0-6D38-45E7-A470-1194EA121347,F3EC5D01-27B1-46D4-B47B-1195D4049F5D,761C67FD-156E-4DC9-9A20-11AC3AED9932,9B5B9176-DABA-4C38-936B-11DC3207169D,1AB8B2D8-53E0-44BE-A74C-11E547C223C3,E94D0F8D-CC0E-4C78-BA07-11EC342B48E6,61A4C039-30BF-408E-A714-11FA558EADD4,1AE9FEFA-E9F1-443C-A135-12FB76027FD0,75C6B01F-F23B-4322-BBAB-130BA526A195,ABDDDF2C-525A-442B-A5B7-130F1C389094,F9D0F3F0-F669-4D5C-8AC6-131C1D98D185,E78389FB-ECDF-4AB7-89AE-1359607B2AB9,C0AC30EA-9E46-48AE-AD66-13758540D6CB,B5AC7196-DFD4-4A63-B29E-138EF13358CE,89B41AEC-EDE3-4691-A5AE-13C5EB33693D,87F58A48-204C-492B-9303-13CC637D5378,4D2B51A3-5ABB-49C5-AD2D-13CE928D77F4,20A2521F-CC00-48B3-96EB-13D9923AF8EF,57E137C9-CC1D-448E-BB7E-14174231478D,1AF9960D-4563-414F-B043-14756AC4DF7C,C9500959-52BD-49D9-9ABB-1480C518EEF4,7E962B32-6619-49B7-90C8-1481EBA59767,C9CC6899-18CE-46DB-B2E4-14E5935FF493,DEBDA302-AB2D-4AF8-990B-14FF2CC5316C,A06FF2B9-120A-4C78-B55B-1507DCEC3D61,F87F1F45-5472-4960-8710-151E091E4CCF,60084064-7C2B-4B2C-B12B-15217DA94343,34B38947-BB2F-418B-B8BC-15634274C546,FC1FE18A-EAF7-4245-91B3-15BC80C2F09F,0C8D78E9-E500-4B2B-AB33-15F9A6D6CEFA,E2540F43-2708-46F6-88CC-16026D9FDBD3,CA59B6D9-2C9D-4DA9-95D4-16209C045BD6,28137346-F06C-439F-9030-16296876DD25,84103240-F679-4FAB-B483-164E65D40AE4,02478B2E-F227-49F5-A5C6-1652E4D64161,B0A1004E-361F-4A29-862A-169C6974AB19,1C72E7E9-1B04-4E74-AB6F-169F15E45CE6,12865E09-0C17-4B87-B467-16C68D206F69,B8E65352-AA84-4E8E-9F0B-16E0D4951C16,2538D032-CEF3-466B-9D2A-16E8A8F50F13,0613BF53-7016-499C-913A-16EA1D28AB47,CE753B48-6AAF-4551-AA55-170CBFCABA2D,FB1A684B-9511-49BC-990D-17775ED1D400,43063575-6833-4844-B3E8-177948CEBA45,B4C19A79-D6E7-44FD-B585-179167B5F5A4,E0058074-659E-4E74-B634-1796A1A4DD4F,161551E2-96D0-4149-A965-17A36E4737A0,E3BEDA7C-D7E0-4A2A-A228-17AFFB13F4AC,0B4E6078-EC03-4913-9EE1-17BEC86B80ED,5AC09F58-E3C5-4CF3-9B06-17D3D29913A1,16019DC4-7B9E-4136-B9EE-17F06EB97FD6,089852D4-0324-45ED-90DB-17F421AC1580,2979550D-F55F-4DEA-8457-180D5C333B8E,03A597D5-ECC3-4C2C-A467-184AE0D66403,66DD32BE-E12B-4A69-83FB-1893BFD7203E,8EC8880F-57C5-43FF-9556-189A404C849D,1E58F087-253D-4967-886D-18AC16298217,625B34F7-393C-42DB-81D0-18D0CB790F16,35293DAB-909E-49A9-B3AA-18D38B7F7704,F142ACA7-D02F-4DA2-A837-18E395427850,4717A65E-81F6-4AA9-B725-18E6BD882BB3,9E8F05E0-4A70-42EB-8A1D-18F7EFF9E3F5,F104B0C8-0825-4DED-B591-190EB3125C80,EB9C2667-8853-4283-B9D5-1923858522AF,AEB10AAD-96CC-48CB-B1B2-1928CACB5281,3FD16D39-777B-49E5-AE26-19377FD51389,7A03F485-CDE2-409A-95A7-1957302B58AF,B42D26F0-2758-4E85-BF94-196F892632BA,DC520325-379F-4530-9EAC-1976C9A83CC8,CD321E00-6EFC-48E4-BC47-19900FCDEB14,FD39C37E-6D50-463A-8D0F-19920A0F7E6D,3959EAFD-1914-4BA1-BAFC-199980BE0940,D9FF90F7-2F8C-491A-BF23-19A9313FDCC5,AFB10ECB-E8A4-47C0-AE4E-19B7F132C290,6C1A145D-C3F4-4E2C-BC07-19E4DAD1C240,6AE5AE3E-D59F-4BF8-AED9-19E8C53A2C57,4EFEB25F-D6FA-4A66-9A42-1A0368553531,A089C2E0-D87A-423B-B323-1A03C16BFB67,42071E9B-FC90-41F3-8626-1A08068E62E2,779CF2B4-2F8E-495D-B778-1A319D0078BC,CB67B5A1-CB14-4417-8774-1A40C4A9A48A,10E1ED55-3C03-4F0D-B339-1A53A32C38A5,41A8454B-B422-4AEE-BBDF-1A6DDBDADF79,A32E4324-5246-4348-BCB1-1A802C0DC939,A4CDAD30-AF93-4668-B51D-1ABC5AECD186,A155225F-8950-4ADB-8B68-1B39BE5DDA9D,BD4B3BF9-37CB-4378-8C11-1B5B191B9D24,B5DADEB9-B4AE-4288-B202-1B98998A6422,F860630A-0685-424B-A54F-1B9D1EB47CC5,839336C4-18A7-4F06-AAE9-1BB282D8F647,2BB594A7-C250-4CAD-9D99-1BD0D8620DC7,8E8E1D84-BFBC-4F0B-AFC6-1BD888692C95,0DAAD5A3-15E3-42A8-952D-1BE5FED34145,2516A687-F4B7-47A3-94CB-1BF55E241820,4A62DAF0-79BA-4EAA-8717-1C03655C6C72,A16F60A7-CBF3-438B-88EB-1C3BA3755078,BF2C73DE-3228-403F-8E0D-1C3D4E4B2979,D25F1253-B3C1-464B-80CA-1C41184FF408,5C0316D0-F406-4AC0-8608-1C4E78B6D788,A878DA14-329E-48F9-98F0-1C5AE984B594,A350DD72-4AF1-45C3-A4A7-1C5BCDCDFAAD,7C47227C-49BD-4C85-AEE9-1C5CE5A63AC0,8C143BF2-BF31-4503-996C-1C5DC7D2E5DC,2A304FD4-0527-4675-856F-1C68E9CFD664,D644FA51-066E-49A7-9918-1C7168BFF9BE,AE0629E9-1F9A-44C7-9249-1C9459C84DF8,9234D1B2-4936-415F-BE25-1C9D61F9DBAA,CAEEC7C8-AD69-40E4-AC8F-1CA35D68BA8D,673E2E96-CD31-4033-BDD7-1CA8B02B8BA6,4AFFD690-14FA-4ADF-8691-1CA98C23DD23,934918D5-6782-427F-8CB7-1CE00AB65375,90482A7F-B81A-41C5-8A88-1CE69E945825,68C4537B-7BD1-4134-8FE2-1CFF7A2B5EEC,998278C2-E0F7-42A0-B43C-1D1A8983172C,FA70E456-A1D8-4B94-8E3D-1D26D63B6AC9,430FC19D-EFA9-457F-B547-1D65D4D6EE73,2B38814E-776C-4C29-A52E-1D6B30B6AB90,588BB1DB-313F-4B67-B706-1D787BE23A7E,602216A8-5D05-4E25-B9D0-1D84D963B310,E4710718-25B1-421F-BBA7-1D8D26CD9435,3BD8B7BB-867E-4AA0-917D-1D921B547CA1,26641E8E-7EB4-4833-A91C-1DBF4B66FC1B,6EAF4842-FEE7-4A57-822C-1DD91D0BE411,ED736310-F6CB-4AE5-831C-1DFBA89BCC95,86790F1C-1965-4E65-9E1A-1E05C5100332,C11839D8-DA96-4D28-9B48-1E3059075DCF,E55193F1-3D7B-4B54-BFB8-1E3541FB7E5F,F2598D44-31E3-4C3D-BB3F-1E428724F61B,3A0D6677-7C8A-4DD5-B70B-1E59F816BE44,1803AAC9-843B-48A0-83EF-1E68B185149F,F1CBF02D-E090-4E5B-8BE6-1E822903BDE7,2C5B70BE-3FAA-4AB5-92D6-1E8B57006762,2B230C17-8B9A-4337-8388-1E8C5648C9F7,5D5EF98E-AB61-4F49-8234-1EB5D929C52F,162BCA4E-2B8C-47D8-BB7B-1F60F4E9C977,5DC94711-FBEF-460A-B96A-1F6D970BBCEF,F987BD85-7140-4C83-BCF3-1F6E0191A4AA,176F885E-D7DB-477B-87EB-1F72DC5DB03D,2CA75782-1B03-47AF-9F19-1F83604974E2,BD0FE575-6739-4A3B-9345-1F92C005D5BF,60DB2710-0547-41E7-BAB5-1F9A6743CD39,AD95AD63-BE85-4BF1-B6D0-1F9C618ED661,335D79FB-0230-40D5-B7D5-1FA505950FDF,5635685C-93C6-47C1-A04B-1FAF94892888,7DEFFAF0-7A1A-4A95-839A-1FB27F6F8C0C,935BDEB6-3286-418D-B8C7-1FCAEF5A4014,CDA84BA2-B75A-4E20-89F7-1FED1D6109A3,16423EAB-39A6-4A19-871F-1FFA2CDADBDC,25B12322-2AB7-48CF-A03E-1FFB01FE0A36,38C4B2FA-992A-4DDC-BA8A-2019D07B46DC,AE61F5C9-2C80-4D59-BF68-2068654E050A,362E2819-DFF2-4AE1-B959-20697FCF845E,44FEEB2E-4DC7-4C0D-A9B5-2075CB3CCF62,7644DBCB-F0F9-4756-BBE6-2075F8FEFF7D,0BF5D69B-DD7D-4EB3-8132-2083F4CB3848,73528A9D-940E-436C-A9F3-209642D30045,1E813123-9141-44E4-A3F4-20D1D9335597,BC26A30C-90A1-44D6-881E-20E9E3A34AA1,866B1C01-62D4-4F45-A20F-20F4B422EF77,7BCE60A9-71A4-4A6E-A329-20F86727EADE,74A9D3CD-266F-4200-8FE1-20F93CCCF11F,0953D257-4BE2-4A73-9A13-20FCF19733AA,2110AA08-59E5-4AD8-B8BA-212687A014D7,6B877C8F-9325-4878-9F4B-21598154C9B5,3275E55A-4E01-4A67-BB51-2188F58BF363,E579D8EF-340C-4896-8BE1-2198FD84B8BF,1EBB71F5-AC54-4F15-AE79-219A3F7E94E1,ADFECC08-746B-488F-9DA5-21B16736E185,5AC6D646-073F-4845-9F12-21B48F9BF8B4,1E69C836-E8D5-4821-9D65-21C2204FA61B,07231F1E-0267-4F91-8607-21C27FAB4650,3F715FD0-8C0B-4EFB-BB41-21E0E3177017,9FD068FC-D1B3-45E2-A14A-222095405B45,41DE6C59-8537-4FA9-8C52-22550F1239A0,8447E11E-0551-4341-8F6B-22B9176DED20,01AB5669-C3EC-4FCD-9431-22E70E2E5044,26ACE964-B15C-4EA2-BF21-231CCE3FAEC2,FC56F515-8D47-4249-BFF5-235CE42E84FE,22B3729A-1F18-4309-A6C0-237B072251F2,A768DB81-FD85-4923-B576-2395CFBBB70D,6F795F7A-9783-4C69-8926-239DDFF381D2,6D5F0B14-4FA3-49BA-9197-23A25701658B,651FE31C-EA29-4B6C-87A9-23D6292F7AAC,CA000CCF-B0E1-49FB-A153-23EF5D6C324F,DC656CA5-4D25-40E7-919E-2407768620F4,59A326F5-5B47-4B80-8C23-2420F00D898F,81685CA6-7238-4079-B7AC-24578575727E,1D66B6CE-958B-4EBC-BA1B-247D2C823B6D,70EB88EE-1149-49EC-B5B7-249ED4D36BCE,35A022EE-B82B-4E29-9994-24AF0E17D909,7DFCB8F1-7C43-4B9B-9925-24BFFDE8D296,3796C557-825D-4F7C-811A-24EFE8EDDEBF,D705F6B5-0C3E-46E3-B047-24FFA0176C63,BFD1661E-5521-4CAE-B996-25053DF0E679,5D2F98D2-F995-4412-B57E-251CA942A2FE,CBB6E550-FAC0-40D2-9047-2540E3C1F873,D8B17500-001D-4726-97DD-2546118B2C7C,6665635C-8704-4BA2-B5BD-259B5BB2508C,91FA6D58-9E2A-45C5-A7ED-25C9C132F416,228B1317-48C5-4A6C-81D8-25E1BFFEF16A,F12D78D6-6012-4FAB-89D4-25E90088B86F,30A7804D-03D5-45A0-9C60-25EA78C3F519,C9C89D4D-0366-42E1-BD30-261C96C417A4,353957D9-5C84-42E1-8DBC-262198ACAB7C,0E820A8B-1952-4D96-A5D2-26293233AD1A,8A6FE693-389A-4798-A14B-26306ED7167B,E59534B4-9B5C-41E5-B865-2633F968D695,EE6D367D-97F9-454E-8BEE-26684F668ACB,8D803C7A-5423-495D-8D43-2669472254DD,66434CFF-4027-43FA-A0CF-268758390286,0F993734-D87B-4AA6-8292-26A02725F482,60AED13D-708F-4CC3-871C-26A18F44018F,EBE354B4-FA8E-4BC9-A5F6-26A98775291A,623DDE87-5C55-495D-99E5-26AAFFE9490D,6EC40B46-95F0-4E36-A331-26AE3D245129,48330365-D136-40D3-A595-26B67EFA931B,416D1405-EC07-4269-9F72-26F5BC34A0AD,B3A6DDDA-28F2-430B-B1DF-27002CAE5F62,1F1CA12C-7EE0-46BD-9C50-2713101AA889,D3508D10-D0C8-4ED4-978B-271E862FA40F,04AC9143-B1E0-467D-BF09-271F657F4D7C,F61AA2B3-CF32-42A5-A292-274281071A28,D2C79231-67F9-45C8-94E0-2758EB7E41CA,DC055EEF-FDF7-4B86-BA2B-27676A3672EB,7D4D52D5-0807-433A-BADA-27A9628A7299,B97A4C28-1089-4351-9463-27B9153B3A3A,94EC17C6-69AC-4206-82AA-27FB1CFAF04C,B9F349D4-B688-4932-AB6B-2830F71C5DE5,BBC3334F-DBFB-4AF6-AF1B-286365C04F2F,743C9841-19FE-4A22-9FB5-287636963171,9F6E8861-1784-4E29-BAE7-28913163B5C3,097881EA-42AC-4CFD-97D6-28A129A085D1,14679CB6-1717-44FD-BD8C-28BD3015A732,E54DCC77-04F6-4225-A33F-28E9B998FBE2,5EA110D9-A2E6-4BA3-84A2-28EAB6542D59,7FF9C74B-4A40-4B4E-AAA9-28F2EBACDAA8,020A53D5-7D74-4011-A4C0-28F41DDA3E0F,663D5694-12A8-4976-B885-294BF60D9B36,D909EDDB-61D8-486E-80AD-29529D8B6368,ABDF9EFE-C3B7-4F00-BC85-2970C8AD02C1,E585D61F-9B48-4AE6-92F1-29A583DF99B4,4989670D-0191-45C5-8072-29B34F307464,1025032B-AE93-466F-9D9D-29BDE5742095,78D0C442-2230-416C-AABE-29C854E999B1,DF500035-BA71-47AE-BB12-29CBC3B7FC66,6C6849AC-0D71-45CE-847D-29CE4D810B06,6465A6E9-3E46-4A48-AF4F-29E2FEF75A6B,9F517C73-6BB3-4C7C-9ECC-2A1EB8B3A00E,5FFA7D9A-F081-4170-816C-2A2F1BB1E6BF,28C3A81F-5FCD-48DC-B1C9-2A6BE7D34DCB,1541E5F6-7E63-488F-9716-2A6FF42289F8,59B087FD-E4DE-4580-A73B-2A75EF4D1B69,F63CEB37-CB1B-418D-A0B4-2AF7AB71211D,458E2D67-356A-48CD-A3D0-2AF85006087B,35E57171-E980-4EF7-A2D0-2B538D0C13D0,47853AB4-808F-4461-8BD7-2B8B3A0C6C71,CE2F7CBF-6156-4DA3-B3AA-2BA4B89C0CE2,7B7DC95F-EE06-425B-A4DF-2BD802C7EBC1,C97F436E-E5D5-4469-8D9C-2C131B4CA10D,3D6EFA89-B1A7-4F9D-BC9B-2C2AE001A9C8,6EE09C06-C827-4F26-83EC-2C38D181F0B8,A4DF7F09-66BB-49FC-BAE1-2C5F930C0329,2063A06B-036A-48F7-9893-2C6CA80A322D,6657AC28-D8C6-40DA-B01A-2C7B7649D58E,A1EEC279-129B-49E4-AB0F-2C803737C50D,278B1B2D-6C1C-492A-8A09-2C9D96A54CA8,4F7B626E-443D-4508-839C-2CACDEF8667F,55336668-C2D6-42FC-9E95-2CB972D1B882,A5693FCD-B9B4-4234-B1F2-2CC52C704FE9,DD6673F5-095B-4268-9821-2CDB68DF5684,338B695A-F0AA-493E-A97B-2D0CC3D8FBFE,C2A0857D-1F57-4C0E-929A-2D1FF22301E4,F27E6B24-7DF3-44C2-B7D0-2D2D41DA5614,9B629DF5-37BB-433F-A80C-2D31C6705F66,3F62A5DA-3280-4006-BEFA-2D3A6D67672E,C49EF765-352B-46A4-9FCF-2D4B44015A3B,7EEB7684-50E7-462E-91D9-2D529E16EECD,01207D9F-AA18-46C8-A292-2D9D230026D2,9225A80A-38DE-448F-A3E8-2D9F5AC61629,EB62BD45-8852-4136-85B1-2DCAA9703ED8,92901E4B-9DD9-430A-811F-2DDE58A37E4F,14156562-7EB9-401C-93A3-2DE309730376,8EC786E2-CC92-4100-834B-2DEB30C6B5A8,421380E7-4B7F-41FF-A726-2DF9E7483FBD,960A9559-3215-41FD-904C-2E3185634D13,E2107759-BB1F-4338-871C-2E3D4DDDA281,1C9EC38E-7757-4E80-BAAC-2E4190D0D0C3,3082D6D2-2798-4390-BC54-2E64DCC1225F,0843A203-F145-47BF-8320-2E75CF7E297B,9047A300-0B34-42DA-97BD-2E7E55B9BCCD,AED93EB3-51A7-4784-8324-2EA94A9636B4,17FF8B6A-FC04-4E5A-AB32-2EFAC7AAF89D,5904F30A-E8BE-4F52-8499-2EFD12A3D0A2,56D24C74-6BF4-4120-A11F-2F2397F92D7B,6D7FA704-DA33-4448-9AC9-2F2AAC0A7952,2A573AE5-766C-4E95-BBF8-2F41A96965AB,0CA766C6-B20D-48A6-95F1-2F6B6F4C9766,FC82C6AA-98CC-4F6A-885C-2F7AC6326297,555779AA-1F1C-4FC8-B0D6-2FA7DE4E4B6C,6D277E7B-9CC1-49B4-BBF4-2FBDFFB03A6F,101B0EF3-8B4F-4609-9BEB-2FEBEE42B74E,4DC1B7DD-0743-4C54-A86C-3048464BAED2,E766E489-34B9-4DBE-B879-306E75CFFB6A,91DB69A0-A241-4E18-B853-307581726C2D,C4FB7A11-D8A2-4BCA-B769-3093C31DF977,3A064399-AED1-4E9E-9904-309DD388D96D,0CC6148D-B97A-476C-92EC-30F2202BFA12,AA7A6E6A-1E7C-4BC1-8611-30FBE9BB414D,B3356B16-ABD9-4992-BF00-310CE94747F3,687014DD-DBBD-4984-B103-314A277CFF13,CE3F58B9-4408-421E-8430-3197C976FF01,BD1D14E3-387E-4C39-BE38-31BA1B774702,8393B8C3-A24D-4E29-A729-31BB969391AE,EBFDCE76-AACC-4EBC-8F60-31E865A60AB2,9FE54D1A-D0EB-4308-A857-31F0B76CC14F,4B994486-7811-48BA-B298-31FE63330B25,636F2CF7-058D-4351-A63B-320213CD03F2,991AD708-3FA5-43EC-8BC8-320A5452D03B,4D27573F-F866-41F3-BC6E-320F20310886";
            String[] testIDArray = testIDs.Split(',');
            for (int i = 0; i < count; i++)
            {
                objectIDs.Add(testIDArray[r.Next((testIDArray.Length - 1))]);
            }
            return objectIDs.ToArray();
        }

        private string[] InvalidObjectIDs(int count)
        {
            string[] ret = new string[count];
            Random r = new Random();
            for (int i = 0; i < count; i++)
            {
                String invalidID = "";
                for (int j = 0; j <= 5; j++)
                {
                    int size = (int)r.Next(12);
                    for (int k = 0; k <= size; k++)
                    {
                        String possible = "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                        invalidID += possible[(int)r.Next(possible.Length)];
                    }
                    if (j != 5)
                        invalidID += "-";
                }
                ret[i] = invalidID;
            }
            return ret;
        }

        [Test]
        public void TestGetCPRsFromArrayOfobjectIDsWithRandomIDs([ValueSource("CprCounts")] int count)
        {
            var objectIDs = RandomObjectIDs(count);
            System.Diagnostics.Debug.WriteLine("TEST random, #: " + count);
            PersonMasterServiceLibrary.BasicOpClient client = new PersonMasterServiceLibrary.BasicOpClient();
            string aux = null;

            var ret = client.GetCPRsFromObjectIDArray("", objectIDs.ToArray(), ref aux);
            //ValidateOutput(objectIDs, ret);
            System.Diagnostics.Debug.WriteLine("Returned random (" + count + ") IDs: " + ret.Length);
        }

        [Test]
        public void GetCPRsFromObjectIDArrays_RandomPNR_SmePNRs([ValueSource("CprCounts")] int count)
        {
            var cprNumbers = RandomCprNumbers(count);
            PersonMasterServiceLibrary.BasicOpClient client = new PersonMasterServiceLibrary.BasicOpClient();
            string aux = null;

            System.Diagnostics.Debug.WriteLine("TEST random, #: " + count);
            var objectIDs = client.GetObjectIDsFromCprArray("", cprNumbers, ref aux);

            var ret = client.GetCPRsFromObjectIDArray("", objectIDs.Select(id => id.ToString()).ToArray(), ref aux);

            for (int i = 0; i < count; i++)
            {
                Assert.AreEqual(cprNumbers[i], ret[i], "Different CPR number at index " + i);
            }
        }

        [Test]
        public void TestGetCPRsFromArrayOfobjectIDsWithInvalidIDs([ValueSource("CprCounts")] int count)
        {
            var cprNumbers = InvalidObjectIDs(count);
            System.Diagnostics.Debug.WriteLine("TEST invalid, #: " + count);
            PersonMasterServiceLibrary.BasicOpClient client = new PersonMasterServiceLibrary.BasicOpClient();
            string aux = null;
            var ret = client.GetCPRsFromObjectIDArray("", cprNumbers.ToArray(), ref aux);
            Assert.NotNull(aux, "Aux is null");
            if (count > 0)
            {
                Assert.Greater(aux.Length, 0, "Aux is empty");
            }
            for (int i = 0; i < count; i++)
            {
                Assert.IsNull(ret[i], string.Format("Cpr number {0} did not fail", cprNumbers[i]));
            }
            System.Diagnostics.Debug.WriteLine("Returned invalid (" + count + ") IDs: " + ret.Length);
        }

        [Test]
        public void TestGetCPRsFromArrayOfobjectIDsWithNullValues([ValueSource("CprCounts")] int count)
        {
            var cprNumbers = new String[count];
            PersonMasterServiceLibrary.BasicOpClient client = new PersonMasterServiceLibrary.BasicOpClient();
            string aux = null;
            var ret = client.GetCPRsFromObjectIDArray("", cprNumbers.ToArray(), ref aux);
            Assert.NotNull(aux, "Aux is null");
            Assert.AreEqual(count, ret.Length);
        }
    }
}
