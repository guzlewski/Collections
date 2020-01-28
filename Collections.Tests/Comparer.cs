using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Collections.Tests
{
    public static class Comparer<T>
    {
        public static bool Compare(IEnumerable<T> first, IEnumerable<T> second)
        {
            var firstEnum = first.GetEnumerator();
            var secondEnum = second.GetEnumerator();

            bool firstEnd, secondEnd;

            while (true)
            {
                firstEnd = firstEnum.MoveNext();
                secondEnd = secondEnum.MoveNext();

                if (!firstEnd && !secondEnd)
                {
                    break;
                }
                else if (firstEnd != secondEnd)
                {
                    Assert.Fail("Collections have different length.");
                    return false;
                }

                if (!EqualityComparer<T>.Default.Equals(firstEnum.Current, secondEnum.Current))
                {
                    Assert.Fail($"Collections have different items: '{firstEnum.Current}' != '{secondEnum.Current}'");
                    return false;
                }
            }

            return true;
        }
    }
}
