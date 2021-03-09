using System;
using System.Collections.Generic;
using System.Text;
using TheMerchant.Model;

namespace TheMerchant.Service
{
    public class TimestampService
    {

        #region Creators

        public Timestamp CreateTimestamp(int year = 1, int month = 1, int week = 1, int day = 1, int hour = 12, int minute = 0)
        {
            return new Timestamp(
                CreateDate(year, month, week, day),
                CreateTime(hour, minute)
                );
        }

        public Date CreateDate(int year = 1, int month = 1, int week = 1, int day = 1)
        {
            ValidateDate(year, month, week, day);

            return new Date(year, month, week, day);
        }

        public Time CreateTime(int hour = 12, int minute = 0)
        {
            ValidateTime(hour, minute);
            return new Time(hour, minute);
        }

        #endregion Creators

        #region Copy

        public Timestamp CopyTimestamp(Timestamp ts)
        {
            return new Timestamp(
                CreateDate(ts.Date.Year, ts.Date.Month, ts.Date.Week, ts.Date.Day),
                CreateTime(ts.Time.Hour, ts.Time.Minute)
                );
        }

        public Date CopyDate(Date date)
        {
            return CreateDate(date.Year, date.Month, date.Week, date.Day);
        }

        public Time CopyTime(Time time)
        {
            return CreateTime(time.Hour, time.Minute);
        }

        #endregion Copy

        #region Set
        public void SetTimestamp(Timestamp ts, int year, int month, int week, int day, int hour, int minute)
        {
            ValidateDate(year, month, week, day);
            ValidateTime(hour, minute);

            ts.Date.Year = year;
            ts.Date.Month = month;
            ts.Date.Week = week;
            ts.Date.Day = day;
            ts.Time.Hour = hour;
            ts.Time.Minute = minute;
        }

        public void SetDateTimestamp(Timestamp ts, int year, int month, int week, int day)
        {
            ValidateDate(year, month, week, day);

            ts.Date.Year = year;
            ts.Date.Month = month;
            ts.Date.Week = week;
            ts.Date.Day = day;
        }

        public void setTimeTimestamp(Timestamp ts, int hour, int minute)
        {
            ValidateTime(hour, minute);

            ts.Time.Hour = hour;
            ts.Time.Minute = minute;
        }

        #endregion Set

        #region New

        #endregion New

        #region Operation



        #endregion Operation

        private void ValidateDate(int year, int month, int week, int day)
        {
            if (year <= 0)
                throw new ArgumentException("Year can not be negative");
            if (month <= 0 || month > 12)
                throw new ArgumentException("Month must be in range 1-12");
            if (week <= 0 || week > 4)
                throw new ArgumentException("Week must be in range 1-4");
            if (day <= 0 || day > 28)
                throw new ArgumentException("Day must be in range 1-28");
        }

        private void ValidateTime(int hour, int minute)
        {
            if (hour < 0 || hour > 23)
                throw new ArgumentException("Hour must be in range 0-23");
            if (minute < 0 || hour > 59)
                throw new ArgumentException("Minute must be in range 0-59");
        }
    }
}
