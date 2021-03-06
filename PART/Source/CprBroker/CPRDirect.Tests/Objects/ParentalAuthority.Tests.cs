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
using CprBroker.Providers.CPRDirect;

namespace CprBroker.Tests.CPRDirect.Objects
{
    namespace ParentalAuthorityTests
    {
        [TestFixture]
        public class ToPersonRelationType
        {
            [Test]
            public void LoadAll()
            {
                var all = IndividualResponseType.ParseBatch(Properties.Resources.U12170_P_opgavenr_110901_ADRNVN_FE);
                var ss = all
                    .Where(p => p.ParentalAuthority.Count() > 0)
                    .Select(p => p.ParentalAuthority.ToArray())
                    .ToArray();
                object o = "";
            }

            [Test]
            [ExpectedException]
            public void ToPersonRelationType_NoTypeOrParents_Exception()
            {
                var auth = new ParentalAuthorityType();
                auth.ToPersonRelationType(null, cpr => Guid.NewGuid());
            }

            [Test]
            [ExpectedException(typeof(ArgumentException))]
            public void ToPersonRelationType_InvalidType_Exception(
                [Values(0, 1, -2, 7)]decimal relType)
            {
                var auth = new ParentalAuthorityType() { RelationshipType = relType };
                var par = new ParentsInformationType();
                auth.ToPersonRelationType(par, cpr => Guid.NewGuid());
            }

            [Test]
            public void ToPersonRelationType_NoPnr_Empty(
            [Values(null, "")]string pnr)
            {
                var auth = new ParentalAuthorityType() { RelationPNR = pnr, RelationshipType = 5 };
                var ret = ParentalAuthorityType.ToPersonRelationType(new ParentalAuthorityType[] { auth }, new ParentsInformationType(), cpr => Guid.NewGuid());
                Assert.AreEqual(0, ret.Length);
            }

            [Test]
            public void ToPersonRelationType_PnrWithStartDate_NullStartDate(
            [Values("1234567890", "0123456789")]string pnr)
            {
                var auth = new ParentalAuthorityType() { RelationPNR = pnr, RelationPNRStartDate = DateTime.Today, RelationshipType = 5 };
                var ret = auth.ToPersonRelationType(new ParentsInformationType(), cpr => Guid.NewGuid());
                Assert.IsNull(ret.Virkning.FraTidspunkt.ToDateTime());
            }

            [Test]
            public void ToPersonRelationType_PnrWithCustodyStartDate_CorrectStartDate(
            [Values("1234567890", "0123456789")]string pnr)
            {
                var auth = new ParentalAuthorityType() { RelationPNR = pnr, CustodyStartDate = DateTime.Today, RelationshipType = 5 };
                var ret = auth.ToPersonRelationType(new ParentsInformationType(), cpr => Guid.NewGuid());
                Assert.AreEqual(DateTime.Today, ret.Virkning.FraTidspunkt.ToDateTime());
            }

            [Test]
            public void ToPersonRelationType_PnrWithStartDate_NullEndDate(
            [Values("1234567890", "0123456789")]string pnr)
            {
                var auth = new ParentalAuthorityType() { RelationPNR = pnr, RelationPNRStartDate = DateTime.Today, RelationshipType = 5 };
                var ret = auth.ToPersonRelationType(new ParentsInformationType(), cpr => Guid.NewGuid());
                Assert.Null(ret.Virkning.TilTidspunkt.ToDateTime());
            }

            [Test]
            public void ToPersonRelationType_PnrWithEndDate_CorrectEndDate(
            [Values("1234567890", "0123456789")]string pnr)
            {
                var auth = new ParentalAuthorityType() { RelationPNR = pnr, CustodyEndDate = DateTime.Today, RelationshipType = 5 };
                var ret = auth.ToPersonRelationType(new ParentsInformationType(), cpr => Guid.NewGuid());
                Assert.AreEqual(DateTime.Today, ret.Virkning.TilTidspunkt.ToDateTime());
            }

        }
    }
}
