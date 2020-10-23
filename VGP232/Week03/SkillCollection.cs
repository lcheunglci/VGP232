using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Week03
{
    [XmlRoot("SkillBook")]
    public class SkillCollection : List<Skill>, IPersistence, IXMLSerializable
    {
        public bool Load(string fileName)
        {
            string extension = Path.GetExtension(fileName);
            if (extension == ".xml")
            {
                return LoadXML(fileName);
            }
            else if (extension == ".bin")
            {
                return LoadBinary(fileName);
            }

            return false;
        }

        public bool LoadXML(string fileName)
        {
            XmlSerializer xml = new XmlSerializer(typeof(SkillCollection));
            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    this.Clear();
                    this.AddRange((SkillCollection)xml.Deserialize(reader));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        public bool LoadBinary(string fileName)
        {
            return true;
        }

        public bool Save(string fileName)
        {
            string extension = Path.GetExtension(fileName);
            if (extension == ".xml")
            {
                return SaveAsXML(fileName);
            }
            else if (extension == ".json")
            {
                return SaveAsJson(fileName);
            }
            else
            {
                return false;
            }
        }


        public bool SaveAsJson(string fileName)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    writer.Write(JsonSerializer.Serialize(this, typeof(SkillCollection)));
                    //writer.Write(JsonSerializer.Serialize<SkillCollection>(this));

                    // To load JSON call this:
                    // JsonSerializer.Deserialize(reader.ReadToEnd()) // reader is a streamreader
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool SaveAsXML(string fileName)
        {
            XmlSerializer xml = new XmlSerializer(typeof(SkillCollection));
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    xml.Serialize(writer, this);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
    }
}
