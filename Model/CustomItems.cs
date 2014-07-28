using System;
using System.Collections.Generic;

namespace Learn.Model
{
    [Serializable]
    public abstract class CustomItems<T>:Notifier
    {
        private string _name=string.Empty;
        private string _remark=string.Empty;
        private List<T> _items;

        public CustomItems()
        {
            _items = new List<T>();
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name!=value)
                {
                    _name = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Remark
        {
            get { return _remark; }
            set
            {
                if (_remark!=value)
                {
                    _remark = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public List<T> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                NotifyPropertyChanged();
            }
        }

        public void Add(T value)
        {
            _items.Add(value);
            NotifyPropertyChanged();
        }

        public void RemoveAt(int idx)
        {
            if (idx >= 0 && idx < _items.Count)
            {
                _items.RemoveAt(idx);
                NotifyPropertyChanged();
            }
            else
                throw new IndexOutOfRangeException("Indexhatár átlépés");
        }

        public void Remove(T item)
        {
            if (_items.Contains(item))
            {
                _items.Remove(item);
                NotifyPropertyChanged();
            }
        }
        public T this[int idx]
        {
            get
            {
                if (idx >= 0 && idx < _items.Count)
                    return _items[idx];
                else
                    throw new IndexOutOfRangeException("Indexhatár átlépés");
            }
            set
            {
                if (idx >= 0 && idx < _items.Count)
                {
                    _items[idx] = value;
                    NotifyPropertyChanged();
                }
                else
                    throw new IndexOutOfRangeException("Indexhatár átlépés");
            }
        }
    }
}
