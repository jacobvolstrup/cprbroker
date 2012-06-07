﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CprBroker.Schemas.Part;

namespace CprBroker.Providers.CPRDirect
{
    public partial class IndividualResponseType
    {
        private TilstandListeType ToTilstandListeType()
        {
            return new TilstandListeType()
            {
                CivilStatus = ToCivilStatusType(),
                LivStatus = ToLivStatusType(),
                LokalUdvidelse = ToLokalUdvidelseType()
            };
        }

        public LivStatusType ToLivStatusType()
        {
            return this.PersonInformation.ToLivStatusType();
        }

        public CivilStatusType ToCivilStatusType()
        {
            return this.CurrentCivilStatus.ToCivilStatusType(this.CurrentSeparation);            
        }

    }
}