using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using S = System.Collections.Generic;

namespace Collections.Tests
{
    [TestClass]
    public class ContainerTests
    {
        [TestMethod]
        public void GetEnumerator()
        {
            var stack = new Queue<int>(Globals.Ints);

            Assert.IsTrue(stack.Count == Globals.Ints.Length);
            Comparer<int>.Compare(stack, Globals.Ints);

            var enumerator = ((IEnumerable)stack).GetEnumerator();

            int index = 0;
            while (enumerator.MoveNext())
            {
                Assert.IsTrue(Globals.Ints[index].Equals(enumerator.Current));
                index++;
            }

            Assert.IsTrue(index == Globals.Ints.Length);
        }

        [TestMethod]
        public void ToArray()
        {
            var stack = new Stack<string>(Globals.Strings);
            var systemStack = new S.Stack<string>(Globals.Strings);

            Comparer<string>.Compare(stack, systemStack);
            Comparer<string>.Compare(stack, stack);

            var stackArray = stack.ToArray();
            var systemStackArray = systemStack.ToArray();

            Comparer<string>.Compare(stackArray, systemStackArray);
            Assert.IsTrue(stackArray.Length == systemStackArray.Length);


            var queue = new Queue<string>(Globals.Strings);
            var systemQueue = new S.Queue<string>(Globals.Strings);

            Comparer<string>.Compare(queue, systemQueue);
            Comparer<string>.Compare(queue, systemQueue);

            var queueArray = queue.ToArray();
            var systemQueueArray = systemQueue.ToArray();

            Comparer<string>.Compare(queueArray, systemQueueArray);
            Assert.IsTrue(queueArray.Length == systemQueueArray.Length);
        }
    }
}
