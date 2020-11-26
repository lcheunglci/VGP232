using System;
using System.Collections.Generic;
using System.Text;

namespace Week03Lib
{
    public interface IPersistence
    {
        bool Save(string fileName);
        bool Load(string fileName);

    }
}
