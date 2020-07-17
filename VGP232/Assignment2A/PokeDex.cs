using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2A
{
    public class PokeDex : List<Pokemon>, IPeristence
    {
        public bool Load(string filename)
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                // Skip the first line because header does not need to be parsed.
                // Nat,Pokemon,HP,Atk,Def,SpA,SpD,Spe,Total
                string header = reader.ReadLine();

                // The rest of the lines looks like the following:
                // 1,Bulbasaur,45,49,49,65,65,45,318
                while (reader.Peek() > 0)
                {
                    Pokemon pokemon = null;
                    if (Pokemon.TryParse(reader.ReadLine(), out pokemon))
                    {
                        this.Add(pokemon);
                    }
                    // TODO: validate that the string array the size expected.
                    // TODO: use int.Parse or TryParse for stats/number values.
                    // Populate the properties of the pokemon
                    // TODO: Add the pokemon to the list
                }
            }
            throw new NotImplementedException();
        }

        public bool Save(string filename)
        {
            FileStream fs;

            //if (appendToFile && File.Exists((outputFile)))
            //{
            //    fs = File.Open(outputFile, FileMode.Append);
            //}
            //else
            //{
            //    fs = File.Open(outputFile, FileMode.Create);
            //}

            using (StreamWriter writer = new StreamWriter(filename))
            {
                // Hint: use writer.WriteLine
                // TODO: use the writer to output the results.
            }

            return true;
        }

        Pokemon GetHighestDefense()
        {
            throw new NotImplementedException();
        }

        Pokemon GetHighestAttack()
        {
            throw new NotImplementedException();
        }

        Pokemon GetHighestHp()
        {
            throw new NotImplementedException();
        }
        Pokemon GetHighestSpeed()
        {
            throw new NotImplementedException();
        }
        Pokemon GetHighestTotal()
        {
            throw new NotImplementedException();
        }
        Pokemon GetHighestSpecialAttack()
        {
            throw new NotImplementedException();
        }
        Pokemon GetHighestSpecialDefense()
        {
            throw new NotImplementedException();
        }
        
        List<Pokemon> GetAllPokemonOfType(PokemonType type)
        {
            throw new NotImplementedException();
        }
        void SortBy(string columnName)
        {
            throw new NotImplementedException();
        }

    }
}
