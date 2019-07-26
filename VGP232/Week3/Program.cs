using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week3Lib.Data;
using Week3Lib.Loader;

namespace Week3
{
    class Program
    {
        static Digimon CreateMon(string name)
        {
            Random rand = new Random();

            Console.WriteLine("Creating Digimon...");
            Digimon mon = new Digimon
            {
                Name = name,
                Charisma = rand.Next(0, 10),
                Defense = rand.Next(0, 10),
                Speed = rand.Next(0, 10),
                Spirit = rand.Next(0, 10),
                Strength = rand.Next(0, 10),
                Tolerance = rand.Next(0, 10),
                Wisdom = rand.Next(0, 10),
                DigiEvolution = (Evolution)rand.Next((int)Evolution.Baby, (int)Evolution.Mega)
            };

            mon.CalculateDamage();

            return mon;
        }

        static void SaveMon(Digimon mon)
        {
            Console.WriteLine("Saving...");
            DigiLoader loader = new DigiLoader();
            loader.Save(mon, mon.Name + ".data");
            Console.WriteLine("Done.");
        }

        static void SaveMon(List<Digimon> mons)
        {
            Console.WriteLine("Saving...");
            DigiLoader loader = new DigiLoader();
            loader.SaveCollection(mons, "digimons.data");
            Console.WriteLine("Done.");
        }

        static void LoadMon(string name)
        {
            Console.WriteLine("Loading Digimon...");
            DigiLoader loader = new DigiLoader();
            Digimon mon = loader.Load(name + ".data");
            Console.WriteLine(mon);
            Console.WriteLine("Done.");
        }

        static void LoadAllMon(string name)
        {
            Console.WriteLine("Loading Digimon...");
            DigiLoader loader = new DigiLoader();
            List<Digimon> mons = loader.LoadCollection(name + ".data");
            foreach (var mon in mons)
            {
                Console.WriteLine(mon);
            }
            Console.WriteLine("Done.");
        }

        static void Generate()
        {
            string[] names = new string[4] { "Agumon", "Angemon", "Hudiemon", "Culumon" };

            List<Digimon> digimons = new List<Digimon>();
            foreach (var name in names)
            {
                digimons.Add(CreateMon(name));
            }

            SaveMon(digimons);
        }

        static void Main(string[] args)
        {
            //Generate();
            //LoadAllMon("digimons");

            DigiLoader digiLoader = new DigiLoader();

            // Loading XML
            // Digimon mon = digiLoader.LoadXML("Agumon.xml");
            Digimon mon = digiLoader.LoadJSON("Agumon.json");
            Console.WriteLine(mon);

            // saving XML
            //digiLoader.SaveXML(CreateMon("Agumon"), "Agumon.xml");
            //digiLoader.SaveJSON(CreateMon("Agumon"), "Agumon.json");
            //LoadMon();

            Console.ReadKey();
        }
    }
}
