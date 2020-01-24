using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Week3Lib
{

    [XmlRoot("Monsters")]
    public class Monsters : List<Monster>, IXmlSerializable
    {
        public bool LoadXML(string path)
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(Monsters));
                    this.Clear();
                    this.AddRange(xs.Deserialize(fs) as Monsters);
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool SaveAsXML(string path)
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(Monsters));
                    xs.Serialize(fs, this);
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

    }
}
