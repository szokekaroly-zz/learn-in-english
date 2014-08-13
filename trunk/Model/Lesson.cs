using System;

namespace Learn.Model
{
    [Serializable]
    public class Lesson:CustomItems<Word>
    {
        public Word CreateWord()
        {
            Word word = new Word();
            Add(word);
            NotifyPropertyChanged();
            return word;
        }
    }
}
