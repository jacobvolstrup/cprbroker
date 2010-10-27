﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CPRBroker.Schemas;
using CPRBroker.Schemas.Part.Enums;

namespace CPRBroker.Providers.DPR
{
    /// <summary>
    /// Contains some utility functions that assis DPR
    /// </summary>
    public static class Utilities
    {
        /// <summary>
        /// Converts the first not null decimal? to a date
        /// </summary>
        /// <param name="decimalValues">Array of decimals</param>
        /// <returns></returns>
        public static DateTime? DateFromFirstDecimal(params decimal?[] decimalValues)
        {
            DateTime? ret = null;
            foreach (decimal? d in decimalValues)
            {
                ret = DateFromDecimal(d);
                if (ret.HasValue)
                {
                    break;
                }
            }
            return ret;
        }


        public static DateTime? DateFromDecimal(decimal? d)
        {
            if (d.HasValue && d.Value > 0)
            {
                return DateFromDecimalString(d.ToString());
            }
            return null;
        }

        /// <summary>
        /// Converts a decimal in string representation to a date
        /// </summary>
        /// <param name="str">String representing a decimal value</param>
        /// <returns></returns>
        public static DateTime? DateFromDecimalString(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                switch (str.Length)
                {
                    case 8:
                        return DateTime.ParseExact(str, "yyyyMMdd", null);

                    case 12:
                        if (str.EndsWith("99"))
                            str = str.Substring(0, 10) + "00";
                        return DateTime.ParseExact(str, "yyyyMMddHHmm", null);

                }
            }
            return null;
        }

        public static decimal? DecimalFromDate(DateTime? date)
        {
            if (date.HasValue)
            {
                if (date.Value.Date < date.Value) // has a time component
                {
                    return Decimal.Parse(date.Value.ToString("yyyyMMddHHmm"));
                }
                else
                {
                    return Decimal.Parse(date.Value.ToString("yyyyMMdd"));
                }
            }
            else
            {
                return null;
            }
        }

        public static Gender GenderFromChar(char? gen)
        {
            switch (gen)
            {
                case 'M':
                    return Gender.Male;
                    break;
                case 'K':
                    return Gender.Female;
                    break;
                default:
                    return Gender.Unknown;
                    break;
            }
        }

    }
}
