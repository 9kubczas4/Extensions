using Extensions;
using NUnit.Framework;
using System;

namespace ExtensionsTests
{
    [TestFixture]
    public class ObjectExtensionsTest
    {
        private const String instance = "test";     

        [TestCase(null, ExpectedResult = true, Description = "WHEN object is null THEN return true")]
        [TestCase(instance, ExpectedResult = false, Description = "WHEN object is not null THEN return false")]
        public bool IsNull_WhenCalled_ShouldReturnExpectedResult(object obj)
        {
            // act and assert
            return obj.IsNull();
        }

        [TestCase(null, ExpectedResult = false, Description = "WHEN object is null THEN return false")]
        [TestCase(instance, ExpectedResult = true, Description = "WHEN object is not null THEN return true")]
        public bool IsNotNull_WhenCalled_ShouldReturnExpectedResult(object obj)
        {
            // act and assert
            return obj.IsNotNull();
        }
    }
}
