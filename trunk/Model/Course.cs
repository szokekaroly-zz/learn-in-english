using System;

namespace Learn.Model
{
    [Serializable]
    public class Course:CustomItems<Lesson>
    {
        private string _fileName;

        public string FileName
        {
            get { return _fileName; }
            set
            {
                if (_fileName!=value)
                {
                    _fileName = value;
                    NotifyPropertyChanged();
                }
            }
        }
        /// <summary>
        /// Új lecke létrehozása
        /// </summary>
        /// <returns>Lesson </returns>
        public Lesson CreateLesson()
        {
            Lesson lesson = new Lesson();
            Add(lesson);
            return lesson;
        }
    }
}
