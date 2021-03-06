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
using CprBroker.PartInterface;
using CprBroker.Engine;
using CprBroker.Engine.Part;
using CprBroker.Schemas;
using CprBroker.Schemas.Part;


namespace CprBroker.Providers.CprServices
{
    public class CprServicesTestReadDataProvider : CprServicesDataProvider, IPartReadDataProvider, IExternalDataProvider, IPerCallDataProvider
    {
        public override string[] OperationKeys
        {
            get
            {
                var ret = base.OperationKeys.ToList();
                ret.Add(Constants.OperationKeys.Unfinished.ADRESSE3);
                return ret.ToArray();
            }
        }

        public RegistreringType1 Read(Schemas.PersonIdentifier uuid, LaesInputType input, Func<string, Guid> cpr2uuidFunc, out Schemas.QualityLevel? ql)
        {
            ql = Schemas.QualityLevel.Cpr;

            var addressMethod = new SearchMethod(Properties.Resources.ADRESSE3);
            var addressRequest = new SearchRequest(uuid.CprNumber);
            var addressCall = new SearchMethodCall(addressMethod, addressRequest);

            var xml = addressCall.ToRequestXml(Properties.Resources.SearchTemplate);

            var xmlOut = "";
            string token = this.SignonAndGetToken();

            // Get address
            var kvit = Send(addressCall.Name, xml, ref token, out xmlOut);
            if (kvit.OK)
            {
                var addressPerson = addressCall.ParseResponse(xmlOut, false).First();
                if (string.IsNullOrEmpty(addressPerson.PNR))
                    addressPerson.PNR = uuid.CprNumber;

                var cache = new UuidCache();
                cache.FillCache(new string[] { addressPerson.PNR });
                var ret = addressPerson.ToRegistreringType1(cache.GetUuid);

                // Now get the name
                var nameMethod = new SearchMethod(Properties.Resources.NAVNE3);
                var nameRequest = new SearchRequest(uuid.CprNumber);
                var nameCall = new SearchMethodCall(nameMethod, nameRequest);
                var nameXml = nameCall.ToRequestXml(Properties.Resources.SearchTemplate);

                kvit = Send(nameCall.Name, nameXml, ref token, out xmlOut);
                if (kvit.OK)
                {
                    var namePersons = nameCall.ParseResponse(xmlOut, false);
                    namePersons[0].PNR = uuid.CprNumber;
                    var nameRet = namePersons[0].ToRegistreringType1(cache.GetUuid);
                    ret.AttributListe.Egenskab[0].NavnStruktur = nameRet.AttributListe.Egenskab[0].NavnStruktur;
                    return ret;
                }

            }
            return null;
        }
    }
}
