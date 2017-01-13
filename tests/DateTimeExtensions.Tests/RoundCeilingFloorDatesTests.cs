using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace DateTimeExtensions.Tests
{
    [TestFixture]
    public class RoundCeilingFloorDatesTests
    {
        private static readonly DateTime TestDate = DateTime.Today
            .SetTime(2, 23, 41);

        [Test]
        public void seconds_round_down_test()
        {
            var roundDate = TestDate.Round(new TimeSpan(0, 0, 20)); //round 41 in periods of 20
            Assert.AreEqual(DateTime.Today.SetTime(2, 23, 40), roundDate);
        }

        [Test]
        public void seconds_round_up_test()
        {
            var roundDate = TestDate.Round(new TimeSpan(0, 0, 15)); //round 41 in periods of 15
            Assert.AreEqual(DateTime.Today.SetTime(2, 23, 45), roundDate);
        }

        [Test]
        public void minutes_round_down_test()
        {
            var roundDate = TestDate.Round(new TimeSpan(0, 10, 0)); //round 23 in periods of 10
            Assert.AreEqual(DateTime.Today.SetTime(2, 20, 0), roundDate);
        }

        [Test]
        public void minutes_round_up_test()
        {
            var roundDate = TestDate.Round(new TimeSpan(0, 15, 0)); //round 23 in periods of 15
            Assert.AreEqual(DateTime.Today.SetTime(2, 30, 0), roundDate);
        }

        [Test]
        public void hours_round_down_test()
        {
            var roundDate = TestDate.Round(new TimeSpan(6, 0, 0)); //round 2 in periods of 5
            Assert.AreEqual(DateTime.Today.SetTime(0, 0, 0), roundDate);
        }

        [Test]
        public void hours_round_up_test()
        {
            var roundDate = TestDate.Round(new TimeSpan(3, 0, 0)); //round 2 in periods of 3
            Assert.AreEqual(DateTime.Today.SetTime(3, 0, 0), roundDate);
        }


        [Test]
        public void seconds_ceiling_test()
        {
            var roundDate = TestDate.Ceiling(new TimeSpan(0, 0, 20)); //ceiling 41 in periods of 20
            Assert.AreEqual(DateTime.Today.SetTime(2, 24, 0), roundDate);
        }

        [Test]
        public void minutes_ceiling_test()
        {
            var roundDate = TestDate.Ceiling(new TimeSpan(0, 10, 0)); //ceiling 23 in periods of 10
            Assert.AreEqual(DateTime.Today.SetTime(2, 30, 0), roundDate);
        }

        [Test]
        public void hours_ceiling_test()
        {
            var roundDate = TestDate.Ceiling(new TimeSpan(4, 0, 0)); //ceiling 2 in periods of 4
            Assert.AreEqual(DateTime.Today.SetTime(4, 0, 0), roundDate);
        }


        [Test]
        public void seconds_floor_test()
        {
            var roundDate = TestDate.Floor(new TimeSpan(0, 0, 15)); //floor 41 in periods of 15
            Assert.AreEqual(DateTime.Today.SetTime(2, 23, 30), roundDate);
        }

        [Test]
        public void minutes_floor_test()
        {
            var roundDate = TestDate.Floor(new TimeSpan(0, 15, 0)); //floor 23 in periods of 15
            Assert.AreEqual(DateTime.Today.SetTime(2, 15, 0), roundDate);
        }

        [Test]
        public void hours_floor_test()
        {
            var roundDate = TestDate.Floor(new TimeSpan(3, 0, 0)); //floor 2 in periods of 3
            Assert.AreEqual(DateTime.Today.SetTime(0, 0, 0), roundDate);
        }
    }
}