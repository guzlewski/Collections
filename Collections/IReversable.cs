using System.Collections.Generic;

namespace Collections
{
    public interface IReversable<T>
    {
        IEnumerable<T> Reverse();
    }
}
