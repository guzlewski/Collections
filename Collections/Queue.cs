using System;
using System.Collections.Generic;

namespace Collections
{
    /*
    Complexity:

    Queue() - O(1)
    Queue(IEnumerable) - O(n)

    Clear - O(1)
    Contains - O(n)
    Dequeue - O(1)
    Enqueue - O(1)
    GetEnumerator - O(1)
    Peek - O(1)
    ToArray - O(n)
    TryDequeue - O(1)
    TryPeek - O(1)
     
    Code Coverage: 100%
    */

    public class Queue<T> : Container<T>
    {
        public Queue() : base() { }

        public Queue(IEnumerable<T> collection) : this()
        {
            foreach (var item in collection)
            {
                Enqueue(item);
            }
        }

        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Queue is empty!");
            }

            var value = Begin.Next.Value;

            Begin.Next = Begin.Next.Next;
            Begin.Next.Prev = Begin;
            Count--;

            return value;
        }

        public void Enqueue(T value)
        {
            var item = new Item<T>()
            {
                Prev = End.Prev,
                Next = End,
                Value = value
            };

            End.Prev.Next = item;
            End.Prev = item;
            Count++;
        }

        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Queue is empty!");
            }

            return Begin.Next.Value;
        }

        public bool TryDequeue(out T result)
        {
            if (Count == 0)
            {
                result = default;
                return false;
            }
            else
            {
                result = Dequeue();
                return true;
            }
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
    }
}
