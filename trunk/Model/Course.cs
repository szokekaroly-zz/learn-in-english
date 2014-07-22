using System;

namespace Learn.Model
{
    [Serializable]
    public class Course<Lesson>:Notifier
    {
        public string FileName
        {
            get;
            set;
        }

    }
}
