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
 * Niels Elgaard Larsen
 * Leif Lodahl
 * Steen Deth
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
using CprBroker.Schemas.Part;

namespace CprBroker.Providers.DPR
{
    /// <summary>
    /// Contains constants that are used in DPR
    /// </summary>
    public class Constants
    {
        public static UnikIdType Actor
        {
            get
            {
                return UnikIdType.Create(new Guid("{4A953CF9-B4C1-4ce9-BF09-2BF655DC61C7}"));
            }
        }


        public const string CprNationalityKmdCode = "5001";
        public const string StatelessKmdCode = "5103";
        public const string DenmarkKmdCode = "5100";

        public const string DiversionOperationName = "Diversion";
        public static readonly Encoding DiversionEncoding = Encoding.UTF7;

        
    }

    public enum InquiryType
    {
        DataNotUpdatedAutomatically = 0,
        DataUpdatedAutomaticallyFromCpr = 1,
        DeleteAutomaticDataUpdateFromCpr = 3
    }

    public enum DetailType
    {
        MasterData = 0, // Only to client
        ExtendedData = 1 // Put to DPR database
    }

    public class EvenOdd
    {
        public const char Even = 'L';
        public const char Odd = 'U';
    }
}
