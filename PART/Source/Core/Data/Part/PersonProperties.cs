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
using System.Data.Linq;
using System.Linq;
using System.Text;
using CprBroker.Schemas.Part;

namespace CprBroker.Data.Part
{
    /// <summary>
    /// Represents the PersonProperties table
    /// </summary>
    public partial class PersonProperties
    {
        public static EgenskabType[] ToXmlType(PersonProperties db)
        {
            if (db != null)
            {
                return new EgenskabType[]
                {
                    new EgenskabType()
                    {
                        BirthDate = db.BirthDate,
                        PersonGenderCode = Data.Part.Gender.GetPartGender(db.GenderId),
                        NavnStruktur = new NavnStrukturType()
                        {
                            KaldenavnTekst = db.NickName,
                            NoteTekst = db.NameNoteText,
                            PersonNameForAddressingName = db.AddressingName,
                            PersonNameStructure = PersonName.ToXmlType(db.PersonName),
                        },
                        FoedestedNavn = db.BirthPlace,
                        FoedselsregistreringMyndighedNavn = db.BirthRegistrationAuthority,
                        KontaktKanal = ContactChannel.ToXmlType(db.ContactChannel),
                        NaermestePaaroerende = ContactChannel.ToXmlType(db.NextOfKinContactChannel),
                        AndreAdresser = Address.ToXmlType(db.OtherAddress),
                        Virkning = Effect.ToVirkningType(db.Effect)
                    }
                };
            }
            return null;
        }

        public static PersonProperties FromXmlType(EgenskabType[] oio)
        {
            if (oio != null && oio.Length > 0 && oio[0] != null)
            {
                return new PersonProperties()
                {
                    BirthDate = oio[0].BirthDate,

                    GenderId = Data.Part.Gender.GetPartCode(oio[0].PersonGenderCode),
                    BirthPlace = oio[0].FoedestedNavn,
                    BirthRegistrationAuthority = oio[0].FoedselsregistreringMyndighedNavn,

                    PersonName = PersonName.FromXmlType(oio[0].NavnStruktur.PersonNameStructure),

                    NickName = oio[0].NavnStruktur.KaldenavnTekst,
                    NameNoteText = oio[0].NavnStruktur.NoteTekst,
                    AddressingName = oio[0].NavnStruktur.PersonNameForAddressingName,

                    ContactChannel = ContactChannel.FromXmlType(oio[0].KontaktKanal),
                    NextOfKinContactChannel = ContactChannel.FromXmlType(oio[0].NaermestePaaroerende),
                    OtherAddress = Address.FromXmlType(oio[0].AndreAdresser),

                    Effect = Effect.FromVirkningType(oio[0].Virkning),
                };
            }
            return null;
        }

        public static void SetChildLoadOptions(DataLoadOptions loadOptions)
        {
            loadOptions.LoadWith<PersonProperties>(pp => pp.ContactChannel);
            loadOptions.LoadWith<PersonProperties>(pp => pp.NextOfKinContactChannel);
            loadOptions.LoadWith<PersonProperties>(pp => pp.OtherAddress);
            loadOptions.LoadWith<PersonProperties>(pp => pp.Effect);
            loadOptions.LoadWith<PersonProperties>(pp => pp.Gender);
            loadOptions.LoadWith<PersonProperties>(pp => pp.PersonName);

            ContactChannel.SetChildLoadOptions(loadOptions);
            Address.SetChildLoadOptions(loadOptions);
        }
    }
}
