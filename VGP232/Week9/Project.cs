using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week9
{
    public class Project
    {
        public string Name { get; set; }
        public string TilesFolder { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }

        public int[] Map { get; set; }
    }
}
