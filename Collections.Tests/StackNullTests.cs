using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using S = System.Collections.Generic;

namespace Collections.Tests
{
    [TestClass]
    public class StackNullTests
    {
        [TestMethod]
        public void Constructor()
        {
            var stack = new Stack<string>();
            var system = new S.Stack<string>();

            Assert.IsTrue(stack.Count == 0);
            Comparer<string>.Compare(stack, system);

            stack = new Stack<string>(Globals.Strings);
            system = new S.Stack<string>(Globals.Strings);

            Assert.IsTrue(stack.Count == system.Count && stack.Count == Globals.Strings.Length);
            Comparer<string>.Compare(stack, system);
        }

        [TestMethod]
        public void Clear()
        {
            var stack = new Stack<string>(Globals.Strings);
            var system = new S.Stack<string>(Globals.Strings);

            Assert.IsTrue(stack.Count == Globals.Strings.Length);
            Comparer<string>.Compare(stack, system);

            stack.Clear();
            system.Clear();

            Assert.IsTrue(stack.Count == 0);
            Comparer<string>.Compare(stack, system);
        }

        [TestMethod]
        public void Contains()
        {
            var stack = new Stack<string>(Globals.Strings);
            var system = new S.Stack<string>(Globals.Strings);

            Comparer<string>.Compare(stack, system);

            foreach (var s in Globals.Strings)
            {
                Assert.IsTrue(stack.Contains(s));
            }

            Comparer<string>.Compare(stack, system);
        }

        [TestMethod]
        public void Peek()
        {
            var stack = new Stack<string>();

            try
            {
                stack.Peek();
                Assert.Fail();
            }
            catch (InvalidOperationException) { }

            stack = new Stack<string>(Globals.Strings);
            var system = new S.Stack<string>(Globals.Strings);

            while (stack.Count != 0)
            {
                Assert.IsTrue(stack.Peek() == system.Peek());

                stack.Pop();
                system.Pop();

                Comparer<string>.Compare(stack, system);
            }

            Assert.IsTrue(stack.Count == system.Count && stack.Count == 0);

            try
            {
                stack.Peek();
                Assert.Fail();
            }
            catch (InvalidOperationException) { }
        }

        [TestMethod]
        public void Pop()
        {
            var stack = new Stack<string>();

            try
            {
                stack.Pop();
                Assert.Fail();
            }
            catch (InvalidOperationException) { }

            stack = new Stack<string>(Globals.Strings);
            var system = new S.Stack<string>(Globals.Strings);

            while (stack.Count != 0)
            {
                Assert.IsTrue(stack.Pop() == system.Pop());
                Comparer<string>.Compare(stack, system);
            }

            Assert.IsTrue(stack.Count == system.Count && stack.Count == 0);

            try
            {
                stack.Pop();
                Assert.Fail();
            }
            catch (InvalidOperationException) { }
        }

        [TestMethod]
        public void Push()
        {
            var stack = new Stack<string>();
            var system = new S.Stack<string>();

            foreach (var item in Globals.Strings)
            {
                stack.Push(item);
                system.Push(item);

                Comparer<string>.Compare(stack, system);
            }

            Comparer<string>.Compare(stack, system);
        }

        [TestMethod]
        public void TryPeek()
        {
            var stack = new Stack<string>(Globals.Strings);
            var system = new S.Stack<string>(Globals.Strings);

            while (stack.TryPeek(out string first))
            {
                Assert.IsTrue(first == system.Peek());

                stack.Pop();
                system.Pop();

                Comparer<string>.Compare(stack, system);
            }

            Comparer<string>.Compare(stack, system);
            Assert.IsFalse(stack.TryPeek(out _));
        }

        [TestMethod]
        public void TryPop()
        {
            var stack = new Stack<string>(Globals.Strings);
            var system = new S.Stack<string>(Globals.Strings);

            while (stack.TryPop(out string first))
            {
                Assert.IsTrue(first == system.Pop());
                Comparer<string>.Compare(stack, system);
            }

            Comparer<string>.Compare(stack, system);
            Assert.IsFalse(stack.TryPop(out _));
        }
    }
}
