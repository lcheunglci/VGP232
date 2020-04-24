using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2A
{
    public class Pokemon
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int MaxCP { get; set; }

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

        public static int CompareByPokemonHP(Pokemon left, Pokemon right)
        {
            return left.HP.CompareTo(right.HP);
        }

        // TODO: add sort for each property i.e. CompareByPokemonHP, CompareByPokemonAttack, CompareByPokemonDefenese, CompareByPokemonMaxCP

        /// <summary>
        /// The Pokemon string with all the properties
        /// </summary>
        /// <returns>The pokemon formated string</returns>
        public override string ToString()
        {
            // TODO: construct a string to return with the following format
            // Name: Bob - HP: 123 Attack: 123 Defense: 123 MaxCP: 123"
            return "TODO: ...";
        }
    }
}
