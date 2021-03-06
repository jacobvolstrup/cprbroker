﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CprBroker.DBR;

namespace CprBroker.Tests.DBR
{
    namespace PersonConversionTests
    {
        [TestFixture]
        public class ConvertPersons : DbrTestBase
        {
            [Test]
            public void _100_ConvertPersons_Extract_ExistsInQueue()
            {
                // TODO: Should this go under CprDirect.Tests??
                CprBroker.Providers.CPRDirect.ExtractManager.ImportText(CprBroker.Tests.CPRDirect.Properties.Resources.U12170_P_opgavenr_110901_ADRNVN_FE_FixedLength);
                var q = CprBroker.Engine.Queues.Queue.GetQueues<CprBroker.Providers.CPRDirect.ExtractStagingQueue>().Single();
                var items = q.GetNext(1);
                Assert.IsNotEmpty(items);
            }

            [Test]
            public void _200_ConvertPersons_Extract_GoesToBaseDbrQueue()
            {
                CprBroker.Providers.CPRDirect.ExtractManager.ImportText(CprBroker.Tests.CPRDirect.Properties.Resources.U12170_P_opgavenr_110901_ADRNVN_FE_FixedLength);
                var stagingQueue = CprBroker.Engine.Queues.Queue.GetQueues<CprBroker.Providers.CPRDirect.ExtractStagingQueue>().Single();
                stagingQueue.RunOneBatch();
                var dbrBaseQueue = CprBroker.Engine.Queues.Queue.GetQueues<CprBroker.Providers.CPRDirect.DbrBaseQueue>().Single();
                var items = dbrBaseQueue.GetNext(1);
                Assert.IsNotEmpty(items);
            }

            [Test]
            public void _300_ConvertPersons_Extract_GoesToDbrQueue()
            {
                // Init DB
                CprBroker.Providers.CPRDirect.ExtractManager.ImportText(CprBroker.Tests.CPRDirect.Properties.Resources.U12170_P_opgavenr_110901_ADRNVN_FE_FixedLength);
                var stagingQueue = CprBroker.Engine.Queues.Queue.GetQueues<CprBroker.Providers.CPRDirect.ExtractStagingQueue>().Single();
                var dbrBaseQueue = CprBroker.Engine.Queues.Queue.GetQueues<CprBroker.Providers.CPRDirect.DbrBaseQueue>().Single();

                var values = new Dictionary<string, string>();
                CprBroker.Engine.DataProviderConfigProperty.Templates.SetConnectionString(DbrDatabase.ConnectionString, values);
                var dbrQueue = CprBroker.Engine.Queues.Queue.AddQueue<DbrQueue>(CprBroker.Providers.CPRDirect.DbrBaseQueue.TargetQueueTypeId, values, 100, 1);

                // Now run
                stagingQueue.RunOneBatch();
                dbrBaseQueue.RunOneBatch();
                var items = dbrQueue.GetNext(1);
                Assert.IsNotEmpty(items);
            }

            [Test]
            public void _400_DbrQueue_GoesToDbrDatabase([ValueSource(typeof(PerPerson.PersonBaseTest), "CprNumbers")] string pnr)
            {
                // Init DB & env
                CprBroker.Engine.BrokerContext.Initialize(CprBroker.Utilities.Constants.BaseApplicationToken.ToString(), "test user");
                CprBroker.Providers.CPRDirect.ExtractManager.ImportText(CprBroker.Tests.CPRDirect.Properties.Resources.U12170_P_opgavenr_110901_ADRNVN_FE_FixedLength);

                var values = new Dictionary<string, string>();
                CprBroker.Engine.DataProviderConfigProperty.Templates.SetConnectionString(DbrDatabase.ConnectionString, values);

                Guid extractId;
                using (var partDataContext = new CprBroker.Providers.CPRDirect.ExtractDataContext())
                {
                    extractId = partDataContext.Extracts.Single().ExtractId;
                }

                using (var dataContext = new System.Data.Linq.DataContext(DbrDatabase.ConnectionString))
                {
                    var sql = "select count(*) from DTTOTAL WHERE PNR = {0}";
                    var c1 = dataContext.ExecuteQuery<int>(sql, pnr).Single();
                    Assert.AreEqual(0, c1);

                    var dbrQueue = CprBroker.Engine.Queues.Queue.AddQueue<DbrQueue>(CprBroker.Providers.CPRDirect.DbrBaseQueue.TargetQueueTypeId, values, 100, 1);
                    var dbrQueueItem = new CprBroker.Providers.CPRDirect.ExtractQueueItem() { ExtractId = extractId, PNR = pnr };
                    dbrQueue.Enqueue(dbrQueueItem);

                    dbrQueue.RunOneBatch();

                    var c2 = dataContext.ExecuteQuery<int>(sql, pnr).Single();
                    Assert.Greater(c2, 0);
                }
            }
        }
    }
}
