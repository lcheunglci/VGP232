using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week9.Model
{
    public class Weapon
    {
        public int Power { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name + " " + Power;
        }

    }
}
