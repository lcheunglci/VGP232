using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Lib
{
    public class Weapon
    {
        public string Name { get; set; }
        public int Damage { get; set; }

        public int AttackSpeed { get; set; }

        public float Range { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}", 
                Name, Damage, AttackSpeed, Range);
        }

    }
}
