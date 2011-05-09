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
using System.Linq;
using System.Text;
using CprBroker.Schemas;
using CprBroker.Utilities;

namespace CprBroker.Data.Part
{
    /// <summary>
    /// Represents the PersonMapping table
    /// Responsible for local mapping between UUID's and CPR numbers
    /// </summary>
    public partial class PersonMapping
    {
        /// <summary>
        /// Maps CPR Numbers to UUIDs
        /// </summary>
        /// <param name="cprNumbers"></param>
        /// <returns></returns>
        public static Guid?[] AssignGuids(params string[] cprNumbers)
        {
            Guid?[] ret = new Guid?[cprNumbers.Length];

            using (PartDataContext dataContext = new PartDataContext())
            {
                var foundPersons = dataContext.PersonMappings.AsQueryable();
                var pred = PredicateBuilder.False<PersonMapping>();

                foreach (var cprNumber in cprNumbers)
                {
                    pred = pred.Or((d) => d.CprNumber == cprNumber);
                }

                foundPersons = foundPersons.Where(pred);

                var foundPersonsArray = foundPersons.ToArray();

                for (int iPerson = 0; iPerson < cprNumbers.Length; iPerson++)
                {
                    var cprNumber = cprNumbers[iPerson];
                    var personMapping = (from d in foundPersonsArray where d.CprNumber == cprNumber select d).FirstOrDefault();

                    if (personMapping != null)
                    {
                        ret[iPerson] = personMapping.UUID;
                    }

                }
                dataContext.SubmitChanges();
            }
            return ret;
        }

        /// <summary>
        /// Maps a person UUID to a PersonIdentifier object.
        /// Returns null if no match is found.
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns></returns>
        public static PersonIdentifier GetPersonIdentifier(Guid uuid)
        {
            PersonIdentifier ret = null;
            using (var dataContext = new PartDataContext())
            {
                ret =
                (
                    from pm in dataContext.PersonMappings
                    where pm.UUID == uuid
                    select new PersonIdentifier()
                    {
                        CprNumber = pm.CprNumber,
                        UUID = uuid
                    }
                ).FirstOrDefault();
            }
            return ret;
        }
    }
}
