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
            monster.parts.Add("tail");
            monster.parts.Add("head");
            monster.parts.Add("claws");

            Monster monster2 = new Monster();
            monster2.name = "Zinorge";
            monster2.health = 1000;
            monster2.ability = Ability.Climb;
            monster2.element = Element.Lightning;
            monster2.parts.Add("horn");
            monster2.parts.Add("claws");

            Monsters monsters = new Monsters();
            monsters.Add(monster);
            monsters.Add(monster2);
            JSONFormat(monsters);
            //XMLFormat(monsters);

            //XMLFormat(monster);
            //BinaryFormat(monster);

            Console.ReadKey();

        }

        private static void BinaryFormat(Monster monster)
        {
            MonsterLoader loader = new MonsterLoader();
            loader.SaveBin("rathalos.bin", monster);
            Console.WriteLine("Monster has been saved");

            Monster loadedMonster = loader.LoadBin("rathalos.bin");
            Console.WriteLine("Monster has been loaded");
            Console.WriteLine(loadedMonster == null ? "none" : loadedMonster.name);
        }

        private static void XMLFormat(Monster monster)
        {
            MonsterLoader loader = new MonsterLoader();
            loader.SaveXML("rathalos.xml", monster);
            Console.WriteLine("Monster has been saved");

            Monster loadedMonster = loader.LoadXML("rathalos.xml");
            Console.WriteLine("Monster has been loaded");
            Console.WriteLine(loadedMonster == null ? "none" : loadedMonster.name);
        }

        private static void XMLFormat(Monsters monsters)
        {
            MonsterLoader loader = new MonsterLoader();
            loader.SaveListXML("monsters.xml", monsters);
            Console.WriteLine("Monster has been saved");

            Monsters loadedMonsters = loader.LoadListXML("monsters.xml");
            Console.WriteLine("Monster has been loaded");
            for (int i = 0; i < loadedMonsters.Count; i++)
            {
                Console.WriteLine(monsters[i].name);
            }
        }

        private static void JSONFormat(Monsters monsters)
        {
            MonsterLoader loader = new MonsterLoader();
            loader.SaveListJSON("monsters.json", monsters);
            Console.WriteLine("Monster has been saved");

            Monsters loadedMonsters = loader.LoadListJSON("monsters.json");
            Console.WriteLine("Monster has been loaded");
            for (int i = 0; i < loadedMonsters.Count; i++)
            {
                Console.WriteLine(monsters[i].name);
            }
        }

    }
}
