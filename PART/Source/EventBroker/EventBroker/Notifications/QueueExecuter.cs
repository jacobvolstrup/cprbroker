﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CprBroker.Data.Queues;
using CprBroker.Engine.Queues;


namespace CprBroker.EventBroker.Notifications
{
    public class QueueExecuter : PeriodicTaskExecuter
    {
        public Queue Queue { get; set; }

        public QueueExecuter(Queue queue)
        {
            this.Queue = queue;
        }

        public static QueueExecuter[] GetQueues()
        {
            return Queue.GetQueues<Queue>()
                .Where(q => q != null)
                .Select(q => new QueueExecuter(q))
                .ToArray();
        }

        protected override TimeSpan CalculateActionTimerInterval(TimeSpan currentInterval)
        {
            return TimeSpan.FromSeconds(60);
        }

        protected override void PerformTimerAction()
        {
            this.Queue.RunOneBatch();
        }

    }

    public class QueueExecuterComparer : IEqualityComparer<QueueExecuter>
    {
        public bool Equals(QueueExecuter x, QueueExecuter y)
        {
            //Check whether the compared objects reference the same data.
            if (Object.ReferenceEquals(x, y)) return true;

            //Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            //Check whether the products' properties are equal.
            return x.Queue.QueueId == y.Queue.QueueId;
        }

        public int GetHashCode(QueueExecuter x)
        {
            //Check whether the object is null
            if (Object.ReferenceEquals(x, null))
                return 0;

            return x.Queue.QueueId.GetHashCode();
        }
    }
}
