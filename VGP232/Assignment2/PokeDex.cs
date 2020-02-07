using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Assignment2
{
    public class PokeDex : List<Pokemon>
    {
        void Parse(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                // skip for header
                reader.ReadLine();

                Pokemon pokemon;
                if (Pokemon.TryParse(reader.ReadLine(), out pokemon))
                {
                    this.Add(pokemon);
                }

            }
        }

        public void Load(string inputFile)
        {
            if (Path.GetExtension(inputFile) == ".json")
            {

            }
        }

        bool LoadAsXML(string filePath)
        {
            this.Clear();
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                XmlSerializer xs = new XmlSerializer(typeof(List<Pokemon>));
                var temp = (xs.Deserialize(fs) as List<Pokemon>);
                foreach (var pokemon in temp)
                {
                    this.Add(pokemon);
                }

            }
            return true;
        }
    }
}
