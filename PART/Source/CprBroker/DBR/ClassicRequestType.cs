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
using System.Data.SqlClient;
using CprBroker.Engine;
using CprBroker.Data.DataProviders;
using CprBroker.Providers.CPRDirect;
using CprBroker.Providers.DPR;
using CprBroker.Utilities.Config;

namespace CprBroker.DBR
{
    public partial class ClassicRequestType
    {
        public override DiversionResponse Process(string dprConnectionString)
        {
            if (this.LargeData == Providers.DPR.DetailType.ExtendedData && this.Type == Providers.DPR.InquiryType.DataUpdatedAutomaticallyFromCpr)
            {
                var providers = LoadDataProviders();

                var response = providers
                    .Select(p => p.GetPerson(this.PNR))
                    .First(p => p != null);

                if (response != null)
                {
                    using (var conn = new SqlConnection(dprConnectionString))
                    {
                        using (var dataContext = new DPRDataContext(conn))
                        {
                            CprConverter.AppendPerson(response, dataContext);

                            conn.Open();
                            using (var trans = conn.BeginTransaction())
                            {
                                dataContext.Transaction = trans;
                                CprConverter.DeletePersonRecords(this.PNR, dataContext);
                                conn.BulkInsertChanges(dataContext.GetChangeSet().Inserts, trans);
                                trans.Commit();
                            }
                            var ret = new ClassicResponseType()
                            {
                                Type = this.Type,
                                LargeData = this.LargeData,
                                PNR = this.PNR,
                                ErrorNumber = "00",
                                Data = "Basen er opdateret"
                            };

                            return ret;
                        }
                    }
                }
                else
                {
                    // TODO: person not found, return error
                    throw new NotImplementedException();
                }
            }
            else
            {
                // TODO: unimplemented mode of operation
                throw new NotImplementedException();
            }
        }

        public virtual IEnumerable<ICprDirectPersonDataProvider> LoadDataProviders()
        {
            DataProvidersConfigurationSection section = ConfigManager.Current.DataProvidersSection;
            var providerFactory = new DataProviderFactory();
            DataProvider[] dbProviders = providerFactory.ReadDatabaseDataProviders();

            var providers = providerFactory
                .GetDataProviderList(section, dbProviders, typeof(ICprDirectPersonDataProvider), Schemas.SourceUsageOrder.LocalThenExternal)
                .Select(p => p as ICprDirectPersonDataProvider);
            return providers;
        }
    }
}
