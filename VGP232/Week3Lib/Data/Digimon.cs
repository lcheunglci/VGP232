using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Week3Lib.Data
{
    public enum Evolution { Baby, Rookie, Champion, Ultimate, Mega }

    [Serializable]
    public class Digimon : IDeserializationCallback
    {
        [XmlElement] public string Name;
        [XmlAttribute] public int Strength;
        [XmlAttribute] public int Defense;
        [XmlAttribute] public int Spirit;
        [XmlAttribute] public int Wisdom;
        [XmlAttribute("spd")] public int Speed;
        [XmlAttribute] public int Charisma;
        [XmlAttribute] public int Tolerance;
        public Evolution DigiEvolution;

        //[XmlArray]
        //[XmlArrayItem]
        //List<string> MyList = new List<string>();

        [XmlIgnore]
        [NonSerialized]
        public int Damage;

        public void OnDeserialization(object sender)
        {
            CalculateDamage();
        }

        public void CalculateDamage()
        {
            Damage = Spirit * Strength;
        }

        public override string ToString()
        {
            return string.Format($"{DigiEvolution} {Name}");
        }
    }
}
