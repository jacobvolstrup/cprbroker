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
using CprBroker.Schemas.Part;

namespace CprBroker.Providers.DPR
{
    public partial class PersonAddress
    {
        public AdresseType ToAdresseType(Street street)
        {
            return new AdresseType()
            {
                Item = new DanskAdresseType()
                {
                    AddressComplete = new CprBroker.Schemas.Part.AddressCompleteType()
                    {
                        AddressAccess = new CprBroker.Schemas.Part.AddressAccessType()
                        {
                            MunicipalityCode = MunicipalityCode.ToDecimalString(),
                            StreetBuildingIdentifier = HouseNumber,
                            StreetCode = StreetCode.ToDecimalString()
                        },
                        AddressPostal = new CprBroker.Schemas.Part.AddressPostalType()
                        {
                            CountryIdentificationCode = CountryIdentificationCodeType.Create(_CountryIdentificationSchemeType.imk, Constants.DenmarkKmdCode),
                            DistrictName = Town,
                            DistrictSubdivisionIdentifier = null,
                            FloorIdentifier = Floor,
                            MailDeliverySublocationIdentifier = null,
                            PostCodeIdentifier = PostCode.ToDecimalString(),
                            PostOfficeBoxIdentifier = null,
                            StreetBuildingIdentifier = HouseNumber,
                            StreetName = street != null ? street.StreetAddressingName : null,
                            StreetNameForAddressingName = StreetAddressingName,
                            SuiteIdentifier = DoorNumber,
                        }
                    },
                    // No address point
                    AddressPoint = null,
                    NoteTekst = null,
                    PolitiDistriktTekst = null,
                    PostDistriktTekst = null,
                    SkoleDistriktTekst = null,
                    SocialDistriktTekst = null,
                    SogneDistriktTekst = null,
                    SpecielVejkodeIndikator = false,
                    SpecielVejkodeIndikatorSpecified = false,
                    UkendtAdresseIndikator = false,
                    ValgkredsDistriktTekst = null
                }
            };
        }

        public AdresseType ToForeignAddressFromSupplementary()
        {
            return new AdresseType()
            {
                Item = new VerdenAdresseType()
                {
                    ForeignAddressStructure = new ForeignAddressStructureType()
                    {
                        CountryIdentificationCode = CountryIdentificationCodeType.Create(_CountryIdentificationSchemeType.imk, Constants.DenmarkKmdCode),
                        LocationDescriptionText = Location,
                        PostalAddressFirstLineText = AdditionalAddressLine1,
                        PostalAddressSecondLineText = AdditionalAddressLine2,
                        PostalAddressThirdLineText = AdditionalAddressLine3,
                        PostalAddressFourthLineText = AdditionalAddressLine4,
                        PostalAddressFifthLineText = AdditionalAddressLine5,
                    },
                    NoteTekst = null,
                    UkendtAdresseIndikator = false
                }
            };
        }

    }
}
