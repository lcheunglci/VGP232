using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Week3Lib
{
    public enum Element
    {
        Fire, Water, Wind, Shadow, Light
    }
    public class Weapon
    {


        [XmlAttribute("n")]
        public string Name { get; set; }
        public int Damage { get; set; }
        public float Range { get; set; }
        public float AttackSpeed { get; set; }
        public Element WeaponElement { get; set; }

        public Weapon()
        {

        }

        public override string ToString()
        {
            return string.Format("{0} - DMG: {1} RNG: {2} ATKSP {3}", Name, Damage, Range, AttackSpeed);
        }
    }
}
