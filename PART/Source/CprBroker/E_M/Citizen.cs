﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CprBroker.Schemas;
using CprBroker.Schemas.Part;

namespace CprBroker.Providers.E_M
{
    public partial class Citizen
    {
        public static RegistreringType1 ToRegistreringType1(Citizen citizen, Func<string, Guid> cpr2uuidFunc)
        {
            var ret = new RegistreringType1()
            {
                AktoerRef = UnikIdType.Create(E_MDataProvider.ActorId),
                AttributListe = ToAttributListeType(citizen),
                CommentText = null,
                LivscyklusKode = LivscyklusKodeType.Rettet,
                RelationListe = ToRelationListeType(citizen, cpr2uuidFunc),
                Tidspunkt = ToTidspunktType(citizen),
                TilstandListe = ToTilstandListeType(citizen),
                Virkning = null
            };
            ret.CalculateVirkning();
            return ret;
        }

        private static AttributListeType ToAttributListeType(Citizen citizen)
        {
            return new AttributListeType()
            {
                Egenskab = new EgenskabType[] { ToEgenskabType(citizen) },
                LokalUdvidelse = ToLokalUdvidelseType(citizen),
                RegisterOplysning = new RegisterOplysningType[] { ToRegisterOplysningType(citizen) },
                SundhedOplysning = new SundhedOplysningType[] { ToSundhedOplysningType(citizen) }
            };
        }

        private static EgenskabType ToEgenskabType(Citizen citizen)
        {
            return new EgenskabType()
            {
                AndreAdresser = ToAndreAdresse(citizen),
                BirthDate = citizen.Birthdate.Value,
                FoedestedNavn = null,
                FoedselsregistreringMyndighedNavn = citizen.BirthRegistrationText,
                KontaktKanal = ToKontaktKanalType(citizen),
                NaermestePaaroerende = ToNextOfKin(citizen),
                NavnStruktur = ToNavnStrukturType(citizen),
                PersonGenderCode = Converters.ToPersonGenderCodeType(citizen.Gender),
                Virkning = ToVirkningType(citizen)
            };
        }

        private static NavnStrukturType ToNavnStrukturType(Citizen citizen)
        {
            //TODO: Fill person name
            return null;
        }

        private static RegisterOplysningType ToRegisterOplysningType(Citizen citizen)
        {
            var ret = new RegisterOplysningType()
            {
                Item = null,
                // TODO: Fill effect dates
                Virkning = null,
            };
            if (!citizen.CountryCode.HasValue
                || new short[] { Constants.AbroadCountryCode, Constants.ReservedCountryCode, Constants.StatelessCountryCode, Constants.UnknownCountryCode }.Contains(citizen.CountryCode.Value))
            {
                ret.Item = ToUkendtBorgerType(citizen);
            }
            else if (citizen.CountryCode.Value == Constants.DenmarkCountryCode)
            {
                ret.Item = ToCprBorgerType(citizen);
            }
            else
            {
                ret.Item = ToUdenlandskBorgerType(citizen);
            }
            return ret;
        }

        private static UkendtBorgerType ToUkendtBorgerType(Citizen citizen)
        {
            return new UkendtBorgerType()
            {
                PersonCivilRegistrationReplacementIdentifier = citizen.PNR.ToString()
            };
        }

        private static CprBorgerType ToCprBorgerType(Citizen citizen)
        {
            return new CprBorgerType()
            {
                AdresseNoteTekst = null,
                FolkekirkeMedlemIndikator = false,
                FolkeregisterAdresse = CitizenPotReadyAddress.ToAdresseType(citizen.CitizenPotReadyAddresses.First()),
                ForskerBeskyttelseIndikator = false,
                NavneAdresseBeskyttelseIndikator = false,
                PersonCivilRegistrationIdentifier = null,
                PersonNationalityCode = null,
                PersonNummerGyldighedStatusIndikator = false,
                TelefonNummerBeskyttelseIndikator = false
            };
        }


        private static UdenlandskBorgerType ToUdenlandskBorgerType(Citizen citizen)
        {
            //TODO: Revise foreign citizen data
            return new UdenlandskBorgerType()
            {
                FoedselslandKode = CountryIdentificationCodeType.Create(_CountryIdentificationSchemeType.imk, citizen.CountryCode.Value.ToString()),
                PersonCivilRegistrationReplacementIdentifier = Converters.ToCprNumber(citizen.PNR),
                PersonIdentifikator = null,
                PersonNationalityCode = new CountryIdentificationCodeType[] { CountryIdentificationCodeType.Create(_CountryIdentificationSchemeType.imk, citizen.CountryCode.Value.ToString()) },
                SprogKode = null
            };
        }

    }
}
