﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CprBroker.Schemas.Part;
using CprBroker.Utilities;

namespace CprBroker.Providers.DPR
{
    public partial class ParentalAuthority
    {
        public PersonRelationType ToRelationType(PersonTotal personTotal, Relation[] relations, Func<decimal, Guid> cpr2uuidConverter)
        {
            string pnr = null;
            var relation = relations.Where(r => r.PNR == this.ChildPNR && r.RelationType == this.RelationType).SingleOrDefault();
            switch ((int)this.RelationType)
            {
                case 3:
                    pnr = personTotal.MotherPersonalOrBirthDate;
                    break;
                case 4:
                    pnr = personTotal.FatherPersonalOrBirthdate;
                    break;
                case 5:
                    pnr = relation.RelationPNR.ToPnrDecimalString();
                    break;
                case 6:
                    pnr = relation.RelationPNR.ToPnrDecimalString();
                    break;
            }
            if (pnr != null)
            {
                var pnrDec = Utilities.ToParentPnr(pnr);
                if (pnrDec.HasValue)
                    return PersonRelationType.Create(cpr2uuidConverter(pnrDec.Value), StartDate, EndDate);
            }
            return null;
        }
    }
}
