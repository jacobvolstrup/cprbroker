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

namespace CprBroker.Providers.CPRDirect
{
    public static class Converters
    {
        public static string DecimalToString(decimal value)
        {
            return CprBroker.Utilities.Strings.DecimalToString(value);
        }
        public static string DecimalToString(decimal value, int length)
        {
            return CprBroker.Utilities.Strings.DecimalToString(value, length);
        }

        public static DateTime? ToDateTime(DateTime? value, char uncertainty)
        {
            if (ToDateTimeUncertainty(uncertainty))
                return value;
            else
                return null;
        }

        public static bool ToDateTimeUncertainty(char uncertainty)
        {
            if (uncertainty == ' ')
                return true;
            else
                return false;
        }

        public static String ToNameString(string value, char uncertainty)
        {
            /*
                Decision made to ignore the markers, interpretation written here for the sake of documentation
                + : The name is abbreviated 
                * : The name contains characters that can not be reported to the CPR 
                = : The name is inadequately documented
            */
            return value;
        }

        public static string ToPnrStringOrNull(string pnr)
        {
            decimal decimalPnr;
            if (decimal.TryParse(pnr, out decimalPnr))
            {
                if (decimalPnr.ToString().Length == 9 || decimalPnr.ToString().Length == 10)
                {
                    return DecimalToString(decimalPnr, 10);
                }
            }
            return null;
        }

        public static PersonGenderCodeType ToPersonGenderCodeType(char gender)
        {
            switch (gender.ToString().ToUpper()[0])
            {
                case 'M':
                    return PersonGenderCodeType.male;
                    break;
                case 'K':
                    return PersonGenderCodeType.female;
                    break;
                default:
                    throw new ArgumentException(
                        string.Format("Invalied value <{0}>, must be either 'M' or 'K'", gender),
                        "gender");
            }
        }

        public static bool ToFolkekirkeMedlemIndikator(char churchRelation)
        {
            switch (churchRelation.ToString().ToUpper()[0])
            {
                case 'A':
                    return false;
                    break;
                case 'F':
                    return true;
                    break;
                case 'M':
                    return true;
                    break;
                case 'S':
                    return true;
                    break;
                case 'U':
                    return false;
                    break;
                default:
                    throw new ArgumentException(
                        string.Format("Invalied value <{0}>, must be 'A', 'F', 'M', 'S' or 'U'", churchRelation),
                        "churchRelation");
            }
        }

        public static bool IsValidCorrectionMarker(char correctionMarker)
        {
            return correctionMarker == CorrectionMarker.OK;
        }

    }
}
