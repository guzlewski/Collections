using System;
using System.Collections.Generic;

namespace Collections
{
    /*
    Complexity:

    Vector() - O(1)
    Vector(capacity) - O(1)
    Vector(IEnumerable) - O(n)

    [] - O(1)

    Add - O(1) --> O(n)
    AddRange - O(n)
    Clear - O(1)
    Contains - O(n)
    ElementAt - O(1)
    GetEnumerator - O(1)
    IndexOf - O(n)
    Insert - O(n)
    Remove - O(n)
    RemoveAll - O(n)
    RemoveAt - O(n)
    PopBack - O(1)
    Reversed - O(1)
    ToArray - O(n)

    Code Coverage: 100%
    */
    public class Vector<T> : Container<T>, IReversable<T>
    {
        private T[] values;

        public int Capacity { get => values.Length; }

        public Vector()
        {
            values = new T[2];
        }

        public Vector(int capacity)
        {
            values = new T[capacity];
        }

        public Vector(IEnumerable<T> collection) : this()
        {
            foreach (var item in collection)
            {
                Add(item);
            }
        }

        public T this[int index]
        {
            get => Get(index);
            set => Set(index, value);
        }

        public void Add(T item)
        {
            if (Count == values.Length)
            {
                T[] biggerArray = new T[2 * values.Length];

                Array.Copy(values, 0, biggerArray, 0, values.Length);
                values = biggerArray;
            }

            values[Count++] = item;
        }

        public void AddRange(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Add(item);
            }
        }

        public override void Clear()
        {
            Count = 0;
        }

        public override IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return values[i];
            }
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

            T[] newArray;

            if (Count == values.Length)
            {
                newArray = new T[2 * Capacity];
            }
            else
            {
                newArray = new T[Capacity];
            }

            Array.Copy(values, 0, newArray, 0, index);
            newArray[index] = value;
            Array.Copy(values, index, newArray, index + 1, Count - index);

            values = newArray;
            Count++;
        }

        public T PopBack()
        {
            if (Count == 0)
            {
                throw new ArgumentOutOfRangeException("Vector is empty.");
            }

            T value = values[Count - 1];

            values[Count - 1] = default;
            Count--;

            return value;
        }

        public void Remove(T item)
        {
            int index = IndexOf(item);

            if (index != -1)
            {
                RemoveAt(index);
            }
        }

        public void RemoveAll(Predicate<T> match)
        {
            T[] array = new T[Capacity];
            int index = 0, count = 0;

            foreach (var item in this)
            {
                if (!match.Invoke(item))
                {
                    array[index++] = item;
                    count++;
                }
            }

            Count = count;
            values = array;
        }

        public void RemoveAt(int index)
        {
            T[] array = new T[Capacity];

            Array.Copy(values, 0, array, 0, index);
            Array.Copy(values, index + 1, array, index, Count - index - 1);

            Count--;
            values = array;
        }

        public IEnumerable<T> Reverse()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return values[i];
            }
        }

        public override T[] ToArray()
        {
            T[] array = new T[Count];

            Array.Copy(values, 0, array, 0, Count);

            return array;
        }

        public T Get(int index)
        {
            if (index >= Count || index < 0)
            {
                throw new ArgumentOutOfRangeException("Index has to be bigger than 0 and smaller than Count.");
            }

            return values[index];
        }

        private void Set(int index, T value)
        {
            if (index >= Count || index < 0)
            {
                throw new ArgumentOutOfRangeException("Index has to be bigger than 0 and smaller than Count.");
            }

            values[index] = value;
        }
    }
}
