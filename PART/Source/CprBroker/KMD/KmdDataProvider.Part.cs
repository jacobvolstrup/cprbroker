﻿/* ***** BEGIN LICENSE BLOCK *****
 * Version: MPL 1.1/GPL 2.0/LGPL 2.1
 *
 * The contents of this file are subject to the Mozilla Public License Version
 * 1.1 (the "License"); you may not use this file except in compliance with
 * the License. You may obtain a copy of the License at
 * http://www.mozilla.org/MPL/
 *
 * Software distributed under the License is distributed on an "AS IS"basis,
 * WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License
 * for the specific language governing rights and limitations under the
 * License.
 *
 *
 * The Initial Developer of the Original Code is
 * IT- og Telestyrelsen / Danish National IT and Telecom Agency.
 *
 * Contributor(s):
 * Beemen Beshara
 * Niels Elgaard Larsen
 * Leif Lodahl
 * Steen Deth
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
using System.Xml;
using CprBroker.Engine;
using CprBroker.Providers.KMD.WS_AS78207;
using CprBroker.Providers.KMD.WS_AN08010;
using CprBroker.Schemas.Part;

namespace CprBroker.Providers.KMD
{
    /// <summary>
    /// Implements the Read operation of the Part standard
    /// </summary>
    public partial class KmdDataProvider : IPartReadDataProvider
    {
        #region IPartReadDataProvider Members

        public RegistreringType1 Read(CprBroker.Schemas.PersonIdentifier uuid, LaesInputType input, Func<string, Guid> cpr2uuidFunc, out CprBroker.Schemas.QualityLevel? ql)
        {
            RegistreringType1 ret = null;
            var detailsResponse = new EnglishAS78207Response(CallAS78207(uuid.CprNumber));
            var addressResponse = CallAS78205(uuid.CprNumber);
            EnglishAN08010Response relationsResponse = null;
            try
            {
                CallAN08010(uuid.CprNumber);
            }
            catch (Exception ex)
            {
                CprBroker.Engine.Local.Admin.LogException(ex);
            }

            ret = new RegistreringType1()
            {
                AttributListe = detailsResponse.ToAttributListeType(addressResponse),
                TilstandListe = detailsResponse.ToTilstandListeType(),
                RelationListe = ToRelationListeType(detailsResponse, relationsResponse, cpr2uuidFunc),

                AktoerRef = Constants.Actor,
                CommentText = Constants.CommentText,
                LivscyklusKode = LivscyklusKodeType.Rettet,
                Tidspunkt = TidspunktType.Create(detailsResponse.GetRegistrationDate()),
                Virkning = null
            };

            ql = CprBroker.Schemas.QualityLevel.Cpr;
            ret.CalculateVirkning();
            return ret;
        }

        #endregion

        #region Utility methods


        public RelationListeType ToRelationListeType(EnglishAS78207Response details, EnglishAN08010Response relations, Func<string, Guid> cpr2uuidFunc)
        {
            var ret = new RelationListeType();

            //Children
            if (relations != null)
            {
                ret.Boern = relations.Filter(RelationTypes.Baby, cpr2uuidFunc);
                ret.Foraeldremyndighedsboern = relations.Filter(RelationTypes.ChildOver18, cpr2uuidFunc);
            }
            else if (details.ChildrenPNRs != null)
            {
                var childPnrs = (from pnr in details.ChildrenPNRs where pnr.Replace("-", "").Length > 0 select pnr.Replace("-", "")).ToArray();
                var uuids = Array.ConvertAll<string, Guid>(childPnrs, (cpr) => cpr2uuidFunc(cpr));
                ret.Boern = Array.ConvertAll<Guid, PersonFlerRelationType>
                (
                    uuids,
                    (pId) => PersonFlerRelationType.Create(pId, null, null)
                );
            }

            //Father
            if (Convert.ToDecimal(details.FatherPNR) > 0)
            {
                ret.Fader = new PersonRelationType[] { PersonRelationType.Create(cpr2uuidFunc(details.FatherPNR), null, null) };
            }
            //Mother
            if (Convert.ToDecimal(details.MotherPNR) > 0)
            {
                ret.Fader = new PersonRelationType[] { PersonRelationType.Create(cpr2uuidFunc(details.MotherPNR), null, null) };
            }

            // Spouse
            if (Convert.ToDecimal(details.SpousePNR) > 0)
            {
                var maritalStatus = Utilities.ToPartMaritalStatus(details.MaritallStatusCode[0]);
                var maritalStatusDate = Utilities.ToDateTime(details.MaritalStatusDate);
                bool isMarried = maritalStatus == CivilStatusKodeType.Gift || maritalStatus == CivilStatusKodeType.RegistreretPartner;
                var spouseUuid = cpr2uuidFunc(details.SpousePNR);
                ret.Aegtefaelle = new PersonRelationType[]
                    {
                        PersonRelationType.Create
                        (
                            spouseUuid,
                            isMarried? maritalStatusDate : null,
                            isMarried? null : maritalStatusDate
                       )
                    };
            }
            // TODO: Fill other relationships such as custody
            return ret;
        }

        #endregion
    }
}
