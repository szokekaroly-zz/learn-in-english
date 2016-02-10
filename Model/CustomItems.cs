using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Learn.Model
{
    [Serializable]
    public abstract class CustomItems<T>:Notifier where T:Notifier
    {
        private string _name=string.Empty;
        private string _remark=string.Empty;
        private ObservableCollection<T> _items;

        public CustomItems()
        {
            _items = new ObservableCollection<T>();
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

        public ObservableCollection<T> Items
        {
            get { return _items; }
            protected set
            {
                _items = value;
                NotifyPropertyChanged();
                foreach (var item in _items)
                {
                    item.Modified += OnModified;
                }
            }
        }

        public void Add(T value)
        {
            _items.Add(value);
            NotifyPropertyChanged();
            IsModified = true;
            value.Modified += OnModified;
        }

        public void RemoveAt(int idx)
        {
            if (idx >= 0 && idx < _items.Count)
            {
                _items[idx].Modified -= OnModified;
                _items.RemoveAt(idx);
                NotifyPropertyChanged();
                IsModified = true;
            }
            else
                throw new IndexOutOfRangeException("Indexhatár átlépés");
        }

        public void Remove(T item)
        {
            if (_items.Contains(item))
            {
                item.Modified -= OnModified;
                _items.Remove(item);
                NotifyPropertyChanged();
                IsModified = true;
            }
        }
        public T this[int idx]
        {
            get
            {
                if (idx >= 0 && idx < _items.Count)
                    return _items[idx];
                else
                    return null;
            }
            protected set
            {
                if (idx >= 0 && idx < _items.Count)
                {
                    _items[idx] = value;
                    NotifyPropertyChanged();
                    value.Modified += OnModified;
                    IsModified = true;
                }
                else
                    throw new IndexOutOfRangeException("Indexhatár átlépés");
            }
        }

        public void OnModified(object sender, EventArgs e)
        {
            IsModified = true;
        }
    }
}
