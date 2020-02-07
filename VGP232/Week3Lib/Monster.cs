using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Week3Lib
{
    public enum Ability
    {
        Fly, Swim, Dig, Climb
    }

    public enum Element
    {
        Fire, Water, Ice, Thunder, Lightning, Posion, Sleep, Blast
    }

    [Serializable]
    public class Monster : INotifyPropertyChanged
    {
        [XmlAttribute]
        public string name;
        public int health;
        public Ability ability;
        public Element element;

        private int _hp;
        public int HP
        {
            get
            {
                return _hp;
            }
            set
            {
                _hp = value;
                NotifyPropertyChanged("HP");
            }
        }

        private void NotifyPropertyChanged(String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        [XmlIgnore]
        public float secretNumber;

        [XmlArray("parts")]
        [XmlArrayItem("part")]
        public List<string> parts = new List<string>();

        public event PropertyChangedEventHandler PropertyChanged;



        public override string ToString()
        {
            return $"{name}, {health}";
        }
    }
}
