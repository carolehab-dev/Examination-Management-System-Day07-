using System;
using System.Collections.Generic;
using System.Text;

namespace Day_7
{

    public class Repository<T> where T : ICloneable, IComparable<T>
    {
        private T[] _items;
        private int _count;

        public Repository()
        {
            _items = new T[10];
            _count = 0;
        }

        public void Add(T item)
        {
            _items[_count] = item;
            _count++;
        }

        public void Remove(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_items[i].Equals(item))
                {
                    _items[i] = _items[_count - 1];
                    _count--;
                    return;
                }
            }
        }

        public void Sort()
        {
            Array.Sort(_items, 0, _count);
        }

        public T[] GetAll()
        {
            return _items;
        }
    }
}
