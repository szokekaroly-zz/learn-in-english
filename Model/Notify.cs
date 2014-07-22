using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Learn.Model
{
    [Serializable]
    public abstract class Notifier:INotifyPropertyChanged
    {
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
