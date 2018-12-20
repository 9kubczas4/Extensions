using Extensions;
using FizzWare.NBuilder;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtensionsTests
{
    [TestFixture]
    public class EnumerableExtensionsTest
    {
        [Test]
        public void FlattenHierarchy_WhenThereIsOnlyOneNode_ShouldReturnCollectionContainsOneNode()
        {
            // arrange
            var node = Builder<Node>.CreateNew()
                .With(x => x.Parent = null)
                .With(x => x.Childrens = null)
                .Build();

            // act
            var result = node.FlattenHierarchy((x) => { return x.Childrens; });

            // assert
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(node, result.First());
        }

        [Test]
        public void FlattenHierarchy_WhenThereIsOnlyOneNodeWithThreeChildrens_ShouldReturnCollectionContainsFourNode()
        {
            // arrange
            var node = Builder<Node>.CreateNew()
                .With(x => x.Parent = null)
                .With(x => x.Childrens = Builder<Node>.CreateListOfSize(3)
                    .All()
                        .With(y => y.Parent = x)
                        .With(y => y.Childrens = null)
                    .Build().ToList())
                .Build();

            // act
            var result = node.FlattenHierarchy((x) => { return x.Childrens; }).ToList();

            // assert
            Assert.AreEqual(4, result.Count());
            Assert.Contains(node, result);
            Assert.Contains(node.Childrens.ElementAt(0), result);
            Assert.Contains(node.Childrens.ElementAt(1), result);
            Assert.Contains(node.Childrens.ElementAt(2), result);
        }

        [Test]
        public void FlattenHierarchy_WhenNodeIsNull_ShouldThrowException()
        {
            // arrange
            Node node = null;

            // act and assert
            Assert.Throws<ArgumentNullException>(() => node.FlattenHierarchy((x) => { return x.Childrens; }).ToList());
        }

        [Test]
        public void EmptyIfNull_WhenCollectionIsNull_ShouldReturnEmptyCollection()
        {
            // arrange
            HashSet<String> set = null;

            // act 
            IEnumerable<string> result = set.EmptyIfNull();

            // assert
            Assert.AreEqual(result.Count(), 0);
        }

        [Test]
        public void EmptyIfNull_WhenCollectionIsEmpty_ShouldReturnEmptyCollection()
        {
            // arrange
            HashSet<String> set = new HashSet<String>();

            // act 
            IEnumerable<string> result = set.EmptyIfNull();

            // assert
            Assert.AreEqual((result as HashSet<String>).Count, 0);
        }

        [Test]
        public void EmptyIfNull_WhenCollectionIsNotNull_ShouldReturnProvidedCollection()
        {
            // arrange
            List<String> list = new List<String>() { "a", "b", "c" };

            // act 
            IEnumerable<string> result = list.EmptyIfNull();

            // assert
            Assert.AreEqual(true, list.AreTheSame(result.ToList()));
        }
    }

    internal class Node
    {
        public Node Parent { get; set; }

        public IEnumerable<Node> Childrens { get; set; }
    }
}
