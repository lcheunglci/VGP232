﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week01
{
    public class Student
    {
        public string Name { get; set; }
        public string Id { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Name, Id);
        }
    }
}
