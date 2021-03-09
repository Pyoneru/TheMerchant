using System;
using System.Collections.Generic;
using System.Text;

namespace TheMerchant.Model
{
    public class Date
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Week { get; set; }
        public int Day { get; set; }

        public Date(int year, int month, int week, int day)
        {
            Year = year;
            Month = month;
            Week = week;
            Day = day;
        }

        public Date()
        {

        }

        public override bool Equals(object obj)
        {
            return obj is Date date &&
                   Year == date.Year &&
                   Month == date.Month &&
                   Week == date.Week &&
                   Day == date.Day;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Year, Month, Week, Day);
        }
    }
}
