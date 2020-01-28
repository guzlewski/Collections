using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using S = System.Collections.Generic;

namespace Collections.Tests
{
    [TestClass]
    public class VectorTests
    {
        [TestMethod]
        public void Constructor()
        {
            var vector = new Vector<string>();
            var system = new S.List<string>();

            Assert.IsTrue(vector.Count == 0);
            Comparer<string>.Compare(vector, system);

            vector = new Vector<string>(Globals.Strings);
            system = new S.List<string>(Globals.Strings);

            Assert.IsTrue(vector.Count == Globals.Strings.Length);
            Comparer<string>.Compare(vector, system);

            vector = new Vector<string>(34);
            system = new S.List<string>(34);

            Assert.IsTrue(vector.Count == system.Count);
            Assert.IsTrue(vector.Capacity == system.Capacity);
            Comparer<string>.Compare(vector, system);
        }

        [TestMethod]
        public void Get()
        {
            var vector = new Vector<string>(Globals.Strings);
            var system = new S.List<string>(Globals.Strings);

            try
            {
                var _ = vector[-1];
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException) { }

            try
            {
                var _ = vector[Globals.Strings.Length];
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException) { }

            Comparer<string>.Compare(vector, system);

            for (int i = 0; i < Globals.Strings.Length; i++)
            {
                Assert.IsTrue(vector[i] == system[i]);
                Comparer<string>.Compare(vector, system);
            }

            Comparer<string>.Compare(vector, system);
        }

        [TestMethod]
        public void Set()
        {
            var vector = new Vector<string>(Globals.Strings);
            var system = new S.List<string>(Globals.Strings);

            try
            {
                vector[-1] = null;
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException) { }

            try
            {
                vector[Globals.Strings.Length] = null;
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException) { }

            Comparer<string>.Compare(vector, system);

            for (int i = 0; i < Globals.Strings.Length; i++)
            {
                vector[i] = i.ToString();
                system[i] = i.ToString();

                Comparer<string>.Compare(vector, system);
            }

            Comparer<string>.Compare(vector, system);
        }

        [TestMethod]
        public void Add()
        {
            var vector = new Vector<string>();
            var system = new S.List<string>();

            foreach (var i in Globals.Strings)
            {
                vector.Add(i);
                system.Add(i);

                Comparer<string>.Compare(vector, system);
            }

            Comparer<string>.Compare(vector, system);
        }

        [TestMethod]
        public void AddRange()
        {
            var vector = new Vector<string> { "", null, "1" };
            var system = new S.List<string> { "", null, "1" };

            Comparer<string>.Compare(vector, system);

            vector.AddRange(Globals.Strings);
            system.AddRange(Globals.Strings);

            Comparer<string>.Compare(vector, system);
        }

        [TestMethod]
        public void Clear()
        {
            var vector = new Vector<string>(Globals.Strings);
            var system = new S.List<string>(Globals.Strings);

            Comparer<string>.Compare(vector, system);

            vector.Clear();
            system.Clear();

            Comparer<string>.Compare(vector, system);

            foreach (var i in Globals.Strings)
            {
                vector.Add(i);
                system.Add(i);

                Comparer<string>.Compare(vector, system);
            }

            Comparer<string>.Compare(vector, system);
        }

        [TestMethod]
        public void GetEnumerator()
        {
            var vector = new Vector<string>(Globals.Strings);
            var system = new S.List<string>(Globals.Strings);

            Comparer<string>.Compare(vector, system);

            int index = 0;

            foreach (var item in vector)
            {
                Assert.IsTrue(item == system[index++]);
                Comparer<string>.Compare(vector, system);
            }

            Comparer<string>.Compare(vector, system);
        }

        [TestMethod]
        public void IndexOf()
        {
            var vector = new Vector<char>(Globals.Chars);
            var system = new S.List<char>(Globals.Chars);

            Comparer<char>.Compare(vector, system);

            for (int i = 0; i < Globals.Chars.Length; i++)
            {
                Assert.IsTrue(vector.IndexOf(Globals.Chars[i]) == i);
            }

            for (int i = 0; i < Globals.Chars.Length; i++)
            {
                Assert.IsTrue(vector.IndexOf(system[i]) == i);
            }

            Assert.IsTrue(vector.IndexOf(' ') == system.IndexOf(' '));

            Comparer<char>.Compare(vector, system);
        }

        [TestMethod]
        public void Insert()
        {
            var vector = new Vector<string>(Globals.Strings);
            var system = new S.List<string>(Globals.Strings);

            Comparer<string>.Compare(vector, system);

            try
            {
                vector.Insert(Globals.Strings.Length, "");
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException) { }

            try
            {
                vector.Insert(-1, "");
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException) { }

            Comparer<string>.Compare(vector, system);

            int count = vector.Count;

            for (int i = 0; i < count; i++)
            {
                vector.Insert(i, i.ToString());
                system.Insert(i, i.ToString());

                Comparer<string>.Compare(vector, system);
            }

            Comparer<string>.Compare(vector, system);
        }

        [TestMethod]
        public void PopBack()
        {
            var vector = new Vector<string>(Globals.Strings);
            var system = new S.List<string>(Globals.Strings);

            Comparer<string>.Compare(vector, system);

            for (int i = 0; i < Globals.Strings.Length; i++)
            {
                vector.PopBack();
                system.RemoveAt(Globals.Strings.Length - i - 1);

                Comparer<string>.Compare(vector, system);
            }

            Comparer<string>.Compare(vector, system);

            try
            {
                vector.PopBack();
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException) { }

            Comparer<string>.Compare(vector, system);
        }

        [TestMethod]
        public void Remove()
        {
            var vector = new Vector<char>(Globals.Chars);
            var system = new S.List<char>(Globals.Chars);

            Comparer<char>.Compare(vector, system);

            for (char c = '\0'; c < (char)1024; c++)
            {
                vector.Remove(c);
                system.Remove(c);

                Comparer<char>.Compare(vector, system);
            }

            Comparer<char>.Compare(vector, system);
        }

        [TestMethod]
        public void RemoveAll()
        {
            var vector = new Vector<char>(Globals.Chars.Concat(Globals.Chars).ToArray());
            var system = new S.List<char>(Globals.Chars.Concat(Globals.Chars).ToArray());

            Comparer<char>.Compare(vector, system);

            for (char c = '\0'; c < char.MaxValue; c++)
            {
                vector.RemoveAll(x => x == c);
                system.RemoveAll(x => x == c);

                Comparer<char>.Compare(vector, system);
            }

            Comparer<char>.Compare(vector, system);
        }

        [TestMethod]
        public void RemoveAt()
        {
            var vector = new Vector<int>(Globals.Ints);
            var system = new S.List<int>(Globals.Ints);

            Comparer<int>.Compare(vector, system);

            try
            {
                vector.RemoveAt(Globals.Ints.Length);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException) { }

            try
            {
                vector.RemoveAt(-1);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException) { }

            Comparer<int>.Compare(vector, system);

            Random random = new Random();

            while (system.Count != 0)
            {
                int index = random.Next(0, system.Count);

                vector.RemoveAt(index);
                system.RemoveAt(index);

                Comparer<int>.Compare(vector, system);
            }

            Comparer<int>.Compare(vector, system);
        }

        [TestMethod]
        public void Reverse()
        {
            var vector = new Vector<string>(Globals.Strings);
            var system = new S.List<string>(Globals.Strings);

            Comparer<string>.Compare(vector, system);

            int index = Globals.Strings.Length;

            foreach (var item in vector.Reverse())
            {
                Assert.IsTrue(item == system[--index]);
                Comparer<string>.Compare(vector, system);
            }

            Comparer<string>.Compare(vector, system);
        }

        [TestMethod]
        public void ToArray()
        {
            var vector = new Vector<string>(Globals.Strings);
            var system = new S.List<string>(Globals.Strings);

            Comparer<string>.Compare(vector, system);
            Comparer<string>.Compare(vector, vector);

            var vectorArray = vector.ToArray();
            var systemArray = system.ToArray();

            Comparer<string>.Compare(vectorArray, systemArray);
            Assert.IsTrue(vectorArray.Length == systemArray.Length);
        }
    }
}
