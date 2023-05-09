using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ArrayEvent
{
    public delegate void ArrayHandler<T>(object sender, ArrayEventArgs<T> e);

    public class CustomArray<T> : IEnumerable<T>
    {
        private readonly T[] _array;
        private readonly int _first;

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _array.Length; i++)
            {
                yield return _array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public event ArrayHandler<T> OnChangeElement;
        public event ArrayHandler<T> OnChangeEqualElement;

        public CustomArray(int first, int length)
        {
            if (length < 0)
            {
                throw new ArgumentException("Length cannot be negative.");
            }

            _first = first;
            _array = new T[length];
        }

        public CustomArray(int first, params T[] list) : this(first, list as IEnumerable<T>)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }

            if (list.Length == 0)
            {
                throw new ArgumentException("List cannot be empty.");
            }
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

                T oldValue = _array[index - _first];
                if (!Equals(oldValue, value))
                {
                    _array[index - _first] = value;
                    OnChangeElement?.Invoke(this, new ArrayEventArgs<T>(index, "Element value changed", value));
                }

                if (Equals(index, value))
                {
                    OnChangeEqualElement?.Invoke(this, new ArrayEventArgs<T>(index, "Element value equal to index", value));
                }
            }
        }
    }
}