using System;
using System.Collections.Generic;
using System.Text;
using PersianDateHelper.DomainEntities;
using System.Linq;

namespace PersianDateHelper
{
    internal static class YearMonthDayManager
    {
        internal static YearMonthDay GetYearMonthDay(string persianDate)
        {
            var persianDateType = GetPersianDateType(persianDate);
            var yearMonthDay = GetYearMonthDay(persianDate, persianDateType);
            return yearMonthDay;
        }
        //
        /// <summary>
        /// Determines Persian Date Type (8-Char , 10-Char, 8-Char , 8-Chal-Slash)
        /// </summary>
        /// <param name="persianDate">Persian Date </param>
        /// <returns>PersianDateType</returns>
        private static PersianDateType GetPersianDateType(string persianDate)
        {
            const int SIX = 6;
            const int Eight = 8;
            const int TEN = 10;
            var length = persianDate.Length;
            switch (length)
            {
                case SIX:
                    return PersianDateType.SixChar;
                case Eight:
                    bool containsSlash = ContainsSlash(persianDate);
                    return containsSlash ? PersianDateType.EightCharWithSlash : PersianDateType.EightCharWithoutSlash;
                case TEN:
                    return PersianDateType.TenChar;
                default:
                    throw new NotSupportedException();
            }
        }
        //
        private static bool ContainsSlash(string persianDate)
        {
            return persianDate.Contains("/") ? true : false;
        }
        //
        private static YearMonthDay GetYearMonthDay(string persianDate, PersianDateType persianDateType)
        {
            switch (persianDateType)
            {
                case PersianDateType.SixChar:
                    return GetYearMonthDay6Digit(persianDate);

                case PersianDateType.EightCharWithoutSlash:
                    return GetYearMonthDay8DigitWithoutSlash(persianDate);

                case PersianDateType.EightCharWithSlash:
                    return GetYearMonthDay8DigitWithSlash(persianDate);

                case PersianDateType.TenChar:
                    return GetYearMonthDay10(persianDate);
                default:
                    throw new NotSupportedException();
            }
        }
        //
        private static YearMonthDay GetYearMonthDay6Digit(string sixDigitDate)
        {
            var _4CharYear = "13" + sixDigitDate;
            var yearMonthDay = ToYearMonthDay(_4CharYear, 0, 4, 4, 2, 6, 2);
            return yearMonthDay;
        }
        //
        private static YearMonthDay GetYearMonthDay8DigitWithoutSlash(string eightDigitWithoutSlash)
        {
            var yearMonthDay = ToYearMonthDay(eightDigitWithoutSlash, 0, 4, 4, 2, 6, 2);
            return yearMonthDay;
        }
        //
        private static YearMonthDay GetYearMonthDay8DigitWithSlash(string eightDigitWithSlash)
        {
            var _4charYear ="13"+ eightDigitWithSlash;
            var yearMonthDay = ToYearMonthDay(_4charYear, 0, 4, 5, 2, 8, 2);
            return yearMonthDay;
        }
        //
        private static YearMonthDay GetYearMonthDay10(string tenDigitDate)
        {
            var yearMonthDay = ToYearMonthDay(tenDigitDate, 0, 4, 5, 2, 8, 2);
            return yearMonthDay;
        }
        //
        private static YearMonthDay ToYearMonthDay(string fullString, int yearIndex, int yearLength,
            int monthIndex, int monthLength, int dayIndex, int dayLength)
        {           
            var stringYear = fullString.Substring(yearIndex, yearLength);
            if (yearLength == 4 && stringYear.Count()<4)
            {
                throw new InvalidOperationException("expected 4 lenght-char of year found less than 4");
            }
            var year = Int32.Parse(stringYear);
            var month = Int32.Parse(fullString.Substring(monthIndex, monthLength));
            var day = Int32.Parse(fullString.Substring(dayIndex, dayLength));
            return new YearMonthDay(year, month, day);
        }       
    }
}
