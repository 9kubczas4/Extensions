using Extensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtensionsTests
{
    [TestFixture]
    public class ListExtensionsTest
    {
        [Test]
        public void Shuffle_WhenListIsNotEmpty_ShouldReturnShuffeledList()
        {
            // arrange
            var emptyList = new List<String>();

            // act
            emptyList.Shuffle();

            // assert
            Assert.AreEqual(0, emptyList.Count());
        }

        [Test]
        public void Shuffle_WhenListIsEmpty_ShouldReturnEmptyList()
        {
            // arrange
            var list = new List<String>();
            var cloneList = list.Clone();

            // act
            list.Shuffle();

            // assert
            Assert.AreEqual(true, list.AreTheSame(cloneList));
        }

        [Test]
        public void Shuffle_WhenListContainsSingleElement_ShouldReturnTheSameList()
        {
            // arrange
            var list = new List<String>() { "a" };
            var cloneList = list.Clone();

            // act
            list.Shuffle();

            // assert
            Assert.AreEqual(1, list.Count());
        }

        [Test]
        public void Shuffle_WhenListIsNull_ShouldThrowException()
        {
            // arrange
            List<String> nullList = null;

            // act and assert
            Assert.Throws<ArgumentNullException>(() => nullList.Shuffle());
        }

        [TestCase(1, 4, Description = "WHEN both values exists in list THEN objects should be swaped in list")]
        [TestCase(4, 2, Description = "WHEN both values exists in list THEN objects should be swaped in list")]
        [TestCase(2, 2, Description = "WHEN both values exists in list THEN objects should be swaped in list")]
        public void Swap_WhenElementsExistInList_ShouldSwapObjectsInList(int first, int second)
        {
            // arrange
            List<int> list = new List<int>() { 1, 2, 3, 4, 5 };
            var firstIndex = list.FindIndex(x => x == first);
            var secondIndex = list.FindIndex(x => x == second);
            Dictionary<int, int> notAffectedItems = new Dictionary<int, int>();
            for (int i = 0; i < list.Count(); i++)
            {
                if (i != firstIndex && i != secondIndex)
                {
                    notAffectedItems.Add(i, list.ElementAt(i));
                }
            }


            // act 
            list.Swap<int>(first, second);

            // assert
            Assert.AreEqual(second, list.ElementAt(firstIndex));
            Assert.AreEqual(first, list.ElementAt(secondIndex));
            foreach(int index in notAffectedItems.Keys)
            {
                Assert.AreEqual(notAffectedItems[index], list.ElementAt(index));
            }
        }

        [TestCase(1,6, Description = "WHEN second value doesnt exist in list THEN excpetion should be thrown")]
        [TestCase(6,1, Description = "WHEN first value doesnt exist in list THEN excpetion should be thrown")]
        [TestCase(0,6, Description = "WHEN both values dont exist in list THEN excpetion should be thrown")]
        public void Swap_WhenAtLeastOneElementDoesntExist_ShouldThrowException(int first, int second)
        {
            // arrange
            List<int> list = new List<int>() { 1, 2, 3, 4, 5 };

            // act and assert
            Assert.Throws<ArgumentOutOfRangeException>(() => list.Swap<int>(first, second));
        }

        [TestCase(ExpectedResult = true)]
        public bool AreTheSame_WhenListsContainTheSameOrderOfItems_ShouldReturnTrue()
        {
            // arrange
            List<String> first = new List<String>() { "a", "b", "c" };
            List<String> second = first.Clone().ToList();

            // act and assert
            return first.AreTheSame(second);
        }

        [TestCase(ExpectedResult = false)]
        public bool AreTheSame_WhenFirstListDoNotContainTheSameOrderOfItems_ShouldReturnFalse()
        {
            // arrange
            List<String> first = new List<String>() { "a", "b", "c" };
            List<String> second = first.Clone().ToList().Swap(first.First(), first.Last());

            // act and assert
            return first.AreTheSame(second);
        }

        [TestCase(ExpectedResult = false)]
        public bool AreTheSame_WhenSecondListDoNotContainTheSameOrderOfItems_ShouldReturnFalse()
        {
            // arrange
            List<String> first = new List<String>() { "a", "b", "c" };
            List<String> second = first.Clone().ToList().Swap(first.First(), first.Last());

            // act and assert
            return second.AreTheSame(first);
        }

        [Test]
        public void AreTheSame_WhenFirstListIsNull_ShouldThrowException()
        {
            // arrange
            List<string> first = null;
            List<String> second = new List<String>() { "a", "b", "c" };

            // act and assert
            Assert.Throws<ArgumentNullException>(() => first.AreTheSame(second));
        }

        [TestCase(ExpectedResult = false)]
        public bool AreTheSame_WhenSecondListIsNull_ShouldReturnFalse()
        {
            // arrange
            List<String> first = new List<String>() { "a", "b", "c" };
            List<String> second = null;

            // act and assert
            return first.AreTheSame(second);
        }

        [Test]
        public void Clone_WhenListIsNull_ShouldThrowException()
        {
            // arrange
            List<String> list = null;

            // act and assert
            Assert.Throws<ArgumentNullException>(() => list.Clone());
        }

        [Test]
        public void Clone_WhenListIsEmpty_ShouldCloneEmptyList()
        {
            // arrange
            List<String> list = new List<String>();

            // act
            var clonedList = list.Clone();

            // assert
            Assert.AreEqual(false, list == clonedList);
        }

        [Test]
        public void Clone_WhenListIsNotEmpty_ShouldCloneObjectInsideList()
        {
            // arrange
            List<MockData> list = new List<MockData>() { new MockData(), new MockData(), new MockData() };

            // act
            var clonedList = list.Clone();

            // assert
            for (int i = 0; i < list.Count; i++)
            {
                Assert.AreEqual(false, list[i] == clonedList[i]);
            }
        }

        private class MockData : ICloneable
        {
            public object Clone()
            {
                return this.MemberwiseClone();
            }
        }
    }
}
