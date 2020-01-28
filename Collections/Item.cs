namespace Collections
{
    class Item<T>
    {
        internal Item<T> Prev;
        internal Item<T> Next;

        internal T Value;

        internal void Clear()
        {
            Prev = null;
            Next = null;
            Value = default;
        }
    }
}
