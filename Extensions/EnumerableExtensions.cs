using System;
using System.Collections.Generic;
using System.Linq;

namespace Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> FlattenHierarchy<T>(this T node,
                     Func<T, IEnumerable<T>> getChildEnumerator)
        {
            if (node == null)
            {
                throw new ArgumentNullException();
            }

            yield return node;
            var children = getChildEnumerator(node);
            if (children == null) yield break;

            foreach (
                var childOrDescendant in
                    children.SelectMany(child => child.FlattenHierarchy(getChildEnumerator)))
            {
                yield return childOrDescendant;
            }
        }

        public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> input)
            => input ?? Enumerable.Empty<T>();
    }
}
