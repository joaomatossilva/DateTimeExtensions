using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;


namespace DateTimeExtensions.Tests
{
    //https://camo.githubusercontent.com/314c51cdbdfdbcb3cb01766992f14ba4b7b23d40/68747470733a2f2f692e737461636b2e696d6775722e636f6d2f30633671302e706e67

    [TestFixture]
    class HelperMethodsTests
    {
        readonly DateTime dateBStart = new DateTime(2020, 3, 10);
        readonly DateTime dateBEnd = new DateTime(2020, 3, 20);

        readonly DateTime afterDateAStart = new DateTime(2020, 3, 1);
        readonly DateTime afterDateAEnd = new DateTime(2020, 3, 8);

        readonly DateTime startTouchingDateAStart = new DateTime(2020, 3, 1);
        readonly DateTime startTouchingDateAEnd = new DateTime(2020, 3, 10);

        readonly DateTime startInsideDateAStart = new DateTime(2020, 3, 1);
        readonly DateTime startInsideDateAEnd = new DateTime(2020, 3, 12);

        readonly DateTime insideStartTouchingDateAStart = new DateTime(2020, 3, 10);
        readonly DateTime insideStartTouchingDateAEnd = new DateTime(2020, 3, 24);

        readonly DateTime enclosingStartTouchingDateAStart = new DateTime(2020, 3, 10);
        readonly DateTime enclosingStartTouchingDateAEnd = new DateTime(2020, 3, 18);

        readonly DateTime enclosingDateAStart = new DateTime(2020, 3, 12);
        readonly DateTime enclosingDateAEnd = new DateTime(2020, 3, 14);

        readonly DateTime enclosingEndTouchingDateAStart = new DateTime(2020, 3, 14);
        readonly DateTime enclosingEndTouchingDateAEnd = new DateTime(2020, 3, 20);

        readonly DateTime exactMatchDateAStart = new DateTime(2020, 3, 10);
        readonly DateTime exactMatchDateAEnd = new DateTime(2020, 3, 20);

        readonly DateTime insideDateAStart = new DateTime(2020, 3, 8);
        readonly DateTime insideDateAEnd = new DateTime(2020, 3, 22);

        readonly DateTime insideEndTouchingDateAStart = new DateTime(2020, 3, 8);
        readonly DateTime insideEndTouchingDateAEnd = new DateTime(2020, 3, 20);

        readonly DateTime endInsideDateAStart = new DateTime(2020, 3, 18);
        readonly DateTime endInsideDateAEnd = new DateTime(2020, 3, 24);

        readonly DateTime endTouchingDateAStart = new DateTime(2020, 3, 20);
        readonly DateTime endTouchingDateAEnd = new DateTime(2020, 3, 24);

        readonly DateTime beforeDateAStart = new DateTime(2020, 3, 24);
        readonly DateTime beforeDateAEnd = new DateTime(2020, 3, 28);

        [Test]
        public void is_date_the_same()
        {
            Assert.IsFalse(DateTimeExtensions.HelperMethods.IsTheSame(afterDateAStart, afterDateAEnd, dateBStart, dateBEnd));
            Assert.IsFalse(DateTimeExtensions.HelperMethods.IsTheSame(startTouchingDateAStart, startTouchingDateAEnd, dateBStart, dateBEnd));
            Assert.IsFalse(DateTimeExtensions.HelperMethods.IsTheSame(startInsideDateAStart, startInsideDateAEnd, dateBStart, dateBEnd));
            Assert.IsFalse(DateTimeExtensions.HelperMethods.IsTheSame(insideStartTouchingDateAStart, insideStartTouchingDateAEnd, dateBStart, dateBEnd));
            Assert.IsFalse(DateTimeExtensions.HelperMethods.IsTheSame(enclosingStartTouchingDateAStart, enclosingStartTouchingDateAEnd, dateBStart, dateBEnd));
            Assert.IsFalse(DateTimeExtensions.HelperMethods.IsTheSame(enclosingDateAStart, enclosingDateAEnd, dateBStart, dateBEnd));
            Assert.IsFalse(DateTimeExtensions.HelperMethods.IsTheSame(enclosingEndTouchingDateAStart, enclosingEndTouchingDateAEnd, dateBStart, dateBEnd));
            Assert.IsTrue(DateTimeExtensions.HelperMethods.IsTheSame(exactMatchDateAStart, exactMatchDateAEnd, dateBStart, dateBEnd));
            Assert.IsFalse(DateTimeExtensions.HelperMethods.IsTheSame(insideDateAStart, insideDateAEnd, dateBStart, dateBEnd));
            Assert.IsFalse(DateTimeExtensions.HelperMethods.IsTheSame(insideEndTouchingDateAStart, insideEndTouchingDateAEnd, dateBStart, dateBEnd));
            Assert.IsFalse(DateTimeExtensions.HelperMethods.IsTheSame(endInsideDateAStart, endInsideDateAEnd, dateBStart, dateBEnd));
            Assert.IsFalse(DateTimeExtensions.HelperMethods.IsTheSame(endTouchingDateAStart, endTouchingDateAEnd, dateBStart, dateBEnd));
            Assert.IsFalse(DateTimeExtensions.HelperMethods.IsTheSame(beforeDateAStart, beforeDateAEnd, dateBStart, dateBEnd));
        }

        [Test]
        public void is_date_inside()
        {
            Assert.IsFalse(DateTimeExtensions.HelperMethods.IsInside(afterDateAStart, afterDateAEnd, dateBStart, dateBEnd));
            Assert.IsFalse(DateTimeExtensions.HelperMethods.IsInside(startTouchingDateAStart, startTouchingDateAEnd, dateBStart, dateBEnd));
            Assert.IsFalse(DateTimeExtensions.HelperMethods.IsInside(startInsideDateAStart, startInsideDateAEnd, dateBStart, dateBEnd));
            Assert.IsFalse(DateTimeExtensions.HelperMethods.IsInside(insideStartTouchingDateAStart, insideStartTouchingDateAEnd, dateBStart, dateBEnd));
            Assert.IsTrue(DateTimeExtensions.HelperMethods.IsInside(enclosingStartTouchingDateAStart, enclosingStartTouchingDateAEnd, dateBStart, dateBEnd));
            Assert.IsTrue(DateTimeExtensions.HelperMethods.IsInside(enclosingDateAStart, enclosingDateAEnd, dateBStart, dateBEnd));
            Assert.IsTrue(DateTimeExtensions.HelperMethods.IsInside(enclosingEndTouchingDateAStart, enclosingEndTouchingDateAEnd, dateBStart, dateBEnd));
            Assert.IsTrue(DateTimeExtensions.HelperMethods.IsInside(exactMatchDateAStart, exactMatchDateAEnd, dateBStart, dateBEnd));
            Assert.IsFalse(DateTimeExtensions.HelperMethods.IsInside(insideDateAStart, insideDateAEnd, dateBStart, dateBEnd));
            Assert.IsFalse(DateTimeExtensions.HelperMethods.IsInside(insideEndTouchingDateAStart, insideEndTouchingDateAEnd, dateBStart, dateBEnd));
            Assert.IsFalse(DateTimeExtensions.HelperMethods.IsInside(endInsideDateAStart, endInsideDateAEnd, dateBStart, dateBEnd));
            Assert.IsFalse(DateTimeExtensions.HelperMethods.IsInside(endTouchingDateAStart, endTouchingDateAEnd, dateBStart, dateBEnd));
            Assert.IsFalse(DateTimeExtensions.HelperMethods.IsInside(beforeDateAStart, beforeDateAEnd, dateBStart, dateBEnd));
        }

        [Test]
        public void is_date_overlapped()
        {
            Assert.IsFalse(DateTimeExtensions.HelperMethods.IsOverlapped(afterDateAStart, afterDateAEnd, dateBStart, dateBEnd));
            Assert.IsFalse(DateTimeExtensions.HelperMethods.IsOverlapped(startTouchingDateAStart, startTouchingDateAEnd, dateBStart, dateBEnd));
            Assert.IsTrue(DateTimeExtensions.HelperMethods.IsOverlapped(startInsideDateAStart, startInsideDateAEnd, dateBStart, dateBEnd));
            Assert.IsTrue(DateTimeExtensions.HelperMethods.IsOverlapped(insideStartTouchingDateAStart, insideStartTouchingDateAEnd, dateBStart, dateBEnd));
            Assert.IsTrue(DateTimeExtensions.HelperMethods.IsOverlapped(enclosingStartTouchingDateAStart, enclosingStartTouchingDateAEnd, dateBStart, dateBEnd));
            Assert.IsTrue(DateTimeExtensions.HelperMethods.IsOverlapped(enclosingDateAStart, enclosingDateAEnd, dateBStart, dateBEnd));
            Assert.IsTrue(DateTimeExtensions.HelperMethods.IsOverlapped(enclosingEndTouchingDateAStart, enclosingEndTouchingDateAEnd, dateBStart, dateBEnd));
            Assert.IsTrue(DateTimeExtensions.HelperMethods.IsOverlapped(exactMatchDateAStart, exactMatchDateAEnd, dateBStart, dateBEnd));
            Assert.IsTrue(DateTimeExtensions.HelperMethods.IsOverlapped(insideDateAStart, insideDateAEnd, dateBStart, dateBEnd));
            Assert.IsTrue(DateTimeExtensions.HelperMethods.IsOverlapped(insideEndTouchingDateAStart, insideEndTouchingDateAEnd, dateBStart, dateBEnd));
            Assert.IsTrue(DateTimeExtensions.HelperMethods.IsOverlapped(endInsideDateAStart, endInsideDateAEnd, dateBStart, dateBEnd));
            Assert.IsFalse(DateTimeExtensions.HelperMethods.IsOverlapped(endTouchingDateAStart, endTouchingDateAEnd, dateBStart, dateBEnd));
            Assert.IsFalse(DateTimeExtensions.HelperMethods.IsOverlapped(beforeDateAStart, beforeDateAEnd, dateBStart, dateBEnd));
        }

        [Test]
        public void is_date_intersected()
        {
            Assert.IsFalse(DateTimeExtensions.HelperMethods.IsIntersect(afterDateAStart, afterDateAEnd, dateBStart, dateBEnd));
            Assert.IsTrue(DateTimeExtensions.HelperMethods.IsIntersect(startTouchingDateAStart, startTouchingDateAEnd, dateBStart, dateBEnd));
            Assert.IsTrue(DateTimeExtensions.HelperMethods.IsIntersect(startInsideDateAStart, startInsideDateAEnd, dateBStart, dateBEnd));
            Assert.IsTrue(DateTimeExtensions.HelperMethods.IsIntersect(insideStartTouchingDateAStart, insideStartTouchingDateAEnd, dateBStart, dateBEnd));
            Assert.IsTrue(DateTimeExtensions.HelperMethods.IsIntersect(enclosingStartTouchingDateAStart, enclosingStartTouchingDateAEnd, dateBStart, dateBEnd));
            Assert.IsTrue(DateTimeExtensions.HelperMethods.IsIntersect(enclosingDateAStart, enclosingDateAEnd, dateBStart, dateBEnd));
            Assert.IsTrue(DateTimeExtensions.HelperMethods.IsIntersect(enclosingEndTouchingDateAStart, enclosingEndTouchingDateAEnd, dateBStart, dateBEnd));
            Assert.IsTrue(DateTimeExtensions.HelperMethods.IsIntersect(exactMatchDateAStart, exactMatchDateAEnd, dateBStart, dateBEnd));
            Assert.IsTrue(DateTimeExtensions.HelperMethods.IsIntersect(insideDateAStart, insideDateAEnd, dateBStart, dateBEnd));
            Assert.IsTrue(DateTimeExtensions.HelperMethods.IsIntersect(insideEndTouchingDateAStart, insideEndTouchingDateAEnd, dateBStart, dateBEnd));
            Assert.IsTrue(DateTimeExtensions.HelperMethods.IsIntersect(endInsideDateAStart, endInsideDateAEnd, dateBStart, dateBEnd));
            Assert.IsTrue(DateTimeExtensions.HelperMethods.IsIntersect(endTouchingDateAStart, endTouchingDateAEnd, dateBStart, dateBEnd));
            Assert.IsFalse(DateTimeExtensions.HelperMethods.IsIntersect(beforeDateAStart, beforeDateAEnd, dateBStart, dateBEnd));
        }
    }
}
