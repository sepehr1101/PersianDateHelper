using System;
using System.Collections.Generic;
using System.Text;
using PersianDateHelper.DomainEntities;

namespace PersianDateHelper
{
    public static class Util
    {
        public static int GetDateDifference(string fromDate, string toDate)
        {
           return DateDifferenceManager.GetDateDifference(fromDate, toDate);
        }

        public static decimal GetDateDifferenceRate(string fromOverallDate, string toOverallDate, string fromPartialDate,
            string toPartialDate)
        {
            return DateDifferenceManager.GetDateDifferenceRate(fromOverallDate, toOverallDate, fromPartialDate, toPartialDate);
        }

        public static int GetPartialDateCount(string fromOverallDate, string toOverallDate, string fromPartialDate,
            string toPartialDate)
        {
            return DateDifferenceManager.GetPartialDateCount(fromOverallDate, toOverallDate, fromPartialDate, toPartialDate);
        }

        public static YearMonthDay GetYearMonthDay(string persianDate)
        {
            return YearMonthDayManager.GetYearMonthDay(persianDate);
        }

        public static string GetJalaliDate(DateTime dateTime, PersianDateType persianDateType)
        {
            return DateConvertor.GetJalaliDate(dateTime, persianDateType);
        }
    }
}
