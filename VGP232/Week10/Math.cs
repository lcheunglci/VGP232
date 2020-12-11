using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Week10
{
    public class Math : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int left;
        
        public int Left
        {
            get { return left; }
            set
            {
                left = value;
                NotifyPropertyChanged("Left");
            }
        }

        private int right;

        public int Right
        {
            get { return right; }
            set
            {
                right = value;
                NotifyPropertyChanged("Right");
            }
        }

        private void NotifyPropertyChanged(String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
