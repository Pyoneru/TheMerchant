using System;
using System.Collections.Generic;
using System.Text;

namespace TheMerchant.Controller.Time
{
    public class TimeEventArgs : EventArgs
    {
        public int year { get; }
        public Time.Month month { get; }
        public int day { get; }
        public int hour { get; }
        public int minute { get; }

        public TimeEventArgs(int year, Time.Month month, int day, int hour, int minute)
        {
            this.year = year;
            this.month = month;
            this.day = day;
            this.hour = hour;
            this.minute = minute;
        }
    }
}
