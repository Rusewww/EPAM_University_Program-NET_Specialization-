using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CustomArray
{
    public class CustomArray<T> : IEnumerable<T>
    {
        private readonly T[] _array;
        private readonly int _first;

        public CustomArray(int first, int length)
        {
            if (length < 0)
            {
                throw new ArgumentException("Length cannot be negative.");
            }

            _first = first;
            _array = new T[length];
        }

        public CustomArray(int first, IEnumerable<T> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }

            _first = first;
            _array = list.ToArray();
        }

        public CustomArray(int first, params T[] list)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }

            if (list.Length == 0)
            {
                throw new ArgumentException("List cannot be empty.");
            }

            _first = first;
            _array = list;
        }

        public int First => _first;

        public int Last => _first + _array.Length - 1;

        public int Length => _array.Length;

        public T[] Array => _array;

        public T this[int index]
        {
            get
            {
                if (index < _first || index > Last)
                {
                    throw new ArgumentException("Index is out of range.");
                }

                return _array[index - _first];
            }
            set
            {
                if (index < _first || index > Last)
                {
                    throw new ArgumentException("Index is out of range.");
                }

                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                _array[index - _first] = value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)_array).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _array.GetEnumerator();
        }
    }
}
