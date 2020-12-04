using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Week9WPF
{
    public class Character : INotifyPropertyChanged
    {
        private int _strength;
        public int Strength
        {
            get { return _strength; }
            set {
                _strength = value;
                if (_strength >= 15)
                {
                    _strengthMod = 2;
                }
                else
                {
                    _strengthMod = 0;
                }

                NotifyPropertyChanged("StrengthModifier");
                NotifyPropertyChanged("Strength");
            }
        }

        private int _strengthMod;

        public int StrengthModifier
        {
            get { return _strengthMod; }
            set
            {
                _strengthMod = value;
                NotifyPropertyChanged("StrengthModifier");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
