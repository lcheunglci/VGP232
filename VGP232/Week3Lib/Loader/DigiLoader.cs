using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week3Lib.Data;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Week3Lib.Loader
{
    public class DigiLoader
    {
        public Digimon Load(string filePath)
        {
            Digimon digimon = null;
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                digimon = bf.Deserialize(fs) as Digimon;
            }

            return digimon;
        }

        public Digimon LoadXML(string filePath)
        {
            Digimon digimon = null;
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Digimon));
                digimon = serializer.Deserialize(fs) as Digimon;
            }

            return digimon;
        }

        public Digimon LoadJSON(string filePath)
        {
            Digimon digimon = null;
            using (StreamReader reader = new StreamReader(filePath))
            {
                digimon = JsonConvert.DeserializeObject<Digimon>(reader.ReadToEnd());
            }

            return digimon;
        }

        public List<Digimon> LoadCollection(string filePath)
        {
            List<Digimon> digimons = new List<Digimon>();
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                digimons = bf.Deserialize(fs) as List<Digimon>;
            }
            return digimons;
        }

        public void Save(Digimon mon, string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, mon);
            }
        }

        public void SaveXML(Digimon mon, string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Digimon));
                serializer.Serialize(fs, mon);
            }
        }

        public void SaveJSON(Digimon mon, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(JsonConvert.SerializeObject(mon));
            }
        }

        public void SaveCollection(List<Digimon> mons, string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, mons);
            }
        }
    }
}
