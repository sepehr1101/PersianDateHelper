using PersianDateHelper.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersianDateHelper
{
    internal static class DateConvertor
    {
        private const string SLASH = "/";
        private const char ZERO_CHAR= '0';
        private const int TWO= 2;

        internal static string GetJalaliDate(DateTime dateTime, PersianDateType persianDateType)
        {
            var yearMonthDay = YearMonthDayManager.GetYearMonthDay(dateTime);
            switch (persianDateType)
            {
                case PersianDateType.EightCharWithoutSlash:
                    return GetJalaliDateEightCharWithoutSlash(yearMonthDay);
                case PersianDateType.EightCharWithSlash:
                    return GetJalaliDateEightCharWithSlash(yearMonthDay);
                case PersianDateType.SixChar:
                    return GetJalaliDateSixChar(yearMonthDay);
                case PersianDateType.TenChar:
                    return GetJalaliDateTenChar(yearMonthDay);
                default:
                    throw new NotImplementedException();
            }
        }

        private static string GetJalaliDateEightCharWithoutSlash(YearMonthDay yearMonthDay)
        {
            var eightCharWithoutSlash = String.Concat(yearMonthDay.Year,
                  PadLeftZero(yearMonthDay.Month),
                  PadLeftZero(yearMonthDay.Day));
            return eightCharWithoutSlash;
        }
        private static string GetJalaliDateEightCharWithSlash(YearMonthDay yearMonthDay)
        {
            var tenCharWithSlash = String.Concat(yearMonthDay.Year,SLASH,
                  PadLeftZero(yearMonthDay.Month),
                  SLASH,
                  PadLeftZero(yearMonthDay.Day));
            var eightCharWithSlash= tenCharWithSlash.Substring(2, tenCharWithSlash.Count() - 2);
            return eightCharWithSlash;
        }
        private static string GetJalaliDateSixChar(YearMonthDay yearMonthDay)
        {
            var eightCharWithoutSlash = String.Concat(yearMonthDay.Year,
                  PadLeftZero(yearMonthDay.Month),
                  PadLeftZero(yearMonthDay.Day));
            var sixCharWithSlash = eightCharWithoutSlash.Substring(TWO, eightCharWithoutSlash.Count() - TWO);
            return sixCharWithSlash;
        }
        private static string GetJalaliDateTenChar(YearMonthDay yearMonthDay)
        {
            var tenChar = String.Concat(yearMonthDay.Year, SLASH, 
                  PadLeftZero(yearMonthDay.Month),
                  SLASH,
                  PadLeftZero(yearMonthDay.Day));
            return tenChar;
        }
        private static string PadLeftZero(int value)
        {
            var paddedString = value.ToString().PadLeft(TWO, ZERO_CHAR);
            return paddedString;
        }
    }
}
