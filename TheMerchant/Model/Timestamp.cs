using System;
using System.Collections.Generic;
using System.Text;

namespace TheMerchant.Model
{
    public class Timestamp
    {
        public Date Date { get; set; }
        public Time Time { get; set; }

        public Timestamp(Date date, Time time)
        {
            Date = date;
            Time = time;
        }

        public Timestamp()
        {

        }

        public override bool Equals(object obj)
        {
            return obj is Timestamp timestamp &&
                   EqualityComparer<Date>.Default.Equals(Date, timestamp.Date) &&
                   EqualityComparer<Time>.Default.Equals(Time, timestamp.Time);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Date, Time);
        }
    }
}
