using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
