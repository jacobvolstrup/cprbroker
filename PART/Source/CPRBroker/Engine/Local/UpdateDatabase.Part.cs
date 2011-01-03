﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CprBroker.Engine;
using CprBroker.Schemas;
using CprBroker.Schemas.Part;
using CprBroker.DAL;
using CprBroker.DAL.Part;


namespace CprBroker.Engine.Local
{

    public partial class UpdateDatabase
    {
        /// <summary>
        /// Updates the system database with person registration objects
        /// </summary>
        /// <param name="personUUID"></param>
        /// <param name="personRegistraion"></param>
        public static void UpdatePersonRegistration(Guid personUUID, Schemas.Part.RegistreringType1 personRegistraion)
        {
            if (MergePersonRegistration(personUUID, personRegistraion))
            {
                // TODO: move this call to a separate phase in request processing
                NotifyPersonRegistrationUpdate(personUUID);
            }
        }

        private static void NotifyPersonRegistrationUpdate(Guid personUuid)
        {
            NotificationQueueService.NotificationQueue notificationQueueService = new CprBroker.Engine.NotificationQueueService.NotificationQueue();
            notificationQueueService.Url = Config.Properties.Settings.Default.NotificationQueueServiceUrl;
            notificationQueueService.ApplicationHeaderValue = new CprBroker.Engine.NotificationQueueService.ApplicationHeader()
            {
                ApplicationToken = DAL.Applications.Application.BaseApplicationToken.ToString(),
                UserToken = Constants.UserToken
            };
            // TODO: use the value of the result
            bool result = notificationQueueService.Enqueue(personUuid);
        }

        private static bool MergePersonRegistration(Guid personUUID, Schemas.Part.RegistreringType1 personRegistraion)
        {
            //TODO: Modify this method to allow searching for registrations that have a fake date of Today, these should be matched by content rather than registration date
            using (var dataContext = new PartDataContext())
            {
                // Match db registrations by UUID, ActorId and registration date
                var existingInDb = (from dbReg in dataContext.PersonRegistrations
                                    where dbReg.UUID == personUUID
                                    && dbReg.RegistrationDate == personRegistraion.TidspunktDatoTid.ToDateTime()                                    
                                    && dbReg.ActorText == personRegistraion.AktoerTekst
                                    select dbReg).ToArray();

                // Perform a content match if key match is found
                if (existingInDb.Length > 0)
                {
                    existingInDb = Array.FindAll(existingInDb, (db) => db.ToXmlType().Equals(personRegistraion));
                }
                // If there are really no matches, update the database
                if (existingInDb.Length == 0)
                {
                    var dbPerson = (from dbPers in dataContext.Persons
                                    where dbPers.UUID == personUUID
                                    select dbPers).FirstOrDefault();
                    if (dbPerson == null)
                    {
                        dbPerson = new CprBroker.DAL.Part.Person()
                        {
                            UUID = personUUID
                        };
                        dataContext.Persons.InsertOnSubmit(dbPerson);
                    }
                    var dbReg = DAL.Part.PersonRegistration.FromXmlType(personRegistraion);
                    dbReg.Person = dbPerson;
                    dataContext.PersonRegistrations.InsertOnSubmit(dbReg);
                    dataContext.SubmitChanges();
                    return true;
                }
            }
            return false;
        }
    }
}
