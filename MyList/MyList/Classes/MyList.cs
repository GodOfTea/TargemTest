using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyListTest.Classes
{
    public class MyList<T> : IList<T> where T : IComparable<T>
    {
        private T[] _contents = new T[1];
        private int _count;

        public MyList()
        {
            _count = 0;
        }

        public T this[int index]
        {
            get => _contents[index];
            set => _contents[index] = value;
        }

        public int Count => _count;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            if (_count >= _contents.Length)
            {
                T[] temp = new T[_contents.Length * 2];

                for (int i = 0; i < _contents.Length; i++)
                {
                    temp[i] = _contents[i];
                }

                _contents = temp;
            }

            _contents[_count] = item;
            ++_count;
        }

        public void Clear()
        {
            _count = 0;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_contents[i] != null)
                    if (_contents[i].CompareTo(item) == 0)
                        return true;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            for (int i = 0; i < Count; i++)
            {
                array.SetValue(_contents[i], arrayIndex++);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return (IEnumerator<T>)_contents.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_contents[i].CompareTo(item) == 0)
                    return i;
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            if (_count + 1 <= _contents.Length && index < Count && index >= 0)
            {
                for (int i = Count - 1; i < index; i--)
                {
                    _contents[i] = _contents[i - 1];
                }
                _contents[index] = item;
            }
        }

        public bool Remove(T item)
        {
            RemoveAt(IndexOf(item));
            return true;
        }

        public void RemoveAt(int index)
        {
            if (index >= 0 && index < Count)
            {
                for (int i = index; i < Count - 1; i++)
                {
                    _contents[i] = _contents[i + 1];
                }
                _count--;
            }

            if (_count <= _contents.Length / 2)
            {
                T[] temp = new T[_contents.Length / 2];

                for (int i = 0; i < _contents.Length / 2; i++)
                {
                    temp[i] = _contents[i];
                }

                _contents = temp;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void PrintContents()
        {
            Console.WriteLine($"List has a capacity of {_contents.Length} and currently has {_count} elements.");
            Console.Write("List contents:");
            for (int i = 0; i < Count; i++)
            {
                Console.Write($" {_contents[i]}");
            }
            Console.WriteLine();
        }
    }
}
