using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Lib
{
    public enum Element { Normal, Fire, Water, Wind, Light, Shadow };
    public class Weapon
    {
        public string Name { get; set; }
        public int Damage { get; set; }

        public int AttackSpeed { get; set; }

        public float Range { get; set; }

        public Element WeaponElement { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}, {4}", 
                Name, Damage, AttackSpeed, Range, WeaponElement);
        }

    }
}
