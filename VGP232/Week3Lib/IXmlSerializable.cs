using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Lib
{
    public interface IXmlSerializable
    {
        bool LoadXML(string filename);
        bool SaveAsXML(string filename);
    }
}
