using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week9.Model
{
    public class Character
    {
        public string Face { get; set; }
        public string Name { get; set; }
        public string Dialogue { get; set; }

        public override string ToString()
        {
            return string.Format("{0} said '{1}'", Name, Dialogue);
        }
    }
}
