using System;
using System.Collections.Generic;

namespace Collections
{
    /*
    Complexity:

    List() - O(1)
    List(IEnumerable) - O(n)

    [] - O(n)

    Add - O(1)
    AddRange - O(n)
    Clear - O(1)
    Contains - O(n)
    ElementAt - O(n)
    GetEnumerator - O(1)
    IndexOf - O(n)
    Insert - O(n)
    Remove - O(n)
    RemoveAll - O(n)
    RemoveAt - O(n)
    Reversed - O(1)
    ToArray - O(n)
     
    Code Coverage: 100%
    */
    public class List<T> : Container<T>
    {
        public List() { }
        public List(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Add(item);
            }
        }

        public T this[int key]
        {
            get => Get(key);
            set => Set(key, value);
        }

        public void Add(T value)
        {
            var item = new Item<T>
            {
                Prev = End.Prev,
                Next = End,
                Value = value
            };

            End.Prev.Next = item;
            End.Prev = item;
            Count++;
        }

        public void AddRange(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Add(item);
            }
        }

        public T ElementAt(int index)
        {
            return Get(index);
        }

        public int IndexOf(T item)
        {
            int index = 0;

            foreach (var i in this)
            {
                if (EqualityComparer<T>.Default.Equals(item, i))
                {
                    return index;
                }

                index++;
            }

            return -1;
        }

        public void Insert(int index, T value)
        {
            if (index >= Count || index < 0)
            {
                throw new ArgumentOutOfRangeException("Index has to be bigger than 0 and smaller than Count.");
            }

            var next = GetItem(index);
            var prev = next.Prev;

            var item = new Item<T>
            {
                Prev = prev,
                Next = next,
                Value = value
            };

            prev.Next = item;
            next.Prev = item;
            Count++;
        }

        public void Remove(T item)
        {
            var current = Begin.Next;

            while (current != End)
            {
                if (EqualityComparer<T>.Default.Equals(current.Value, item))
                {
                    Remove(current);
                    return;
                }

                current = current.Next;
            }
        }

        public void RemoveAll(Predicate<T> match)
        {
            var current = Begin.Next;

            while (current != End)
            {
                if (match.Invoke(current.Value))
                {
                    var temp = current;
                    current = current.Next;

                    Remove(temp);
                }
                else
                {
                    current = current.Next;
                }
            }
        }

        public void RemoveAt(int index)
        {
            if (index >= Count || index < 0)
            {
                throw new ArgumentOutOfRangeException("Index has to be bigger than 0 and smaller than Count.");
            }

            var current = Begin.Next;

            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            Remove(current);
        }

        public IEnumerable<T> Reverse()
        {
            var current = End.Prev;

            while (current != Begin)
            {
                yield return current.Value;
                current = current.Prev;
            }
        }

        private T Get(int index)
        {
            if (index >= Count || index < 0)
            {
                throw new ArgumentOutOfRangeException("Index has to be bigger than 0 and smaller than Count.");
            }

            T value = default;

            foreach (var item in this)
            {
                if (index-- == 0)
                {
                    value = item;
                    break;
                }
            }

            return value;
        }

        private Item<T> GetItem(int index)
        {
            var current = Begin.Next;

            while (index-- != 0)
            {
                current = current.Next;
            }

            return current;
        }

        private void Remove(Item<T> item)
        {
            var prev = item.Prev;
            var next = item.Next;

            prev.Next = next;
            next.Prev = prev;

            Count--;
        }

        private void Set(int key, T value)
        {
            if (key >= Count || key < 0)
            {
                throw new ArgumentOutOfRangeException("Index has to be bigger than 0 and smaller than Count.");
            }

            var current = Begin.Next;

            while (key-- != 0)
            {
                current = current.Next;
            }

            current.Value = value;
        }
    }
}
