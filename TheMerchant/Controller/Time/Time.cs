using System;
using System.Collections.Generic;
using System.Text;

namespace TheMerchant.Controller.Time
{
    public class Time
    {
        #region Enum Month
        public enum Month
        {
            JANUARY     = 1,
            FEBRUARY    = 2,
            MARCH       = 3,
            APRIL       = 4,
            MAY         = 5,
            JUNE        = 6,
            JULY        = 7,
            AUGUST      = 8,
            SEPTEMBER   = 9,
            OCTOBER     = 10,
            NOVEMBER    = 11,
            DECEMBER    = 12
        }
        #endregion Enum Month

        #region Properties

        public int Year { get; }
        public Month Mth { get; }
        public int Day { get; }
        public int Hour { get; }
        public int Minute { get; }

        public int CountCallbacks { get; }

        #endregion Properties

        #region Events

        public event EventHandler<TimeEventArgs> EventTimeChange;
        public event EventHandler<TimeEventArgs> EventNewDay;
        public event EventHandler<TimeEventArgs> EventNewWeek;
        public event EventHandler<TimeEventArgs> EventNewMonth;
        public event EventHandler<TimeEventArgs> EventNewYear;

        protected virtual void OnEventTimeChange(TimeEventArgs args)
        {
            EventTimeChange?.Invoke(this, args);
        }

        protected virtual void OnEventNewDay(TimeEventArgs args)
        {
            EventNewDay?.Invoke(this, args);
        }

        protected virtual void OnEventNewWeek(TimeEventArgs args)
        {
            EventNewWeek?.Invoke(this, args);
        }

        protected virtual void OnEventNewMonth(TimeEventArgs args)
        {
            EventNewMonth?.Invoke(this, args);
        }

        protected virtual void OnEventNewYear(TimeEventArgs args)
        {
            EventNewYear?.Invoke(this, args);
        }

        #endregion Events

        #region Methods

        public Time(int year, Month month, int day, int hour, int minute)
        {

        }

        public void AddMinute(int minute)
        {

        }

        public void AddHour(int hour = 1)
        {

        }

        public void AddDay(int day = 1)
        {

        }

        public int AddCallback(int year, Month month, int day, int hour, int minute, Action callback)
        {
            return -1;
        }

        public int RemoveCallback(int index)
        {
            return -1;
        }

        #endregion Methods
    }
}
