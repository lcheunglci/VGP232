using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Week3Lib
{
    public class MonsterLoader
    {
        public Monster LoadBin(string filePath)
        {
            Monster monster = null;

            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                monster = bf.Deserialize(fs) as Monster;
            }

            return monster;
        }

        public void SaveBin(string filePath, Monster monster)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, monster);
            }
        }

        public void SaveXML(string filePath, Monster monster)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Monster));
                xs.Serialize(fs, monster);
            }
        }

        public Monster LoadXML(string filePath)
        {
            Monster monster = null;
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Monster));
                monster = xs.Deserialize(fs) as Monster;
            }
            return monster;
        }


        public void SaveListXML(string filePath, Monsters monsters)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Monsters));
                xs.Serialize(fs, monsters);
            }
        }

        public Monsters LoadListXML(string filePath)
        {
            Monsters monsters = null;
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Monsters));
                monsters = xs.Deserialize(fs) as Monsters;
            }
            return monsters;
        }

        public void SaveListJSON(string filePath, Monsters monsters)
        {
            using (StreamWriter fs = new StreamWriter(filePath))
            {
                fs.WriteLine(JsonConvert.SerializeObject(monsters, Formatting.Indented));
            }
        }

        public Monsters LoadListJSON(string filePath)
        {
            Monsters monsters = null;
            using (StreamReader fs = new StreamReader(filePath))
            {
                string data = fs.ReadToEnd();
                //monsters = JsonConvert.DeserializeObject(data) as Monsters;
                monsters = JsonConvert.DeserializeObject<Monsters>(data);
            }
            return monsters;
        }

    }
}
