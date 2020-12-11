using System;
using System.Collections.Generic;
using System.Text;

namespace Week10
{
    public class MapProject
    {
        public string Name { get; set; }
        public string TilesFolder { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }

        public int[] Map { get; set; }
    }
}
