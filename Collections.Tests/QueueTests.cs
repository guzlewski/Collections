using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using S = System.Collections.Generic;

namespace Collections.Tests
{
    [TestClass]
    public class QueueTests
    {
        [TestMethod]
        public void Constructor()
        {
            var queue = new Queue<int>();
            var system = new S.Queue<int>();

            Assert.IsTrue(queue.Count == 0);
            Comparer<int>.Compare(queue, system);

            queue = new Queue<int>(Globals.Ints);
            system = new S.Queue<int>(Globals.Ints);

            Assert.IsTrue(queue.Count == system.Count && queue.Count == Globals.Ints.Length);
            Comparer<int>.Compare(queue, system);
        }

        [TestMethod]
        public void Clear()
        {
            var queue = new Queue<int>(Globals.Ints);
            var system = new S.Queue<int>(Globals.Ints);

            Assert.IsTrue(queue.Count == Globals.Ints.Length);
            Comparer<int>.Compare(queue, system);

            queue.Clear();
            system.Clear();

            Assert.IsTrue(queue.Count == 0);
            Comparer<int>.Compare(queue, system);
        }

        [TestMethod]
        public void Contains()
        {
            var queue = new Queue<char>(Globals.Chars);
            var system = new S.Queue<char>(Globals.Chars);

            for (char c = '\0'; c < char.MaxValue; c++)
            {
                if (queue.Contains(c) != Globals.Chars.Contains(c) || queue.Contains(c) != system.Contains(c))
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void Peek()
        {
            var queue = new Queue<string>();

            try
            {
                queue.Peek();
                Assert.Fail();
            }
            catch (InvalidOperationException) { }

            queue = new Queue<string>(Globals.Strings);
            var system = new S.Queue<string>(Globals.Strings);

            while (queue.Count != 0)
            {
                Assert.IsTrue(queue.Peek() == system.Peek());

                queue.Dequeue();
                system.Dequeue();

                Comparer<string>.Compare(queue, system);
            }

            Assert.IsTrue(queue.Count == system.Count && queue.Count == 0);

            try
            {
                queue.Peek();
                Assert.Fail();
            }
            catch (InvalidOperationException) { }
        }

        [TestMethod]
        public void Dequeue()
        {
            var queue = new Queue<string>();

            try
            {
                queue.Dequeue();
                Assert.Fail();
            }
            catch (InvalidOperationException) { }

            queue = new Queue<string>(Globals.Strings);
            var system = new S.Queue<string>(Globals.Strings);

            while (queue.Count != 0)
            {
                Assert.IsTrue(queue.Dequeue() == system.Dequeue());
                Comparer<string>.Compare(queue, system);
            }

            Assert.IsTrue(queue.Count == system.Count && queue.Count == 0);

            try
            {
                queue.Dequeue();
                Assert.Fail();
            }
            catch (InvalidOperationException) { }
        }

        [TestMethod]
        public void Enqueue()
        {
            var queue = new Queue<int>();
            var system = new S.Queue<int>();

            foreach (var item in Globals.Ints)
            {
                queue.Enqueue(item);
                system.Enqueue(item);

                Comparer<int>.Compare(queue, system);
            }

            Comparer<int>.Compare(queue, system);
        }

        [TestMethod]
        public void TryPeek()
        {
            var queue = new Queue<string>(Globals.Strings);
            var system = new S.Queue<string>(Globals.Strings);

            while (queue.TryPeek(out string first))
            {
                Assert.IsTrue(first == system.Peek());

                queue.Dequeue();
                system.Dequeue();

                Comparer<string>.Compare(queue, system);
            }

            Comparer<string>.Compare(queue, system);
            Assert.IsFalse(queue.TryPeek(out _));
        }

        [TestMethod]
        public void TryDequeue()
        {
            var queue = new Queue<string>(Globals.Strings);
            var system = new S.Queue<string>(Globals.Strings);

            while (queue.TryDequeue(out string first))
            {
                Assert.IsTrue(first == system.Dequeue());
                Comparer<string>.Compare(queue, system);
            }

            Comparer<string>.Compare(queue, system);
            Assert.IsFalse(queue.TryDequeue(out _));
        }
    }
}
