using Extensions;
using NUnit.Framework;
using System;
using System.Collections;

namespace ExtensionsTests
{
    [TestFixture]
    public class TypeExtensionsTest
    {
        [Test]
        public void CreateListOfType_WhenProvidedIsSimpleType_ShouldCreateNewList()
        {
            // arrange
            int i = 0;
            Type type = i.GetType();

            // act
            IList result = type.CreateListOfType();

            // assert
            Assert.IsNotInstanceOf(type, result);
        }

        [Test]
        public void CreateListOfType_WhenProvidedIsNotSimpleType_ShouldCreateNewList()
        {
            // arrange
            String str = "text";
            Type type = str.GetType();

            // act
            IList result = type.CreateListOfType();

            // assert
            Assert.IsNotInstanceOf(type, result);
        }
    }
}
