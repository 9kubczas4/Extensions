using Extensions;
using NUnit.Framework;
using System;

namespace ExtensionsTests
{
    [TestFixture]
    public class IntegerExtensionsTest
    {
        [TestCase(11, ExpectedResult = "th", Description = "WHEN provided number is 11 THEN return th")]
        [TestCase(12, ExpectedResult = "th", Description = "WHEN provided number is 12 THEN return th")]
        [TestCase(13, ExpectedResult = "th", Description = "WHEN provided number is 13 THEN return th")]
        [TestCase(24, ExpectedResult = "th", Description = "WHEN provided number is 24 THEN return th")]
        [TestCase(115, ExpectedResult = "th", Description = "WHEN provided number is 115 THEN return th")]
        [TestCase(216, ExpectedResult = "th", Description = "WHEN provided number is 216 THEN return th")]
        [TestCase(517, ExpectedResult = "th", Description = "WHEN provided number is 517 THEN return th")]
        [TestCase(718, ExpectedResult = "th", Description = "WHEN provided number is 718 THEN return th")]
        [TestCase(819, ExpectedResult = "th", Description = "WHEN provided number is 819 THEN return th")]
        [TestCase(1, ExpectedResult = "st", Description = "WHEN provided number is 1 THEN return st")]
        [TestCase(21, ExpectedResult = "st", Description = "WHEN provided number is 21 THEN return st")]
        [TestCase(121, ExpectedResult = "st", Description = "WHEN provided number is 121 THEN return st")]
        [TestCase(2, ExpectedResult = "nd", Description = "WHEN provided number is 2 THEN return nd")]
        [TestCase(22, ExpectedResult = "nd", Description = "WHEN provided number is 22 THEN return nd")]
        [TestCase(522, ExpectedResult = "nd", Description = "WHEN provided number is 522 THEN return nd")]
        [TestCase(3, ExpectedResult = "rd", Description = "WHEN provided number is 3 THEN return rd")]
        [TestCase(23, ExpectedResult = "rd", Description = "WHEN provided number is 23 THEN return rd")]
        [TestCase(123, ExpectedResult = "rd", Description = "WHEN provided number is 123 THEN return rd")]
        public string ToOccurrenceSuffix_WhenCalled_ShouldReturnExpectedResult(int number)
        {
            // act and assert
            return number.ToOccurrenceSuffix();
        }

        [TestCase(2, ExpectedResult = true, Description = "WHEN provided number is 2 THEN return true")]
        [TestCase(3, ExpectedResult = false, Description = "WHEN provided number is 3 THEN return false")]
        [TestCase(-2, ExpectedResult = true, Description = "WHEN provided number is -2 THEN return true")]
        [TestCase(-3, ExpectedResult = false, Description = "WHEN provided number is -3 THEN return false")]
        public bool IsPrime_WhenCalled_ShouldReturnExpectedResult(int number)
        {
            // act and assert
            return number.IsPrime();
        }

        [TestCase(0)]
        public void IsPrime_WhenProvidedNumberIsZero_ShouldThrowException(int number)
        {
            // act and assert
            Assert.Throws<InvalidOperationException>(() => number.IsPrime());
        }

        [TestCase(2, ExpectedResult = true, Description = "WHEN provided number is 2 THEN return true")]
        [TestCase(3, ExpectedResult = true, Description = "WHEN provided number is 3 THEN return true")]
        [TestCase(5, ExpectedResult = true, Description = "WHEN provided number is 5 THEN return true")]
        [TestCase(8, ExpectedResult = true, Description = "WHEN provided number is 8 THEN return true")]
        [TestCase(13, ExpectedResult = true, Description = "WHEN provided number is 13 THEN return true")]
        [TestCase(21, ExpectedResult = true, Description = "WHEN provided number is 21 THEN return true")]
        [TestCase(-2, ExpectedResult = false, Description = "WHEN provided number is -2 THEN return false")]
        [TestCase(-3, ExpectedResult = false, Description = "WHEN provided number is -3 THEN return false")]
        [TestCase(0, ExpectedResult = false, Description = "WHEN provided number is 0 THEN return false")]
        [TestCase(1, ExpectedResult = false, Description = "WHEN provided number is 1 THEN return false")]
        [TestCase(4, ExpectedResult = false, Description = "WHEN provided number is 4 THEN return false")]
        [TestCase(9, ExpectedResult = false, Description = "WHEN provided number is 9 THEN return false")]
        public bool IsFibonnacci_WhenCalled_ShouldReturnExpectedResult(int number)
        {
            // act and assert
            return number.IsFibonnacci();
        }

        [TestCase(0,-1,1, ExpectedResult = true, Description = "WHEN number is between min and max THEN return true")]
        [TestCase(-10, -11, -1, ExpectedResult = true, Description = "WHEN number is between min and max THEN return true")]
        [TestCase(10, 1, 11, ExpectedResult = true, Description = "WHEN number is between min and max THEN return true")]
        [TestCase(0, 1, 2, ExpectedResult = false, Description = "WHEN number is not between min and max THEN return false")]
        [TestCase(-10, -12, -11, ExpectedResult = false, Description = "WHEN number is not between min and max THEN return false")]
        [TestCase(10, 12, 14, ExpectedResult = false, Description = "WHEN number is not between min and max THEN return false")]
        public bool IsBetween_WhenCalled_ShouldReturnExpectedResult(int number, int min, int max)
        {
            // act and assert
            return number.IsBetween(min, max);
        }

        [TestCase(0, 1, -1)]
        [TestCase(10, 11, 1)]
        [TestCase(-10, -9, -11)]
        public void IsBetween_WhenMaxIsLessThanMin_ShouldReturnThrowException(int number, int min, int max)
        {
            // act and assert
            Assert.Throws<ArgumentException>(() => number.IsBetween(min, max));
        }
    }
}
