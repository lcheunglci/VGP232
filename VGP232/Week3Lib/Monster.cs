using System;
using System.Collections.Generic;
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
    public class Monster
    {
        [XmlAttribute]
        public string name;
        public int health;
        public Ability ability;
        public Element element;

        [XmlIgnore]
        public float secretNumber;

        [XmlArray("parts")]
        [XmlArrayItem("part")]
        public List<string> parts = new List<string>();
    }
}
