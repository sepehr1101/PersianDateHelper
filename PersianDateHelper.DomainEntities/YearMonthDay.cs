namespace PersianDateHelper.DomainEntities
{

    public struct YearMonthDay
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }

        public YearMonthDay(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;
        }
    }
}