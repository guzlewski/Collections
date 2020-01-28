using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using S = System.Collections.Generic;

namespace Collections.Tests
{
    [TestClass]
    public class ListTests
    {
        [TestMethod]
        public void Constructor()
        {
            var list = new List<int>();
            var system = new S.List<int>();

            Assert.IsTrue(list.Count == 0);
            Comparer<int>.Compare(list, system);

            list = new List<int>(Globals.Ints);
            system = new S.List<int>(Globals.Ints);

            Assert.IsTrue(list.Count == system.Count && list.Count == Globals.Ints.Length);
            Comparer<int>.Compare(list, system);
        }

        [TestMethod]
        public void Get()
        {
            var list = new List<string>(Globals.Strings);
            var system = new S.List<string>(Globals.Strings);

            Comparer<string>.Compare(list, system);

            try
            {
                var _ = list[-1];
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException) { }

            try
            {
                var _ = list[Globals.Strings.Length];
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException) { }

            Comparer<string>.Compare(list, system);

            for (int i = 0; i < system.Count; i++)
            {
                Assert.IsTrue(list[i] == system[i]);

                Comparer<string>.Compare(list, system);
            }

            Comparer<string>.Compare(list, system);
        }

        [TestMethod]
        public void Set()
        {
            var list = new List<string>(Globals.Strings);
            var system = new S.List<string>(Globals.Strings);

            Comparer<string>.Compare(list, system);

            try
            {
                list[-1] = null;
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException) { }

            try
            {
                list[Globals.Strings.Length] = null;
            }
            catch (ArgumentOutOfRangeException) { }

            Comparer<string>.Compare(list, system);

            for (int i = 0; i < system.Count; i++)
            {
                list[i] = i.ToString();
                system[i] = i.ToString();

                Comparer<string>.Compare(list, system);
            }

            Comparer<string>.Compare(list, system);
        }

        [TestMethod]
        public void Add()
        {
            var list = new List<int>();
            var system = new S.List<int>();

            foreach (var i in Globals.Ints)
            {
                list.Add(i);
                system.Add(i);

                Comparer<int>.Compare(list, system);
            }

            Assert.IsTrue(list.Count == system.Count && list.Count == Globals.Ints.Length);
            Comparer<int>.Compare(list, system);
        }

        [TestMethod]
        public void AddRange()
        {
            var list = new List<int>();
            var system = new S.List<int>();

            list.AddRange(Globals.Ints);
            system.AddRange(Globals.Ints);

            Assert.IsTrue(list.Count == system.Count && list.Count == Globals.Ints.Length);
            Comparer<int>.Compare(list, system);
        }

        [TestMethod]
        public void Clear()
        {
            var list = new List<int>(Globals.Ints);
            var system = new S.List<int>(Globals.Ints);

            Assert.IsTrue(list.Count == Globals.Ints.Length);
            Comparer<int>.Compare(list, system);

            list.Clear();
            system.Clear();

            Assert.IsTrue(list.Count == 0);
            Comparer<int>.Compare(list, system);
        }

        [TestMethod]
        public void Contains()
        {
            var list = new List<char>(Globals.Chars);
            var system = new S.List<char>(Globals.Chars);

            for (char c = '\0'; c < char.MaxValue; c++)
            {
                if (list.Contains(c) != Globals.Chars.Contains(c) || list.Contains(c) != system.Contains(c))
                {
                    Assert.Fail();
                }
            }

            Comparer<char>.Compare(list, system);
        }

        [TestMethod]
        public void ElementAt()
        {
            var list = new List<char>(Globals.Chars);
            var system = new S.List<char>(Globals.Chars);

            Comparer<char>.Compare(list, system);

            for (int i = 0; i < system.Count; i++)
            {
                Assert.IsTrue(list.ElementAt(i) == system.ElementAt(i));
            }

            Comparer<char>.Compare(list, system);
        }

        [TestMethod]
        public void IndexOf()
        {
            var list = new List<char>(Globals.Chars);
            var system = new S.List<char>(Globals.Chars);

            Comparer<char>.Compare(list, system);

            for (char c = '\0'; c < char.MaxValue; c++)
            {
                if (list.IndexOf(c) != system.IndexOf(c))
                {
                    Assert.Fail();
                }
            }

            Comparer<char>.Compare(list, system);
        }

        [TestMethod]
        public void Insert()
        {
            var list = new List<string>(Globals.Strings);
            var system = new S.List<string>(Globals.Strings);

            Comparer<string>.Compare(list, system);

            try
            {
                list.Insert(Globals.Strings.Length, "");
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException) { }

            try
            {
                list.Insert(-1, "");
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException) { }

            Comparer<string>.Compare(list, system);

            int count = list.Count;

            for (int i = 0; i < count; i++)
            {
                list.Insert(i, i.ToString());
                system.Insert(i, i.ToString());

                Comparer<string>.Compare(list, system);
            }

            Comparer<string>.Compare(list, system);
        }

        [TestMethod]
        public void Remove()
        {
            var list = new List<char>(Globals.Chars);
            var system = new S.List<char>(Globals.Chars);

            Comparer<char>.Compare(list, system);

            for (char c = '\0'; c < char.MaxValue; c++)
            {
                list.Remove(c);
                system.Remove(c);

                Comparer<char>.Compare(list, system);
            }

            Comparer<char>.Compare(list, system);
        }

        [TestMethod]
        public void RemoveAll()
        {
            var list = new List<char>(Globals.Chars.Concat(Globals.Chars).ToArray());
            var system = new S.List<char>(Globals.Chars.Concat(Globals.Chars).ToArray());

            Comparer<char>.Compare(list, system);

            for (char c = '\0'; c < char.MaxValue; c++)
            {
                list.RemoveAll(x => x == c);
                system.RemoveAll(x => x == c);

                Comparer<char>.Compare(list, system);
            }

            Comparer<char>.Compare(list, system);
        }

        [TestMethod]
        public void RemoveAt()
        {
            var list = new List<int>(Globals.Ints);
            var system = new S.List<int>(Globals.Ints);

            Comparer<int>.Compare(list, system);

            try
            {
                list.RemoveAt(Globals.Ints.Length);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException) { }

            try
            {
                list.RemoveAt(-1);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException) { }

            Comparer<int>.Compare(list, system);

            Random random = new Random();

            while (system.Count != 0)
            {
                int index = random.Next(0, system.Count);

                list.RemoveAt(index);
                system.RemoveAt(index);

                Comparer<int>.Compare(list, system);
            }

            Comparer<int>.Compare(list, system);
        }

        [TestMethod]
        public void Reverse()
        {
            var list = new List<int>(Globals.Ints);
            var system = new S.List<int>(Globals.Ints);

            Comparer<int>.Compare(list, system);

            int index = Globals.Ints.Length;

            foreach (var i in list.Reverse())
            {
                Assert.IsTrue(i == system[--index]);

                Comparer<int>.Compare(list, system);
            }

            Comparer<int>.Compare(list, system);
        }
    }
}
