using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week10.Model
{
    public class Skill
    {
        public string Icon { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Mana { get; set; }
        public int Damage { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - DMG {1} - MP {2}", Name, Damage, Mana);
        }
    }
}
