using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
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

        public static int CompareByPokemonMaxCp(Pokemon left, Pokemon right)
        {
            return left.MaxCP.CompareTo(right.MaxCP);
        }

        /// <summary>
        /// The Pokemon string with all the properties
        /// </summary>
        /// <returns>The pokemon</returns>
        public override string ToString()
        {
            return string.Format($"{Name} - HP: {HP} Attack: {Attack} Defense {Defense} MaxCP: {MaxCP}");
        }

        //public static bool TryParse(string line, out Pokemon pok)
        //{
        //    pok = new Pokemon();
        //    // split 
        //    // initialize a pokemon
        //    // set the values
        //}
    }
}
