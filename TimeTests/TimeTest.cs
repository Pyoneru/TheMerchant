using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheMerchant.Controller.Time;
using System;

namespace TimeTests
{
    [TestClass]
    public class TimeTest
    {

        #region Constructors
        
        /// <summary>
        /// After instanced object, sets class field with given values.
        /// </summary>
        [TestMethod]
        public void CreateTimeTest()
        {
            // Prepare data
            int year = 1576;
            Time.Month month = (Time.Month)1;
            int day = 10;
            int hour = 10;
            int minute = 30;

            Time time = new Time(year, month, day, hour, minute);

            Assert.AreEqual(year, time.Year);
            Assert.AreEqual(month, time.Mth);
            Assert.AreEqual(day, time.Day);
            Assert.AreEqual(hour, time.Hour);
            Assert.AreEqual(minute, time.Minute);
        }

        /// <summary>
        /// If year has negative value, throw exception
        /// </summary>
        [TestMethod]
        public void CreateTimeNegativeYearArgTest()
        {
            // Prepare data
            int year = -12;
            Time.Month month = (Time.Month)1;
            int day = 10;
            int hour = 10;
            int minute = 30;

            Assert.ThrowsException<ArgumentException>(() =>
            {
                new Time(year, month, day, hour, minute);
            });

        }

        /// <summary>
        /// If Month has bad value, throw ArgumentException
        /// </summary>
        [TestMethod]
        public void CreateTimeBadMonthArgTest()
        {
            // Prepare data
            int year = -12;
            Time.Month month = (Time.Month)78;
            int day = 10;
            int hour = 10;
            int minute = 30;

            Assert.ThrowsException<ArgumentException>(() =>
            {
                new Time(year, month, day, hour, minute);
            });
        }
        
        /// <summary>
        /// Day can be between 1-30 value.
        /// </summary>
        [TestMethod]
        public void CreateTimeZeroDayTest()
        {
            // Prepare data
            int year = 1245;
            Time.Month month = (Time.Month)1;
            int day = 0;
            int hour = 10;
            int minute = 30;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                new Time(year, month, day, hour, minute);
            });
        }

        /// <summary>
        /// Object should instanced if hour arg is in 0-23 range
        /// </summary>
        [TestMethod]
        public void CreateTimeHourRangeTest()
        {
            // Prepare data
            int year = 1245;
            Time.Month month = (Time.Month)1;
            int day = 1;
            int hour = 0;
            int minute = 30;

            // Min value
            Time time = new Time(year, month, day, hour, minute);

            Assert.AreEqual(hour, time.Hour);

            // Max value
            hour = 23;
            time = new Time(year, month, day, hour, minute);

            Assert.AreEqual(hour, time.Hour);

            // Out range
            hour = 24;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                new Time(year, month, day, hour, minute);
            });

        }

        /// <summary>
        /// Object should instanced if minute arg is in 0-59 range
        /// </summary>
        [TestMethod]
        public void CreateTimeMinuteRangeTest()
        {
            // Prepare data
            int year = 1245;
            Time.Month month = (Time.Month)1;
            int day = 1;
            int hour = 0;
            int minute = 0;

            // Min value
            Time time = new Time(year, month, day, hour, minute);

            Assert.AreEqual(minute, time.Minute);

            // Max value
            minute = 59;

            time = new Time(year, month, day, hour, minute);

            Assert.AreEqual(minute, time.Minute);

            // Out range
            minute = 60;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                new Time(year, month, day, hour, minute);
            });
        }

        #endregion Constructors

        #region Methods

        #region AddMinute

        /// <summary>
        /// Check if AddMinute method work correct
        /// </summary>
        [TestMethod]
        public void AddMinuteTest()
        {
            int year = 1567;
            Time.Month month = (Time.Month)1;
            int day = 1;
            int hour = 12;
            int minute = 30;

            Time time = new Time(year, month, day, hour, minute);
            time.AddMinute(20);

            Assert.AreEqual(year, time.Year);
            Assert.AreEqual(month, time.Mth);
            Assert.AreEqual(day, time.Day);
            Assert.AreEqual(hour, time.Hour);
            Assert.AreEqual((minute + 20), time.Minute);
        }

        /// <summary>
        /// New hour after added minutes
        /// </summary>
        [TestMethod]
        public void AddMinuteNewHourTest()
        {
            int year = 1567;
            Time.Month month = (Time.Month)1;
            int day = 1;
            int hour = 12;
            int minute = 30;

            Time time = new Time(year, month, day, hour, minute);
            time.AddMinute(50);

            Assert.AreEqual(year, time.Year);
            Assert.AreEqual(month, time.Mth);
            Assert.AreEqual(day, time.Day);
            Assert.AreEqual(13, time.Hour);
            Assert.AreEqual(20, time.Minute);
        }

        /// <summary>
        /// New hour and the same minute time after added 2 hours(in minutes)
        /// </summary>
        [TestMethod]
        public void AddMinute120MinutesTest()
        {
            int year = 1567;
            Time.Month month = (Time.Month)1;
            int day = 1;
            int hour = 12;
            int minute = 30;

            Time time = new Time(year, month, day, hour, minute);
            time.AddMinute(120);

            Assert.AreEqual(year, time.Year);
            Assert.AreEqual(month, time.Mth);
            Assert.AreEqual(day, time.Day);
            Assert.AreEqual(14, time.Hour);
            Assert.AreEqual(minute, time.Minute);
        }

        /// <summary>
        /// In given arg is negative, throw excepetion
        /// </summary>
        [TestMethod]
        public void AddMinuteNegativeValueTest()
        {
            int year = 1567;
            Time.Month month = (Time.Month)1;
            int day = 1;
            int hour = 12;
            int minute = 30;

            Time time = new Time(year, month, day, hour, minute);

            Assert.ThrowsException<ArgumentException>(() => time.AddMinute(-10));
        }

        #endregion AddMinute

        #region AddHour

        /// <summary>
        /// Test AddHour method
        /// </summary>
        [TestMethod]
        public void AddHourTest()
        {

            int year = 1410;
            Time.Month month = (Time.Month)1;
            int day = 1;
            int hour = 12;
            int minute = 0;

            Time time = new Time(year, month, day, hour, minute);
            time.AddHour(5);

            Assert.AreEqual(year, time.Year);
            Assert.AreEqual(month, time.Mth);
            Assert.AreEqual(day, time.Day);
            Assert.AreEqual(hour+5, time.Hour);
            Assert.AreEqual(minute, time.Minute);
        }

        /// <summary>
        /// New day after added hour
        /// </summary>
        [TestMethod]
        public void AddHourNewDayTest()
        {
            int year = 1410;
            Time.Month month = (Time.Month)1;
            int day = 1;
            int hour = 12;
            int minute = 0;

            Time time = new Time(year, month, day, hour, minute);
            time.AddHour(24);

            Assert.AreEqual(year, time.Year);
            Assert.AreEqual(month, time.Mth);
            Assert.AreEqual(day+1, time.Day);
            Assert.AreEqual(hour, time.Hour);
            Assert.AreEqual(minute, time.Minute);
        }

        /// <summary>
        /// if given value is negative, throw ArgumentException
        /// </summary>
        [TestMethod]
        public void AddHourNegativeValueTest()
        {
            int year = 1410;
            Time.Month month = (Time.Month)1;
            int day = 1;
            int hour = 12;
            int minute = 0;

            Time time = new Time(year, month, day, hour, minute);
            Assert.ThrowsException<ArgumentException>(() => time.AddHour(-2));
        }

        /// <summary>
        /// New week after added 24*7 hours(seven days).
        /// </summary>
        [TestMethod]
        public void AddHourNewWeekTest()
        {
            int year = 1410;
            Time.Month month = (Time.Month)1;
            int day = 1;
            int hour = 12;
            int minute = 0;

            Time time = new Time(year, month, day, hour, minute);
            time.AddHour(24 * 7);

            Assert.AreEqual(year, time.Year);
            Assert.AreEqual(month, time.Mth);
            Assert.AreEqual(day + 7, time.Day);
            Assert.AreEqual(hour, time.Hour);
            Assert.AreEqual(minute, time.Minute);
        }

        #endregion AddHour

        #region AddDay

        /// <summary>
        /// Test AddDay method
        /// </summary>
        [TestMethod]
        public void AddDayTest()
        {
            int year = 1600;
            Time.Month month = (Time.Month)1;
            int day = 24;
            int hour = 12;
            int minute = 0;

            Time time = new Time(year, month, day, hour, minute);
            time.AddDay(2);

            Assert.AreEqual(year, time.Year);
            Assert.AreEqual(month, time.Mth);
            Assert.AreEqual(day + 2, time.Day);
            Assert.AreEqual(hour, time.Hour);
            Assert.AreEqual(minute, time.Minute);
        }

        /// <summary>
        /// Every month has 30 days.
        /// </summary>
        [TestMethod]
        public void AddDayNewMonthTest()
        {
            int year = 1600;
            Time.Month month = (Time.Month)1;
            int day = 24;
            int hour = 12;
            int minute = 0;

            Time time = new Time(year, month, day, hour, minute);
            time.AddDay(7);

            Time.Month nextMonth = (Time.Month)2;

            Assert.AreEqual(year, time.Year);
            Assert.AreEqual(nextMonth, time.Mth);
            Assert.AreEqual(1, time.Day);
            Assert.AreEqual(hour, time.Hour);
            Assert.AreEqual(minute, time.Minute);
        }

        /// <summary>
        /// If given value is negative, throw ArgumentException
        /// </summary>
        [TestMethod]
        public void AddNewDayNegativeValueTest()
        {
            int year = 1600;
            Time.Month month = (Time.Month)1;
            int day = 24;
            int hour = 12;
            int minute = 0;

            Time time = new Time(year, month, day, hour, minute);
            Assert.ThrowsException<ArgumentException>(() => time.AddDay(-1));
        }

        #endregion AddDay

        #endregion Methods
    }
}
