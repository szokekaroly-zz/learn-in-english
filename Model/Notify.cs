using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Learn.Model
{
    [Serializable]
    public abstract class Notifier:INotifyPropertyChanged
    {
        [NonSerialized]
        private bool _isModified;
        public bool IsModified
        {
            get { return _isModified; }
            set
            {
                if (_isModified != value)
                {
                    _isModified = value;
                    NotifyModifiedChanged();
                }
            }
        }

        [field:NonSerialized]
        public event EventHandler Modified;

        private void NotifyModifiedChanged()
        {
            if (Modified != null)
            {
                Modified(this, new EventArgs());
            }
        }

        [field:NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
