using Extensions;
using NUnit.Framework;
using System;
using System.Collections;

namespace ExtensionsTests
{
    [TestFixture]
    public class DateTimeExtensionsTest
    {
        [Test, TestCaseSource(typeof(DateTimeFactoryClass), "IsBetweenTestCases")]
        public bool IsBetween_WhenCalled_ShouldReturnExpectedResult(DateTime date, DateTime min, DateTime max)
        {
            // act and assert
            return date.IsBetween(min, max);
        }

        [Test, TestCaseSource(typeof(DateTimeFactoryClass), "IsBeforeTestCases")]
        public bool IsBefore_WhenCalled_ShouldReturnExpectedResult(DateTime date, DateTime dateToCompare)
        {
            // act and assert
            return date.IsBefore(dateToCompare);
        }

        [Test, TestCaseSource(typeof(DateTimeFactoryClass), "IsAfterTestCases")]
        public bool IsAfter_WhenCalled_ShouldReturnExpectedResult(DateTime date, DateTime dateToCompare)
        {
            // act and assert
            return date.IsAfter(dateToCompare);
        }
    }

    public class DateTimeFactoryClass
    {
        private static DateTime _firstDate = new DateTime(2010, 7, 8);
        private static DateTime _secondDate = new DateTime(2011, 7, 8);
        private static DateTime _thirdDate = new DateTime(2012, 7, 8);

        public static IEnumerable IsBetweenTestCases
        {
            get
            {
                yield return new TestCaseData(_firstDate, _secondDate, _thirdDate).Returns(false);
                yield return new TestCaseData(_firstDate, _thirdDate, _secondDate).Returns(false);
                yield return new TestCaseData(_secondDate, _firstDate, _thirdDate).Returns(true);
                yield return new TestCaseData(_secondDate, _thirdDate, _firstDate).Returns(true);
                yield return new TestCaseData(_thirdDate, _firstDate, _secondDate).Returns(false);
                yield return new TestCaseData(_thirdDate, _secondDate, _firstDate).Returns(false);
            }
        }

        public static IEnumerable IsBeforeTestCases
        {
            get
            {
                yield return new TestCaseData(_firstDate, _secondDate).Returns(true);
                yield return new TestCaseData(_firstDate, _thirdDate).Returns(true);
                yield return new TestCaseData(_secondDate, _firstDate).Returns(false);
                yield return new TestCaseData(_secondDate, _thirdDate).Returns(true);
                yield return new TestCaseData(_thirdDate, _firstDate).Returns(false);
                yield return new TestCaseData(_thirdDate, _secondDate).Returns(false);
            }
        }

        public static IEnumerable IsAfterTestCases
        {
            get
            {
                yield return new TestCaseData(_firstDate, _secondDate).Returns(false);
                yield return new TestCaseData(_firstDate, _thirdDate).Returns(false);
                yield return new TestCaseData(_secondDate, _firstDate).Returns(true);
                yield return new TestCaseData(_secondDate, _thirdDate).Returns(false);
                yield return new TestCaseData(_thirdDate, _firstDate).Returns(true);
                yield return new TestCaseData(_thirdDate, _secondDate).Returns(true);
            }
        }
    }
}
