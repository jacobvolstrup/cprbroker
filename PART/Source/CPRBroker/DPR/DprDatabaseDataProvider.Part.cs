﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CprBroker.Engine;
using CprBroker.Schemas;
using CprBroker.Schemas.Part;
using CprBroker.Schemas.Util;
using System.Linq.Expressions;


namespace CprBroker.Providers.DPR
{
    public partial class DprDatabaseDataProvider : ClientDataProvider, IPartReadDataProvider
    {
        public static readonly Guid ActorId = new Guid("{4A953CF9-B4C1-4ce9-BF09-2BF655DC61C7}");

        #region IPartReadDataProvider Members

        public RegistreringType1 Read(PersonIdentifier uuid, LaesInputType input, Func<string, Guid> cpr2uuidFunc, out QualityLevel? ql)
        {
            CprBroker.Schemas.Part.RegistreringType1 ret = null;
            EnsurePersonDataExists(uuid.CprNumber);

            //TODO: Get values from Input
            DateTime? effectDate = null;
            if (!effectDate.HasValue)
            {
                effectDate = DateTime.Today;
            }
            using (var dataContext = new DPRDataContext(this.ConnectionString))
            {
                var db =
                (
                    from personInfo in PersonInfo.PersonInfoExpression.Compile()(dataContext)
                    where personInfo.PersonName.PNR == Decimal.Parse(uuid.CprNumber)
                    select personInfo
                ).FirstOrDefault();

                if (db != null)
                {
                    ret = db.ToRegisteringType1(effectDate, cpr2uuidFunc, dataContext);
                }
            }
            ql = QualityLevel.DataProvider;
            return ret;
        }

        #endregion
    }
}
