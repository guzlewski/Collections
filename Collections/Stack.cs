using System;
using System.Collections.Generic;

namespace Collections
{
    /*
    Complexity:

    Stack() - O(1)
    Stack(IEnumerable) - O(n)

    Clear - O(1)
    Contains - O(n)
    GetEnumerator - O(1)
    Peek - O(1)
    Pop - O(1)
    Push - O(1)
    ToArray - O(n)
    TryPeek - O(1)
    TryPop - O(1)
    
    Code Coverage: 100%
    */

    public class Stack<T> : Container<T>
    {
        public Stack() : base() { }

        public Stack(IEnumerable<T> collection) : this()
        {
            foreach (var item in collection)
            {
                Push(item);
            }
        }

        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Stack is empty!");
            }

            return Begin.Next.Value;
        }

        public T Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Stack is empty!");
            }

            var value = Begin.Next.Value;

            Begin.Next = Begin.Next.Next;
            Count--;

            return value;
        }

        public void Push(T value)
        {
            var item = new Item<T>
            {
                Next = Begin.Next,
                Value = value
            };

            Begin.Next = item;
            Count++;
        }

        public bool TryPeek(out T result)
        {
            if (Count == 0)
            {
                result = default;
                return false;
            }
            else
            {
                result = Peek();
                return true;
            }
        }

        public bool TryPop(out T result)
        {
            if (Count == 0)
            {
                result = default;
                return false;
            }
            else
            {
                result = Pop();
                return true;
            }
        }
    }
}
