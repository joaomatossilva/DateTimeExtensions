using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;


namespace DateTimeExtensions.Tests
{
    //https://camo.githubusercontent.com/314c51cdbdfdbcb3cb01766992f14ba4b7b23d40/68747470733a2f2f692e737461636b2e696d6775722e636f6d2f30633671302e706e67

    [TestFixture]
    class DatePeriodsComparingTests
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
        public void is_the_same_as()
        {
            Assert.IsFalse(afterDateAStart.IsTheSameAs(afterDateAEnd, dateBStart, dateBEnd));
            Assert.IsFalse(startTouchingDateAStart.IsTheSameAs(startTouchingDateAEnd, dateBStart, dateBEnd));
            Assert.IsFalse(startInsideDateAStart.IsTheSameAs(startInsideDateAEnd, dateBStart, dateBEnd));
            Assert.IsFalse(insideStartTouchingDateAStart.IsTheSameAs(insideStartTouchingDateAEnd, dateBStart, dateBEnd));
            Assert.IsFalse(enclosingStartTouchingDateAStart.IsTheSameAs(enclosingStartTouchingDateAEnd, dateBStart, dateBEnd));
            Assert.IsFalse(enclosingDateAStart.IsTheSameAs(enclosingDateAEnd, dateBStart, dateBEnd));
            Assert.IsFalse(enclosingEndTouchingDateAStart.IsTheSameAs(enclosingEndTouchingDateAEnd, dateBStart, dateBEnd));
            Assert.IsTrue(exactMatchDateAStart.IsTheSameAs(exactMatchDateAEnd, dateBStart, dateBEnd));
            Assert.IsFalse(insideDateAStart.IsTheSameAs(insideDateAEnd, dateBStart, dateBEnd));
            Assert.IsFalse(insideEndTouchingDateAStart.IsTheSameAs(insideEndTouchingDateAEnd, dateBStart, dateBEnd));
            Assert.IsFalse(endInsideDateAStart.IsTheSameAs(endInsideDateAEnd, dateBStart, dateBEnd));
            Assert.IsFalse(endTouchingDateAStart.IsTheSameAs(endTouchingDateAEnd, dateBStart, dateBEnd));
            Assert.IsFalse(beforeDateAStart.IsTheSameAs(beforeDateAEnd, dateBStart, dateBEnd));
        }

        [Test]
        public void is_inside_in()
        {
            Assert.IsFalse(afterDateAStart.IsInsideIn(afterDateAEnd, dateBStart, dateBEnd));
            Assert.IsFalse(startTouchingDateAStart.IsInsideIn(startTouchingDateAEnd, dateBStart, dateBEnd));
            Assert.IsFalse(startInsideDateAStart.IsInsideIn(startInsideDateAEnd, dateBStart, dateBEnd));
            Assert.IsFalse(insideStartTouchingDateAStart.IsInsideIn(insideStartTouchingDateAEnd, dateBStart, dateBEnd));
            Assert.IsTrue(enclosingStartTouchingDateAStart.IsInsideIn(enclosingStartTouchingDateAEnd, dateBStart, dateBEnd));
            Assert.IsTrue(enclosingDateAStart.IsInsideIn(enclosingDateAEnd, dateBStart, dateBEnd));
            Assert.IsTrue(enclosingEndTouchingDateAStart.IsInsideIn(enclosingEndTouchingDateAEnd, dateBStart, dateBEnd));
            Assert.IsTrue(exactMatchDateAStart.IsInsideIn(exactMatchDateAEnd, dateBStart, dateBEnd));
            Assert.IsFalse(insideDateAStart.IsInsideIn(insideDateAEnd, dateBStart, dateBEnd));
            Assert.IsFalse(insideEndTouchingDateAStart.IsInsideIn(insideEndTouchingDateAEnd, dateBStart, dateBEnd));
            Assert.IsFalse(endInsideDateAStart.IsInsideIn(endInsideDateAEnd, dateBStart, dateBEnd));
            Assert.IsFalse(endTouchingDateAStart.IsInsideIn(endTouchingDateAEnd, dateBStart, dateBEnd));
            Assert.IsFalse(beforeDateAStart.IsInsideIn(beforeDateAEnd, dateBStart, dateBEnd));
        }

        [Test]
        public void is_overlapped_with()
        {
            Assert.IsFalse(afterDateAStart.IsOverlappedWith(afterDateAEnd, dateBStart, dateBEnd));
            Assert.IsFalse(startTouchingDateAStart.IsOverlappedWith(startTouchingDateAEnd, dateBStart, dateBEnd));
            Assert.IsTrue(startInsideDateAStart.IsOverlappedWith(startInsideDateAEnd, dateBStart, dateBEnd));
            Assert.IsTrue(insideStartTouchingDateAStart.IsOverlappedWith(insideStartTouchingDateAEnd, dateBStart, dateBEnd));
            Assert.IsTrue(enclosingStartTouchingDateAStart.IsOverlappedWith(enclosingStartTouchingDateAEnd, dateBStart, dateBEnd));
            Assert.IsTrue(enclosingDateAStart.IsOverlappedWith(enclosingDateAEnd, dateBStart, dateBEnd));
            Assert.IsTrue(enclosingEndTouchingDateAStart.IsOverlappedWith(enclosingEndTouchingDateAEnd, dateBStart, dateBEnd));
            Assert.IsTrue(exactMatchDateAStart.IsOverlappedWith(exactMatchDateAEnd, dateBStart, dateBEnd));
            Assert.IsTrue(insideDateAStart.IsOverlappedWith(insideDateAEnd, dateBStart, dateBEnd));
            Assert.IsTrue(insideEndTouchingDateAStart.IsOverlappedWith(insideEndTouchingDateAEnd, dateBStart, dateBEnd));
            Assert.IsTrue(endInsideDateAStart.IsOverlappedWith(endInsideDateAEnd, dateBStart, dateBEnd));
            Assert.IsFalse(endTouchingDateAStart.IsOverlappedWith(endTouchingDateAEnd, dateBStart, dateBEnd));
            Assert.IsFalse(beforeDateAStart.IsOverlappedWith(beforeDateAEnd, dateBStart, dateBEnd));
        }

        [Test]
        public void is_intersect_with()
        {
            Assert.IsFalse(afterDateAStart.IsIntersectWith(afterDateAEnd, dateBStart, dateBEnd));
            Assert.IsTrue(startTouchingDateAStart.IsIntersectWith(startTouchingDateAEnd, dateBStart, dateBEnd));
            Assert.IsTrue(startInsideDateAStart.IsIntersectWith(startInsideDateAEnd, dateBStart, dateBEnd));
            Assert.IsTrue(insideStartTouchingDateAStart.IsIntersectWith(insideStartTouchingDateAEnd, dateBStart, dateBEnd));
            Assert.IsTrue(enclosingStartTouchingDateAStart.IsIntersectWith(enclosingStartTouchingDateAEnd, dateBStart, dateBEnd));
            Assert.IsTrue(enclosingDateAStart.IsIntersectWith(enclosingDateAEnd, dateBStart, dateBEnd));
            Assert.IsTrue(enclosingEndTouchingDateAStart.IsIntersectWith(enclosingEndTouchingDateAEnd, dateBStart, dateBEnd));
            Assert.IsTrue(exactMatchDateAStart.IsIntersectWith(exactMatchDateAEnd, dateBStart, dateBEnd));
            Assert.IsTrue(insideDateAStart.IsIntersectWith(insideDateAEnd, dateBStart, dateBEnd));
            Assert.IsTrue(insideEndTouchingDateAStart.IsIntersectWith(insideEndTouchingDateAEnd, dateBStart, dateBEnd));
            Assert.IsTrue(endInsideDateAStart.IsIntersectWith(endInsideDateAEnd, dateBStart, dateBEnd));
            Assert.IsTrue(endTouchingDateAStart.IsIntersectWith(endTouchingDateAEnd, dateBStart, dateBEnd));
            Assert.IsFalse(beforeDateAStart.IsIntersectWith(beforeDateAEnd, dateBStart, dateBEnd));
        }
    }
}
