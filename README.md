![coverage](https://img.shields.io/badge/coverage-100%25-brightgreen) ![build](https://img.shields.io/badge/build-passing-brightgreen)
# Collections
This is custom implementaion of generic Stack, Queue, List and Vector written in C#. Unit tests coverage: 100%. Vector is similar to List but has different complexity.  
All collections has implemented IEnumerable<T> interface, List and Vector IReversable<T> - iterate in reverse order. Methods and features are similar to System.Collections.Generic. 


# Complexity
|        |  []  |     Add     | AddRange | Clear | Contains | ElementAt | GetEnumerator | IndexOf | Insert | PopBack | Remove | RemoveAll | RemoveAt | Reversed | ToArray |
|--------|:----:|:-----------:|:--------:|:-----:|:--------:|:---------:|:-------------:|:-------:|:------:|---------|:------:|:---------:|:--------:|:--------:|:-------:|
| List   | O(n) |     O(1)    |   O(n)   |  O(1) |   O(n)   |    O(n)   |      O(1)     |   O(n)  |  O(n)  | -       |  O(n)  |    O(n)   |   O(n)   |   O(1)   |   O(n)  |
| Vector | O(1) |  O(1)/O(n)  |   O(n)   |  O(1) |   O(n)   |    O(1)   |      O(1)     |   O(n)  |  O(n)  | O(1)    |  O(n)  |    O(n)   |   O(n)   |   O(1)   |   O(n)  |

|       | Clear | Contains | Dequeue | Enqueue | GetEnumerator | Peek |  Pop | Push | ToArray | TryDequeue | TryPeek | TryPop |
|:-----:|:-----:|:--------:|:-------:|:-------:|:-------------:|:----:|:----:|:----:|:-------:|:----------:|:-------:|:------:|
| Queue |  O(1) |   O(n)   |   O(1)  |   O(1)  |      O(1)     | O(1) |   -  |   -  |   O(n)  |    O(1)    |   O(1)  |    -   |
| Stack |  O(1) |   O(n)   |    -    |    -    |      O(1)     | O(1) | O(1) | O(1) |   O(n)  |      -     |   O(1)  |  O(1)  |

# How to use
```cs
using Collections;

namespace Example
{
    class CollectionsSample
    {
        public static void Main(string[] args)
        {
            var stack = new Stack<int>();
            stack.Push(10);

            var queue = new Queue<char>();
            queue.Enqueue('c');

            var list = new List<string>();
            list.Add("string");

            var vector = new Vector<double>();
            vector.Add(3.14);
        }
    }
}
```
