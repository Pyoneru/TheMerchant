using System;
using System.Collections.Generic;
using System.Text;

namespace TheMerchant.Model
{
    public class Time
    {
        public int Hour { get; set; }
        public int Minute { get; set; }

        public Time(int hour, int minute)
        {
            Hour = hour;
            Minute = minute;
        }

        public Time()
        {

        }

        public override bool Equals(object obj)
        {
            return obj is Time time &&
                   Hour == time.Hour &&
                   Minute == time.Minute;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Hour, Minute);
        }
    }
}
