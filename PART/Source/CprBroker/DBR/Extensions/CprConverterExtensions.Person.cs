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
 * Dennis Amdi Skov Isaksen
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
using CprBroker.Providers.DPR;
using CprBroker.Providers.CPRDirect;
using CprBroker.Schemas.Part;

namespace CprBroker.DBR.Extensions
{
    public partial class CprConverterExtensions
    {
        public static Person ToPerson(this IndividualResponseType person)
        {
            Person p = new Person();
            p.PNR = decimal.Parse(person.PersonInformation.PNR);
            p.CprUpdateDate = CprBroker.Utilities.Dates.DateToDecimal(person.RegistrationDate, 12);
            p.Birthdate = CprBroker.Utilities.Dates.DateToDecimal(person.PersonInformation.Birthdate.Value, 8);
            p.Gender = person.PersonInformation.Gender.ToString();
            p.CustomerNumber = null; //DPR SPECIFIC
            /*
             * Birth date related
             */
            p.BirthRegistrationAuthorityCode = decimal.Parse(person.BirthRegistrationInformation.BirthRegistrationAuthorityCode);
            p.BirthRegistrationDate = CprBroker.Utilities.Dates.DateToDecimal(person.BirthRegistrationInformation.Registration.RegistrationDate, 12);
            p.BirthRegistrationPlaceUpdateDate = 0; //TODO: Can be retrieved from CPR Services: foedmynhaenstart
            p.BirthplaceTextUpdateDate = null; //TODO: Can be retrieved from CPR Services: foedtxttimestamp
            p.BirthplaceText = person.BirthRegistrationInformation.AdditionalBirthRegistrationText; //TODO: validate that this is correct
            /*
             * Religious related
             */
            p.ChristianMark = person.ChurchInformation.ChurchRelationship.ToString();
            p.ChurchRelationUpdateDate = CprBroker.Utilities.Dates.DateToDecimal(person.ChurchInformation.Registration.RegistrationDate, 12);
            p.ChurchAuthorityCode = 0; //TODO: Can be retrieved from CPR Services: fkirkmynkod
            p.ChurchDate = CprBroker.Utilities.Dates.DateToDecimal(person.ChurchInformation.StartDate.Value, 8);
            /*
             * Guardianship related
             */
            p.UnderGuardianshipAuthprityCode = 0; //TODO: Can be retrieved from CPR Services: mynkod-ctumyndig
            p.GuardianshipUpdateDate = null; //TODO: Can be fetched in CPR Services: timestamp
            if (person.Disempowerment != null)
            {
                p.UnderGuardianshipDate = CprBroker.Utilities.Dates.DateToDecimal(person.Disempowerment.DisempowermentStartDate.Value, 8);
            }
            else
            {
                p.UnderGuardianshipDate = null;
            }
            /*
             * PNR related
             */
            p.PnrMarkingDate = null; //TODO: Can be fetched in CPR Services: pnrhaenstart
            p.PnrDate = 0; //TODO: Can be fetched in CPR Services: pnrmrkhaenstart 
            p.CurrentPnrUpdateDate = null; //TODO: Can be fetched in CPR Services: timestamp
            if (!string.IsNullOrEmpty(person.PersonInformation.CurrentCprNumber))
            {
                p.CurrentPnr = decimal.Parse(person.PersonInformation.CurrentCprNumber);
            }
            else
            {
                p.CurrentPnr = null;
            }
            if (person.PersonInformation.PersonEndDate != null)
            {
                p.PnrDeletionDate = CprBroker.Utilities.Dates.DateToDecimal(person.PersonInformation.PersonEndDate.Value, 8);
            }
            else
            {
                p.PnrDeletionDate = null;
            }
            /*
             * Position related
             */
            p.JobDate = null; //TODO: Can be fetched in CPR Services: stillingsdato
            p.Job = person.PersonInformation.Job;
            /*
             * Relations related
             */
            p.KinshipUpdateDate = 0; //TODO: Can be fetched in CPR Services: timestamp
            if (!string.IsNullOrEmpty(person.ParentsInformation.MotherPNR))
            {
                p.MotherPnr = decimal.Parse(person.ParentsInformation.MotherPNR);
            }
            else
            {
                p.MotherPnr = 0;
            }
            p.KinshipUpdateDate = 0; //TODO: Can be fetched in CPR Services: timestamp
            if (person.ParentsInformation.MotherBirthDate != null)
            {
                p.MotherBirthdate = CprBroker.Utilities.Dates.DateToDecimal(person.ParentsInformation.MotherBirthDate.Value, 8);
            }
            else
            {
                p.MotherBirthdate = null;
            }
            p.MotherDocumentation = null; //TODO: Can be fetched in CPR Services: mor_dok
            p.FatherPnr = decimal.Parse(person.ParentsInformation.FatherPNR);
            if (person.ParentsInformation.FatherBirthDate != null)
            {
                p.FatherBirthdate = CprBroker.Utilities.Dates.DateToDecimal(person.ParentsInformation.FatherBirthDate.Value, 8);
            }
            else
            {
                p.FatherBirthdate = null;
            }
            p.FatherDocumentation = null; //TODO: Can be fetched in CPR Services: far_dok
            p.PaternityDate = null; //TODO: Can be fetched in CPR Services: farhaenstart
            p.PaternityAuthorityCode = null; //TODO: Can be fetched in CPR Services: far_mynkod
            p.MotherName = person.ParentsInformation.MotherName;
            p.FatherName = person.ParentsInformation.FatherName;
            if (person.Disempowerment != null)
            {
                if (person.Disempowerment.DisempowermentEndDate.HasValue)
                    p.UnderGuardianshipDeleteDate = person.Disempowerment.DisempowermentEndDate.Value;
                p.UnderGuardianshipRelationType = person.Disempowerment.GuardianRelationType;
            }
            else
            {
                p.UnderGuardianshipDeleteDate = null;
                p.UnderGuardianshipRelationType = null;
            }
            return p;
        }

    }
}
