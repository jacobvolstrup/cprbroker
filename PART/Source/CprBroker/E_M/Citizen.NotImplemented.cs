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
        private static LokalUdvidelseType ToLokalUdvidelseType(Citizen citizen)
        {
            // No extension
            return null;
        }

        public virtual KontaktKanalType ToNextOfKin()
        {
            //TODO: Shoud NextOfKin be implemented?
            return null;
        }

        public virtual KontaktKanalType ToKontaktKanalType()
        {
            // No contact channels
            return null;
        }

        public virtual AdresseType ToAndreAdresse()
        {
            //TODO: Shoud other address be filled?
            return null;
        }

        public SundhedOplysningType ToSundhedOplysningType()
        {
            return null;
        }
    }
}