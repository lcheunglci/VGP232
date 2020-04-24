using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2A
{
    public class PokeDex : List<Pokemon>, IPeristence
    {
        List<Pokemon> mPokemons;

        public bool Load(string filename)
        {
            try
            {
                //this.Add()
                //
            } 
            catch (Exception ex)
            {
                return false;
            }
            // Implementation
            return true;
        }

        public bool Save(string filename)
        {
            throw new NotImplementedException();
        }
    }
}
