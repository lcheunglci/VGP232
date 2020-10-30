using System;
using System.Collections.Generic;
using System.Text;

namespace Week03Lib
{
    public interface IXMLSerializable
    {
        bool SaveAsXML(string fileName);
        bool LoadXML(string fileName);

    }
}
