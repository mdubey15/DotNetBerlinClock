using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BerlinClock.Classes;
using System.Collections.Generic;
using System.Collections;

namespace BerlinClockTests
{
    [TestClass]
    public class BerlinClockTest
    {
       #region Ctor

        [DataSource("Constructor_Must_Succeed_DataSource")]
        public void Constructor_Must_Return_Expected(int hours, int minutes, int seconds, Time expected)
        {
            Assert.AreEqual(expected, new Time(hours, minutes, seconds));
        }

        private static IEnumerable<object[]> Constructor_Must_Succeed_DataSource()
        {
            yield return new object[] { /* hours: */ 0, /*  minutes: */ 0, /*  seconds: */ 0, /*  expected: */ new Time(0, 0, 0) };
            yield return new object[] { /* hours: */ 8, /*  minutes: */ 4, /*  seconds: */ 11, /* expected: */ new Time(8, 4, 11) };
            yield return new object[] { /* hours: */ 12, /* minutes: */ 0, /*  seconds: */ 0, /*  expected: */ new Time(12, 0, 0) };
            yield return new object[] { /* hours: */ 13, /* minutes: */ 15, /* seconds: */ 9, /*  expected: */ new Time(13, 15, 9) };
            yield return new object[] { /* hours: */ 17, /* minutes: */ 0, /*  seconds: */ 1, /*  expected: */ new Time(17, 0, 1) };
            yield return new object[] { /* hours: */ 18, /* minutes: */ 0, /*  seconds: */ 0, /*  expected: */ new Time(18, 0, 0) };
            yield return new object[] { /* hours: */ 24, /* minutes: */ 0, /*  seconds: */ 0, /*  expected: */ new Time(24, 0, 0) };
        }

        [DataSource("Constructor_Must_Fail_DataSource")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_Must_Throw_ArgumentOutOfRangeException(int hours, int minutes, int seconds)
        {
            Assert.Fail("Argument Out of Range", new Time(hours, minutes, seconds));
        }

        private static IEnumerable<int[]> Constructor_Must_Fail_DataSource()
        {
            yield return new[] { /* hours: */ -1, /* minutes: */ 0, /*  seconds: */ 0 };
            yield return new[] { /* hours: */ 25, /* minutes: */ 0, /*  seconds: */ 0 };
            yield return new[] { /* hours: */ 0, /*  minutes: */ -1, /* seconds: */ 0 };
            yield return new[] { /* hours: */ 0, /*  minutes: */ 60, /* seconds: */ 0 };
            yield return new[] { /* hours: */ 24, /* minutes: */ 1, /*  seconds: */ 0 };
            yield return new[] { /* hours: */ 0, /*  minutes: */ 0, /*  seconds: */ -1 };
            yield return new[] { /* hours: */ 0, /*  minutes: */ 0, /*  seconds: */ 60 };
            yield return new[] { /* hours: */ 24, /* minutes: */ 0, /*  seconds: */ 1 };
        }

        #endregion

        #region Operators

        [DataSource("Equals_DataSource")]
        public void Equals_Operator_Must_Return_True(Time x, Time y)
        {
            Assert.IsTrue(x == y);
        }

        [DataSource("NotEquals_DataSource")]
        public void NotEquals_Operator_Must_Return_IsTrue(Time x, Time y)
        {
            Assert.IsTrue(x != y);
        }

        [DataSource("LessThan_DataSource")]
        public void LessThan_Operator_Must_Return_IsTrue(Time x, Time y)
        {
            Assert.IsTrue(x < y);
        }

        [DataSource("LessThanOrEqual_DataSource")]
        public void LessThanOrEqual_Operator_Must_Return_IsTrue(Time x, Time y)
        {
            Assert.IsTrue(x <= y);
        }

        [DataSource("GreaterThan_DataSource")]
        public void GreaterThan_Operator_Must_Return_IsTrue(Time x, Time y)
        {
            Assert.IsTrue(x > y);
        }

        [DataSource("GreaterThanOrEqual_DataSource")]
        public void GreaterThanOrEqual_Operator_Must_Return_True(Time x, Time y)
        {
            Assert.IsTrue(x >= y);
        }

        private static IEnumerable<Time[]> Equals_DataSource()
        {
            yield return new[] { /* x: */ new Time(0, 0, 0), /*    y: */ new Time(0, 0, 0) };
            yield return new[] { /* x: */ new Time(0, 0, 1), /*    y: */ new Time(0, 0, 1) };
            yield return new[] { /* x: */ new Time(0, 1, 0), /*    y: */ new Time(0, 1, 0) };
            yield return new[] { /* x: */ new Time(1, 0, 0), /*    y: */ new Time(1, 0, 0) };
            yield return new[] { /* x: */ new Time(24, 0, 0), /*   y: */ new Time(24, 0, 0) };
            yield return new[] { /* x: */ new Time(23, 59, 59), /* y: */ new Time(23, 59, 59) };
            yield return new[] { /* x: */ new Time(23, 59, 0), /*  y: */ new Time(23, 59, 0) };
            yield return new[] { /* x: */ new Time(23, 0, 0), /*   y: */ new Time(23, 0, 0) };
            yield return new[] { /* x: */ default(Time), /*        y: */ Time.MinValue };
            yield return new[] { /* x: */ new Time(24, 0, 0), /*   y: */ Time.MaxValue };
        }


        private static IEnumerable<Time[]> NotEquals_DataSource()
        {
            yield return new[] { /* x: */ new Time(0, 0, 0), /*    y: */ new Time(0, 0, 1) };
            yield return new[] { /* x: */ new Time(0, 0, 1), /*    y: */ new Time(0, 0, 0) };
            yield return new[] { /* x: */ new Time(0, 1, 0), /*    y: */ new Time(0, 0, 59) };
            yield return new[] { /* x: */ new Time(1, 0, 0), /*    y: */ new Time(1, 0, 1) };
            yield return new[] { /* x: */ new Time(23, 59, 0), /*  y: */ new Time(23, 59, 1) };
            yield return new[] { /* x: */ new Time(23, 59, 59), /* y: */ new Time(23, 59, 58) };
            yield return new[] { /* x: */ new Time(23, 59, 0), /*  y: */ new Time(23, 58, 0) };
            yield return new[] { /* x: */ Time.MinValue, /*        y: */ Time.MaxValue };
        }

        private static IEnumerable<Time[]> LessThan_DataSource()
        {
            yield return new[] { /* x: */ new Time(0, 0, 0), /*    y: */ new Time(0, 0, 1) };
            yield return new[] { /* x: */ new Time(0, 0, 0), /*    y: */ new Time(0, 1, 0) };
            yield return new[] { /* x: */ new Time(0, 0, 0), /*    y: */ new Time(1, 0, 0) };
            yield return new[] { /* x: */ new Time(23, 59, 59), /* y: */ new Time(24, 0, 0) };
            yield return new[] { /* x: */ new Time(23, 59, 0), /*  y: */ new Time(23, 59, 1) };
            yield return new[] { /* x: */ new Time(23, 0, 0), /*   y: */ new Time(23, 0, 1) };
            yield return new[] { /* x: */ Time.MinValue, /*        y: */ new Time(0, 0, 1) };
            yield return new[] { /* x: */ new Time(23, 59, 59), /* y: */ Time.MaxValue };
        }

        private static IEnumerable<Time[]> LessThanOrEqual_DataSource()
        {
            yield return new[] { /* x: */ new Time(0, 0, 0), /*    y: */ new Time(0, 0, 1) };
            yield return new[] { /* x: */ new Time(0, 0, 0), /*    y: */ new Time(0, 1, 0) };
            yield return new[] { /* x: */ new Time(0, 0, 0), /*    y: */ new Time(1, 0, 0) };
            yield return new[] { /* x: */ new Time(23, 59, 59), /* y: */ new Time(24, 0, 0) };
            yield return new[] { /* x: */ new Time(23, 59, 0), /*  y: */ new Time(23, 59, 1) };
            yield return new[] { /* x: */ new Time(23, 0, 0), /*   y: */ new Time(23, 0, 1) };
            yield return new[] { /* x: */ Time.MinValue, /*        y: */ new Time(0, 0, 1) };
            yield return new[] { /* x: */ new Time(23, 59, 59), /* y: */ Time.MaxValue };
            //Equal To Data source
            yield return new[] { /* x: */ new Time(0, 0, 0), /*    y: */ new Time(0, 0, 0) };
            yield return new[] { /* x: */ new Time(0, 0, 1), /*    y: */ new Time(0, 0, 1) };
            yield return new[] { /* x: */ new Time(0, 1, 0), /*    y: */ new Time(0, 1, 0) };
            yield return new[] { /* x: */ new Time(1, 0, 0), /*    y: */ new Time(1, 0, 0) };
            yield return new[] { /* x: */ new Time(24, 0, 0), /*   y: */ new Time(24, 0, 0) };
            yield return new[] { /* x: */ new Time(23, 59, 59), /* y: */ new Time(23, 59, 59) };
            yield return new[] { /* x: */ new Time(23, 59, 0), /*  y: */ new Time(23, 59, 0) };
            yield return new[] { /* x: */ new Time(23, 0, 0), /*   y: */ new Time(23, 0, 0) };
            yield return new[] { /* x: */ default(Time), /*        y: */ Time.MinValue };
            yield return new[] { /* x: */ new Time(24, 0, 0), /*   y: */ Time.MaxValue };
        }

        private static IEnumerable<Time[]> GreaterThan_DataSource()
        {
            yield return new[] { /* x: */ new Time(0, 0, 1), /*   y: */ new Time(0, 0, 0) };
            yield return new[] { /* x: */ new Time(0, 1, 0), /*   y: */ new Time(0, 0, 0) };
            yield return new[] { /* x: */ new Time(1, 0, 0), /*   y: */ new Time(0, 0, 0) };
            yield return new[] { /* x: */ new Time(24, 0, 0), /*  y: */ new Time(23, 59, 59) };
            yield return new[] { /* x: */ new Time(23, 59, 1), /* y: */ new Time(23, 59, 0) };
            yield return new[] { /* x: */ new Time(23, 0, 1), /*  y: */ new Time(23, 0, 0) };
            yield return new[] { /* x: */ new Time(0, 0, 1), /*   y: */ Time.MinValue };
            yield return new[] { /* x: */ new Time(0, 0, 1), /*   y: */ default(Time) };
        }

        private static IEnumerable<Time[]> GreaterThanOrEqual_DataSource()
        {
            yield return new[] { /* x: */ new Time(0, 0, 1), /*   y: */ new Time(0, 0, 0) };
            yield return new[] { /* x: */ new Time(0, 1, 0), /*   y: */ new Time(0, 0, 0) };
            yield return new[] { /* x: */ new Time(1, 0, 0), /*   y: */ new Time(0, 0, 0) };
            yield return new[] { /* x: */ new Time(24, 0, 0), /*  y: */ new Time(23, 59, 59) };
            yield return new[] { /* x: */ new Time(23, 59, 1), /* y: */ new Time(23, 59, 0) };
            yield return new[] { /* x: */ new Time(23, 0, 1), /*  y: */ new Time(23, 0, 0) };
            yield return new[] { /* x: */ new Time(0, 0, 1), /*   y: */ Time.MinValue };
            yield return new[] { /* x: */ new Time(0, 0, 1), /*   y: */ default(Time) };
            //Equal To Data source
            yield return new[] { /* x: */ new Time(0, 0, 0), /*    y: */ new Time(0, 0, 0) };
            yield return new[] { /* x: */ new Time(0, 0, 1), /*    y: */ new Time(0, 0, 1) };
            yield return new[] { /* x: */ new Time(0, 1, 0), /*    y: */ new Time(0, 1, 0) };
            yield return new[] { /* x: */ new Time(1, 0, 0), /*    y: */ new Time(1, 0, 0) };
            yield return new[] { /* x: */ new Time(24, 0, 0), /*   y: */ new Time(24, 0, 0) };
            yield return new[] { /* x: */ new Time(23, 59, 59), /* y: */ new Time(23, 59, 59) };
            yield return new[] { /* x: */ new Time(23, 59, 0), /*  y: */ new Time(23, 59, 0) };
            yield return new[] { /* x: */ new Time(23, 0, 0), /*   y: */ new Time(23, 0, 0) };
            yield return new[] { /* x: */ default(Time), /*        y: */ Time.MinValue };
            yield return new[] { /* x: */ new Time(24, 0, 0), /*   y: */ Time.MaxValue };
        }
        #endregion


        #region IComparable

        [DataSource("CompareTo_DataSource")]
        public void IComparable_CompareTo_Must_Return_Expected(Time x, object y, int expected)
        {
            Assert.AreEqual(expected, ((IComparable)x).CompareTo(y));
        }

        private static IEnumerable<object[]> CompareTo_DataSource()
        {
            foreach (var item in LessThan_DataSource())
                yield return new object[] { /* x: */ item[0], /* y: */ item[1], /* expected: */ -1 };

            foreach (var item in Equals_DataSource())
                yield return new object[] { /* x: */ item[0], /* y: */ item[1], /* expected: */ 0 };

            foreach (var item in GreaterThan_DataSource())
                yield return new object[] { /* x: */ item[0], /* y: */ item[1], /* expected: */ 1 };
        }

        private static IEnumerable<object[]> A_Time_Instance_And_A_NonTime_Instance_DataSource()
        {
            yield return new object[] { /* x: */ new Time(0, 0, 0), /*    y: */ new object() };
            yield return new object[] { /* x: */ new Time(0, 0, 0), /*    y: */ "string value" };
            yield return new object[] { /* x: */ new Time(0, 0, 0), /*    y: */ new TimeSpan() };
            yield return new object[] { /* x: */ new Time(23, 59, 0), /*  y: */ Guid.Empty };
            yield return new object[] { /* x: */ new Time(23, 59, 59), /* y: */ 1 };
            yield return new object[] { /* x: */ new Time(23, 59, 59), /* y: */ DayOfWeek.Friday };
        }

        
        [DataSource("CompareTo_DataSource")]
        public void IComparable_Of_Time_CompareTo_Must_Return_Expected(Time x, Time y, int expected)
        {
            Assert.AreEqual(expected, ((IComparable<Time>)x).CompareTo(y));
        }

        #endregion

        #region IEquatable

        [DataSource("Equals_DataSource")]
        public void IEquatable_Of_Time_Equals_Must_Return_True(Time x, Time y)
        {
            Assert.IsTrue(((IEquatable<Time>)x).Equals(y));
        }

        [DataSource("NotEquals_DataSource")]
        public void IEquatable_Of_Time_Equals_Must_Return_False(Time x, Time y)
        {
            Assert.IsFalse(((IEquatable<Time>)x).Equals(y));
        }

        #endregion

        #region Overrides

        [DataSource("Equals_DataSource")]
        public void Equals_Must_Return_True(Time x, object y)
        {
            Assert.IsTrue(x.Equals(y));
        }


        [DataSource("NotEquals_DataSource")]
        public void Equals_Must_Return_False(Time x, object y)
        {
            Assert.IsFalse(x.Equals(y));
        }

        [DataSource("A_Time_Instance_And_A_NonTime_Instance_DataSource")]
        public void Equals_Must_Return_False_When_Argument_Is_Not_A_Time_Instance(Time x, object y)
        {
            Assert.IsFalse(x.Equals(y));
        }


        [TestMethod]
        public void When_Argument_Is_Null_Return_False()
        {
            Assert.IsFalse(new Time(15, 10, 8).Equals(null));
        }

        [TestMethod]
        public void GetHashCode_Must_Be_Unique()
        {
            var expectedDictionaryCount = (24 * 60 * 60) + 1;
            var dictionary = new Dictionary<Time, string>(expectedDictionaryCount);

            for (int hours = 0; hours < 24; hours++)
                for (int minutes = 0; minutes < 60; minutes++)
                    for (int seconds = 0; seconds < 60; seconds++)
                        dictionary.Add(new Time(hours, minutes, seconds), "{hours}:{minutes}:{seconds}");
            dictionary.Add(Time.MaxValue, "24:0:0");
            // Adding all possible Times to check for HashCode duplicates

            Assert.AreEqual(expectedDictionaryCount, dictionary.Count);

            for (int hours = 0; hours < 24; hours++)
                for (int minutes = 0; minutes < 60; minutes++)
                    for (int seconds = 0; seconds < 60; seconds++)
                        Assert.AreEqual("{hours}:{minutes}:{seconds}", dictionary[new Time(hours, minutes, seconds)]);
            Assert.AreEqual("24:0:0", dictionary[Time.MaxValue]);
            // Checking that all values added are reachable
        }

        [DataSource("Random_Valid_Times_DataSource")]
        public void ToString_Must_Return_Formatted_Hours_Minutes_Seconds(Time time)
        {
            Assert.AreEqual("{time.Hours:00}:{time.Minutes:00}:{time.Seconds:00}", time.ToString());
        }

        private static IEnumerable<Time> Random_Valid_Times_DataSource()
        {
            yield return Time.MinValue;
            var random = new Random(Guid.NewGuid().GetHashCode());

            for (var i = 0; i < 10; i++)
                yield return new Time(random.Next(0, 24), random.Next(0, 60), random.Next(0, 60));
            yield return Time.MaxValue;
        }

        #endregion

        #region Parse

        [DataSource("Parse_Must_Succeed_DataSource")]
        public void Parse_Must_Return_Expected(string time, Time expected)
        {
            Assert.AreEqual(expected, Time.Parse(time));
        }


        private static IEnumerable<object[]> Parse_Must_Succeed_DataSource()
        {
            yield return new object[] { "00:00:00", new Time(0, 0, 0) };
            yield return new object[] { "08:04:11", new Time(8, 4, 11) };
            yield return new object[] { "12:00:00", new Time(12, 0, 0) };
            yield return new object[] { "13:15:09", new Time(13, 15, 9) };
            yield return new object[] { "17:00:01", new Time(17, 0, 1) };
            yield return new object[] { "18:00:00", new Time(18, 0, 0) };
            yield return new object[] { "24:00:00", new Time(24, 0, 0) };
        }

        [DataSource("Parse_Must_Fail_DataSource")]
        public void Parse_Must_Throw_ArgumentException_When_Argument_Is_Not_Valid(string time)
        {
            Assert.IsNull(Time.Parse(time),"Argument is not valid");
        }


        private static IEnumerable<string> Parse_Must_Fail_DataSource()
        {
            yield return "";
            yield return " ";
            yield return "asdf";
            yield return "11";
            yield return "11:AA:00";
        }


        [TestMethod]
        public void Parse_Must_Throw_ArgumentNullException_When_Argument_Is_Null()
        {
            Assert.IsNull(Time.Parse(null),"Argument is null");
        }
        #endregion

    }
}
