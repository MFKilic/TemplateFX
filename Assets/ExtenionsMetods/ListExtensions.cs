using System;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

namespace TemplateFx
{
    public static class ListExtensions
    {
        /// <summary>
        /// Shuffle the list in place using the Fisher-Yates method.
        /// </summary>
        /// <param name="list"></param>
        /// <typeparam name="T"></typeparam>
        public static void Shuffle<T>(this IList<T> list)
        {
            var count = list.Count;
            var last = count - 1;
            for (var i = 0; i < last; ++i)
            {
                var r = Random.Range(i, count);
                (list[i], list[r]) = (list[r], list[i]);
            }
        }

        /// <summary>
        /// Removes a random item from the list, returning that item.
        /// Sampling without replacement.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static T RemoveRandomElement<T>(this IList<T> list)
        {
            if (list.Count == 0)
            {
                throw new IndexOutOfRangeException("Cannot remove a random element from an empty list");
            }

            int index = Random.Range(0, list.Count);
            T item = list[index];
            list.RemoveAt(index);
            return item;
        }

        public static T RandomElement<T>(this IList<T> list)
        {
            if (list.Count == 0)
            {
                throw new IndexOutOfRangeException("Cannot get a random element from an empty list");
            }

            int randomIndex = Random.Range(0, list.Count);
            return list[randomIndex];
        }

        public static T RandomElement<T>(this IList<T> list, IList<T> excludedElements)
        {
            if (list.Count == 0)
            {
                throw new IndexOutOfRangeException("Cannot get a random element from an empty list");
            }

            IList<T> allowedElements = CollectAllowedElements(list, excludedElements);
            return RandomElement(allowedElements);
        }

        public static T RandomElement<T>(this IList<T> list, params T[] excludeElements)
        {
            if (list.Count == 0)
            {
                throw new IndexOutOfRangeException("Cannot get a random element from an empty list");
            }

            IList<T> allowedElements = CollectAllowedElements(list, excludeElements);
            return RandomElement(allowedElements);
        }

        public static IList<T> CollectAllowedElements<T>(this IList<T> list, IList<T> excludedElements)
        {
            if (list.Count == 0)
            {
                throw new IndexOutOfRangeException("Cannot collect from an empty list");
            }

            List<T> allowedElements = new List<T>();
            foreach (T element in list)
            {
                if (!excludedElements.Contains(element))
                {
                    allowedElements.Add(element);
                }
            }

            return allowedElements;
        }

        /// <summary>
        /// Get the minimum element, based on some property, like a distance or a price.
        /// </summary>
        public static T MinElement<T, R>(this IEnumerable<T> en, Func<T, R> evaluate) where R : IComparable<R>
        {
            return en.Select(t => new Tuple<T, R>(t, evaluate(t)))
                .Aggregate((max, next) => next.Item2.CompareTo(max.Item2) < 0 ? next : max).Item1;
        }

        public static T MaxElement<T, R>(this IEnumerable<T> en, Func<T, R> evaluate) where R : IComparable<R>
        {
            return en.Select(t => new Tuple<T, R>(t, evaluate(t)))
                .Aggregate((max, next) => next.Item2.CompareTo(max.Item2) > 0 ? next : max).Item1;
        }
    }


}
