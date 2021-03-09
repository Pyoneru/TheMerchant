using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheMerchant.Service;
using TheMerchant.Model;

namespace TimeTests
{
    
    [TestClass]
    public class TimestampServiceTest
    {
        private TimestampService service;

        public TimestampServiceTest()
        {
            this.service = new TimestampService();
        }

        [TestMethod]
        public void AddDayToTimestamp()
        {
            Timestamp ts = service.CreateTimestamp();

            service.AddDay(ts);

            int newDay = ts.Date.Day;

            Assert.AreEqual(2, newDay);
        }

        [TestMethod]
        public void AddWeekInDaysToTimestamp()
        {
            Timestamp ts = service.CreateTimestamp();

            service.AddDay(ts, 7);

            int newWeek = ts.Date.Week;

            Assert.AreEqual(2, newWeek);
        }

        [TestMethod]
        public void AddDayWithNegativeValueToTimestampShouldThrowException()
        {
            Timestamp ts = service.CreateTimestamp();

            Assert.ThrowsException<ArgumentException>(() =>
            {
                service.AddDay(ts, -1);
            });
        }

        [TestMethod]
        public void AddHourToTimestamp()
        {
            Timestamp ts = service.CreateTimestamp();

            service.AddHour(ts);

            int newHour = ts.Time.Hour;

            Assert.AreEqual(13, newHour);
        }

        [TestMethod]
        public void Add25HoursToTimestamp()
        {
            Timestamp ts = service.CreateTimestamp();

            service.AddHour(ts, 25);

            int newDay = ts.Date.Day;
            int newHour = ts.Time.Hour;

            Assert.AreEqual(2, newDay);
            Assert.AreEqual(13, newHour);
        }

        [TestMethod]
        public void AddHourWithNegativeValueToTimestampShouldThrowException()
        {
            Timestamp ts = service.CreateTimestamp();

            Assert.ThrowsException<ArgumentException>(() =>
            {
                service.addHour(-1);
            });
        }

        [TestMethod]
        public void AddQuarterToTimestamp()
        {
            Timestamp ts = service.CreateTimestamp();

            service.AddMinute(ts, 15);

            int newMinute = ts.Time.Minute;

            Assert.AreEqual(15, newMinute);
        }

        [TestMethod]
        public void Add90MinutesToTimestamp()
        {
            Timestamp ts = service.CreateTimestamp();

            service.AddMinute(ts, 90);

            int newHour = ts.Time.Hour;
            int newMinute = ts.Time.Minute;

            Assert.AreEqual(13, newHour);
            Assert.AreEqual(30, newMinute);
        }

        [TestMethod]
        public void AddMinuteWithNegativeValueToTimestampShouldThrowException()
        {
            Timestamp ts = service.CreateTimestamp();

            Assert.ThrowsException<ArgumentException>(() =>
            {
                ts.AddMinute(-1);
            });
        }


        [TestMethod]
        public void GetNextWeekFromTimestamp()
        {
            Timestamp ts = service.CreateTimestamp();
            ts.Date.Day = 3;

            Timestamp nextWeek = service.GetNextWeek(ts);

            int newWeek = nextWeek.Date.Week;
            int newDay = nextWeek.Date.Day;

            Assert.AreEqual(2, newWeek);
            Assert.AreEqual(1, newWeek);
        }
    }
}
