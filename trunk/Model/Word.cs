using System;

namespace Learn.Model
{
    [Serializable]
    public class Word : Notifier
    {
        private string _hungarian=string.Empty;
        private string _foreign=string.Empty;
        private int _comparePercent=100;

        /// <summary>
        /// Magyarul
        /// </summary>
        public String Hungarian
        {
            get { return _hungarian; }
            set
            {
                if (_hungarian!=value)
                {
                    _hungarian = value;
                    NotifyPropertyChanged();
                }
            }
        }
        /// <summary>
        /// Idegen nyelven
        /// </summary>
        public String Foreign
        {
            get { return _foreign; }
            set
            {
                if (_foreign!=value)
                {
                    _foreign = value;
                    NotifyPropertyChanged();
                }
            }
        }
        /// <summary>
        /// Nem teljes egyezés esetén hány százalékos hasonlóság
        /// esetén lehessen automatikusan elfogadni
        /// </summary>
        public int ComparePercent
        {
            get { return _comparePercent; }
            set
            {
                if (_comparePercent!=value)
                {
                    _comparePercent = value;
                    NotifyPropertyChanged();
                }
            }
        }
        /// <summary>
        /// Meghatározza, hogy két sztring hány százalékban hasonlít
        /// </summary>
        /// <param name="value1">Ehhez hasonlít</param>
        /// <param name="value2">Ezt hasonlítja</param>
        /// <returns>0-100%</returns>
        private int comparePercent(string value1, string value2)
        {
            if (value1==value2)
                return 100;
            else
                return 0;
        }
        /// <summary>
        /// Összehasonlítja a megadott szót a magyar jelentéssel
        /// </summary>
        /// <param name="value">Összehasonlítandó szó</param>
        /// <returns>true: helyes; false: helytelen</returns>
        public bool checkHungarian(string value)
        {
            return comparePercent(Hungarian, value) > ComparePercent;
        }
        /// <summary>
        /// Összehasonlítja a megadott szót az idegen jelentéssel
        /// </summary>
        /// <param name="value">Összehasonlítandó szó</param>
        /// <returns>true: helyes; false: helytelen</returns>
        public bool checkForeign(string value)
        {
            return comparePercent(Foreign, value) > ComparePercent;
        }
    }
}
