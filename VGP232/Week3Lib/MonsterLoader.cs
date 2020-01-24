using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

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
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, monster);
            }
        }

    }
}
