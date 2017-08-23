using PersianDateHelper.DomainEntities;
using System;
using System.Globalization;

namespace PersianDateHelper
{
    internal static class DateDifferenceManager
    {
        //
        /// <summary>
        /// اختلاف بین دو تاریخ شمسی را به تعداد روز محاسبه میکند
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns>اختلاف به تعداد روز</returns>
        internal static int GetDateDifference(string fromDate, string toDate)
        {
            var fromYearMonthDay = YearMonthDayManager.GetYearMonthDay(fromDate);
            var toYearMonthDay = YearMonthDayManager.GetYearMonthDay(toDate);
            var fromMiladidate = GetDateTime(fromYearMonthDay);
            var toMiladiDate = GetDateTime(toYearMonthDay);
            int dateDifference = (int)(toMiladiDate - fromMiladidate).TotalDays;
            return dateDifference;
        }
        //
        internal static decimal GetDateDifferenceRate(string fromOverallDate, string toOverallDate, string fromPartialDate,
            string toPartialDate)
        {
            var overalDateDifference = GetDateDifference(fromOverallDate, toOverallDate);
            var partialDateDifference = GetDateDifference(fromPartialDate, toPartialDate);
            decimal dateDivisionRate = Decimal.Divide(partialDateDifference, overalDateDifference);
            return dateDivisionRate;
        }
        //
        /// <summary>
        /// تاریخ استاندارد میلادی برمیگرداند
        /// </summary>
        /// <param name="yearMonthDay"></param>
        /// <returns>DateTime (miladi)</returns>     
        private static DateTime GetDateTime(YearMonthDay yearMonthDay,bool convertFoolishDates=false)
        {
            if (convertFoolishDates)
            {
                MakeFoolishDateStandard(ref yearMonthDay);
            }
            DateTime dateMiladi = new PersianCalendar().ToDateTime(yearMonthDay.Year, yearMonthDay.Month, yearMonthDay.Day, 0, 0, 0, 0);
            return dateMiladi;
        }
        //
        internal static int GetPartialDateCount(string fromOverallDate, string toOverallDate, string fromPartialDate,
            string toPartialDate)
        {
            string date1, date2;
            const int ZERO = 0;

            var fromOverallMiladi = GetDateTime(YearMonthDayManager.GetYearMonthDay(fromOverallDate));
            var toOverallMiladi = GetDateTime(YearMonthDayManager.GetYearMonthDay(toOverallDate));
            var fromPartialMiladi = GetDateTime(YearMonthDayManager.GetYearMonthDay(fromPartialDate));
            var toPartialMiladi = GetDateTime(YearMonthDayManager.GetYearMonthDay(toPartialDate));

            ValidateDates(fromOverallMiladi, toOverallMiladi);
            ValidateDates(fromPartialMiladi, toPartialMiladi);
            //
            // <--------------->p
            //          <--------------------------->o
            if (fromPartialMiladi <= fromOverallMiladi && toPartialMiladi <= toOverallMiladi && fromOverallMiladi <= toPartialMiladi)
            {
                date1 = fromOverallDate;
                date2 = toPartialDate;
            }
            //
            //  <----------->p
            //<---------------->o
            else if (fromOverallMiladi <= fromPartialMiladi && toPartialMiladi <= toOverallMiladi && fromOverallMiladi <= toPartialMiladi)
            {
                date1 = fromPartialDate;
                date2 = toPartialDate;
            }
            //
            //             <------>p
            // <-------------->o
            else if (fromOverallMiladi <= fromPartialMiladi && toOverallMiladi <= toPartialMiladi && fromPartialMiladi <= toOverallMiladi)
            {
                date1 = fromPartialDate;
                date2 = toOverallDate;
            }
            //
            // <----------------------------->p
            //    <------------------->o
            else if (fromPartialMiladi <= fromOverallMiladi && toOverallMiladi <= toPartialMiladi && fromOverallMiladi <= toPartialMiladi)
            {
                date1 = fromOverallDate;
                date2 = toOverallDate;
            }
            else
            {
                return ZERO;
            }
            return GetDateDifference(date1, date2);
        }
        //
        /// <summary>
        /// validated two dateTime instance for subtracttion
        /// </summary>
        /// <param name="date1">date1</param>
        /// <param name="date2">date2</param>
        private static void ValidateDates(DateTime date1, DateTime date2)
        {
            if (date2 < date1)
            {
                throw new NotSupportedException();
            }
        }
        //
        private static void MakeFoolishDateStandard(ref YearMonthDay yearMonthDay)
        {
            if (yearMonthDay.Month == 12 && yearMonthDay.Day == 30)
            {
                yearMonthDay.Day = 29;
            }
            if (yearMonthDay.Month > 12)
            {
                yearMonthDay.Month = 12;
            }
            if (yearMonthDay.Day > 31)
            {
                yearMonthDay.Day = 31;
            }
        }
    }
}
