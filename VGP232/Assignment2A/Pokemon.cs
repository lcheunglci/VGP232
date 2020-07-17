using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2A
{
    public class Pokemon
    {
        public enum PokemonType { Fire, Water
        }
        // Nat,Pokemon,HP,Atk,Def,SpA,SpD,Spe,Total
        public string Index { get; set; }
        public string Name { get; set; }
        public int HP { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpecialAttack { get; set; }
        public int SpecialDefense { get; set; }
        public int Speed { get; set; }
        public int Total { get; set; }

        public static bool TryParse(string line, out Pokemon pokemon)
        {
            pokemon = new Pokemon();
            string[] values = line.Split(',');

            // TODO: validate that the string array the size expected.
            // TODO: use int.Parse or TryParse for stats/number values.
            // Populate the properties of the pokemon
            // TODO: Add the pokemon to the list
            return true;
        }

        /// <summary>
        /// The Comparator function to check for name
        /// </summary>
        /// <param name="left">Left side Pokemon</param>
        /// <param name="right">Right side Pokemon</param>
        /// <returns> -1 (or any other negative value) for "less than", 0 for "equals", or 1 (or any other positive value) for "greater than"</returns>
        public static int CompareByPokemonName(Pokemon left, Pokemon right)
        {
            return left.Name.CompareTo(right.Name);
        }

        // TODO: add sort for each property:
        // CompareByIndex
        // CompareByPokemonHP
        // CompareByPokemonAttack
        // CompareByPokemonDefenese
        // CompareBySpecialAttack
        // CompareBySpecialDefense
        // CompareByPokemonTotal

        /// <summary>
        /// The Pokemon string with all the properties
        /// </summary>
        /// <returns>The pokemon formated string</returns>
        public override string ToString()
        {
            // TODO: construct a string to return with the following format
            // Nat,Pokemon,HP,Atk,Def,SpA,SpD,Spe,Total
            return "This is not implemented";
        }
    }
}
