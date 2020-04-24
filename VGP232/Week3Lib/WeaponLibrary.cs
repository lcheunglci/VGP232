using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Week3Lib
{
    public class WeaponLibrary : List<Weapon>, IXmlSerializable
    {
        public bool LoadXML(string path)
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(List<Weapon>));
                    List<Weapon> weapons = (List<Weapon>)xs.Deserialize(fs);
                    this.Clear();
                    this.AddRange(weapons);
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool SaveXML(string path)
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(List<Weapon>));
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
