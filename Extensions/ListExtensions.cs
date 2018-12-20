using System;
using System.Collections.Generic;
using System.Linq;

namespace Extensions
{
    public static class ListExtensions
    {
        public static void Shuffle<T>(this List<T> list) where T : ICloneable
        {
            if (list.IsNull())
            {
                throw new ArgumentNullException();
            }

            int count = list.Count;

            if (count <= 1)
            {
                return;
            }

            Random rng = new Random();
            List<T> origin = list.Clone<T>().ToList();

            
            while (count > 1)
            {
                count--;
                int index = rng.Next(count + 1);
                T value = list[index];
                list[index] = list[count];
                list[count] = value;
            }

            while (list.AreTheSame(origin))
            {
                Shuffle(list);
            }
        }

        public static bool AreTheSame<T>(this IList<T> list, IList<T> listToCompare)
        {
            if (list.IsNull())
            {
                throw new ArgumentNullException();
            }
            if (listToCompare.IsNull())
            {
                return false;
            }

            int listCount = list.Count();
            int listToCompareCount = listToCompare.Count();

            if (listCount != listToCompareCount)
            {
                return false;
            }

            for (int i = 0; i < listCount; i++)
            {
                if (!list[i].Equals(listToCompare[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public static List<T> Swap<T>(this List<T> list, T first, T second)
        {
            if (!list.Contains(first) || !list.Contains(second)) {
                throw new ArgumentOutOfRangeException();
            }
            else {
                var firstIndex = list.FindIndex(x => x.Equals(first));
                var secondIndex = list.FindIndex(x => x.Equals(second));
                list[firstIndex] = second;
                list[secondIndex] = first;
            }
            return list;
        }

        public static IList<T> Clone<T>(this IList<T> listToClone) where T : ICloneable 
            => listToClone.Select(item => (T) item.Clone()).ToList();
    }
}
