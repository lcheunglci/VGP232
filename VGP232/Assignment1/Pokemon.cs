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
        public string HP { get; set; }
        public string Attack { get; set; }
        public string Defense { get; set; }
        public string MaxCP { get; set; }

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

        /// <summary>
        /// The Pokemon string with all the properties
        /// </summary>
        /// <returns>The pokemon</returns>
        public override string ToString()
        {
            return string.Format($"{Name} - HP: {HP} Attack: {Attack} Defense {Defense} MaxCP: {MaxCP}");
        }
    }
}
