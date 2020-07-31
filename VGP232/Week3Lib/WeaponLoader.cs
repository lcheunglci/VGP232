using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Week3Lib
{
    public class WeaponLoader : List<Weapon>, IXmlSerializable
    {
        XmlSerializer serializer;

        public WeaponLoader()
        {
            serializer = new XmlSerializer(typeof(List<Weapon>));
        }

        public bool LoadXML(string filename)
        {
            bool success = false;

            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {

                List<Weapon> temp = serializer.Deserialize(fs) as List<Weapon>;
                if (temp != null)
                {
                    this.Clear();
                    this.AddRange(temp);
                }

                success = true;
            }

            return success;
        }

        public List<Weapon> GetAllWeaponsOfElement(Element element)
        {
            List<Weapon> elementWeapons = new List<Weapon>();
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].WeaponElement == element)
                {
                    elementWeapons.Add(this[i]);
                }
            }
            return elementWeapons;
        }

        public bool SaveAsXML(string filename)
        {
            bool success = false;

            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                serializer.Serialize(fs, this);
                success = true;
            }

            return success;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.Count; i++)
            {
                sb.AppendLine(this[i].ToString());
            }
            return sb.ToString();
        }
    }
}
