using System;
using System.Collections.Generic;
using System.Text;
using TheMerchant.Model;

namespace TheMerchant.Service
{
    public class TimestampService
    {

        public const int YEAR_DAYS = 12 * 28;
        public const int MONTH_DAYS = 28;
        public const int WEEK_DAYS = 7;

        public const int YEARS_HOURS = 12 * (28 * 24);
        public const int MONTH_HOURS = 28 * 24;
        public const int WEEK_HOURS = 7 * 24;
        public const int DAY_HOURS = 24;

        public const int YEAR_MINUTES = 12 * (28 * (24 * 60));
        public const int MONTH_MINUTES = 28 * (24 * 60);
        public const int WEEK_MINUTES = 7 * (24 * 60);
        public const int DAY_MINUTES = 24 * 60;
        public const int HOUR_MINUTES = 60;

        #region Creators

        public Timestamp CreateTimestamp(int year = 1, int month = 1, int week = 1, int day = 1, int hour = 12, int minute = 0)
        {
            return new Timestamp(
                CreateDate(year, month, week, day),
                CreateTime(hour, minute)
                );
        }

        public Timestamp CreateTimestampFromHours(int hour)
        {
            Timestamp ts = new Timestamp();

            ts.Date.Year = hour / YEARS_HOURS;
            hour -= ts.Date.Year * YEARS_HOURS;

            ts.Date.Month = hour / MONTH_HOURS;
            hour -= ts.Date.Month * MONTH_HOURS;

            ts.Date.Week = hour / WEEK_HOURS;
            hour -= ts.Date.Week * WEEK_HOURS;

            ts.Date.Day = hour / DAY_HOURS;
            hour -= ts.Date.Day * DAY_HOURS;

            ts.Time.Hour = hour;
            ts.Time.Minute = 0;

            return ts;
        }

        public Timestamp CreateTimestampFromMinutes(int minute)
        {
            Timestamp ts = new Timestamp();

            ts.Date.Year = minute / YEAR_MINUTES;
            minute -= ts.Date.Year * YEAR_MINUTES;

            ts.Date.Month = minute / MONTH_MINUTES;
            minute -= ts.Date.Month * MONTH_MINUTES;

            ts.Date.Week = minute / WEEK_MINUTES;
            minute -= ts.Date.Week * WEEK_MINUTES;

            ts.Date.Day = minute / DAY_MINUTES;
            minute -= ts.Date.Day * DAY_MINUTES;

            ts.Time.Hour = minute / HOUR_MINUTES;
            minute -= ts.Time.Hour * HOUR_MINUTES;

            ts.Time.Minute = minute;

            return ts;
        }

        public Date CreateDate(int year = 1, int month = 1, int week = 1, int day = 1)
        {
            ValidateDate(year, month, week, day);

            return new Date(year, month, week, day);
        }

        public Date CreateDateFromDays(int day)
        {
            Date date = new Date();

            date.Year = day / YEAR_DAYS;
            day -= date.Year * YEAR_DAYS;

            date.Month = day / MONTH_DAYS;
            day -= date.Month * MONTH_DAYS;

            date.Week = day / WEEK_DAYS;
            day -= date.Week * WEEK_DAYS;

            date.Day = day;

            return date;
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

        public void SetDateTimestamp(Timestamp ts, Date date)
        {
            ValidateDate(date.Year, date.Month, date.Week, date.Day);

            ts.Date.Year = date.Year;
            ts.Date.Month = date.Month;
            ts.Date.Week = date.Week;
            ts.Date.Day = date.Day;
        }

        public void setTimeTimestamp(Timestamp ts, int hour, int minute)
        {
            ValidateTime(hour, minute);

            ts.Time.Hour = hour;
            ts.Time.Minute = minute;
        }

        #endregion Set

        #region New

        public Timestamp GetNextWeek(Timestamp ts)
        {
            Timestamp copy = CopyTimestamp(ts);

            copy.Date.Day = 1;
            copy.Date.Week += 1;
            if(copy.Date.Week > 4)
            {
                copy.Date.Month += 1;
                copy.Date.Week = 1;

                if(copy.Date.Month > 12)
                {
                    copy.Date.Year += 1;
                    copy.Date.Month = 1;
                }
            }

            return copy;
        }

        #endregion New

        #region Operation

        public void AddDay(Timestamp ts, int day = 1)
        {
            if(day <= 0)
                throw new ArgumentException("Day can not be negative");

            Date dateDay = CreateDateFromDays(day);

            ts.Date.Day += dateDay.Day;
            if(ts.Date.Day > 7)
            {
                dateDay.Week += 1;
                ts.Date.Day -= 7;
            }
            ts.Date.Week += dateDay.Week;
            if(ts.Date.Week > 4)
            {
                dateDay.Month += 1;
                ts.Date.Week -= 4;
            }
            ts.Date.Month += dateDay.Month;
            if(ts.Date.Month > 12)
            {
                dateDay.Year += 1;
                ts.Date.Month -= 12;
            }
            ts.Date.Year += dateDay.Year;
        }

        public void AddHour(Timestamp ts, int hour = 1)
        {
            if (hour <= 0)
                throw new ArgumentException("Hour can not be negative");

            Timestamp tsHour = CreateTimestampFromHours(hour);

            ts.Time.Hour += tsHour.Time.Hour;
            if(ts.Time.Hour > 23)
            {
                tsHour.Date.Day += 1;
                ts.Time.Hour -= 24;
            }
            ts.Date.Day += tsHour.Date.Day;
            if (ts.Date.Day > 7)
            {
                tsHour.Date.Week += 1;
                ts.Date.Day -= 7;
            }
            ts.Date.Week += tsHour.Date.Week;
            if (ts.Date.Week > 4)
            {
                tsHour.Date.Month += 1;
                ts.Date.Week -= 4;
            }
            ts.Date.Month += tsHour.Date.Month;
            if (ts.Date.Month > 12)
            {
                tsHour.Date.Year += 1;
                ts.Date.Month -= 12;
            }
            ts.Date.Year += tsHour.Date.Year;
        }
        
        public void AddMinute(Timestamp ts, int minute)
        {
            if (minute <= 0)
                throw new ArgumentException("Hour can not be negative");

            Timestamp tsMinute = CreateTimestampFromMinutes(minute);

            ts.Time.Minute += tsMinute.Time.Minute;
            if(ts.Time.Minute > 59)
            {
                tsMinute.Time.Hour += 1;
                ts.Time.Minute -= 60;
            }
            ts.Time.Hour += tsMinute.Time.Hour;
            if (ts.Time.Hour > 23)
            {
                tsMinute.Date.Day += 1;
                ts.Time.Hour -= 24;
            }
            ts.Date.Day += tsMinute.Date.Day;
            if (ts.Date.Day > 7)
            {
                tsMinute.Date.Week += 1;
                ts.Date.Day -= 7;
            }
            ts.Date.Week += tsMinute.Date.Week;
            if (ts.Date.Week > 4)
            {
                tsMinute.Date.Month += 1;
                ts.Date.Week -= 4;
            }
            ts.Date.Month += tsMinute.Date.Month;
            if (ts.Date.Month > 12)
            {
                tsMinute.Date.Year += 1;
                ts.Date.Month -= 12;
            }
            ts.Date.Year += tsMinute.Date.Year;
        }
        #endregion Operation


        private void ValidateDay(int day)
        {
            if (day <= 0 || day > 28)
                throw new ArgumentException("Day must be in range 1-28");
        }

        private void ValidateHour(int hour)
        {
            if (hour < 0 || hour > 23)
                throw new ArgumentException("Hour must be in range 0-23");
        }
        private void ValidateDate(int year, int month, int week, int day)
        {
            if (year <= 0)
                throw new ArgumentException("Year can not be negative");
            if (month <= 0 || month > 12)
                throw new ArgumentException("Month must be in range 1-12");
            if (week <= 0 || week > 4)
                throw new ArgumentException("Week must be in range 1-4");
            if (day <= 0 || day > 7)
                throw new ArgumentException("Day must be in range 1-7");
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
