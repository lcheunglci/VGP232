using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week3Lib;

namespace Week3
{
    class Program
    {
        static void Main(string[] args)
        {
            Monster monster = new Monster();
            monster.name = "Rathalos";
            monster.health = 1000;
            monster.ability = Ability.Fly;
            monster.element = Element.Fire;

            MonsterLoader loader = new MonsterLoader();
            loader.SaveBin("rathalos.bin", monster);
            Console.WriteLine("Monster has been saved");

            Monster loadedMonster = loader.LoadBin("rathalos.bin");
            Console.WriteLine("Monster has been loaded");
            Console.WriteLine(loadedMonster == null ? "none" : loadedMonster.name);

            Console.ReadKey();

        }
    }
}
