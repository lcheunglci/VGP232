using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewExample
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        Person person;

        public string Name
        {
            get { return person.Name; }
            set
            {
                NotifyPropertyChanged("Name");
                person.Name = value;
            }
        }

        public int Age
        {
            get { return person.Age; }
            set {
                NotifyPropertyChanged("Age");
                person.Age = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
