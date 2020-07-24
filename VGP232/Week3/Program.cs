using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Week3
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a file: ");
            string filename = Console.ReadLine();
            Console.WriteLine("Would you like to load or save?");
            string choice = Console.ReadLine();
            bool save = string.Equals(choice, "save", StringComparison.OrdinalIgnoreCase);

            Weapon axe = new Weapon()
            {
                AttackSpeed = 2,
                Damage = 10,
                Name = "Axe",
                Range = 1
            };

            Weapon sword = new Weapon()
            {
                AttackSpeed = 3,
                Damage = 6,
                Name = "Sword",
                Range = 2
            };

            List<Weapon> weapons = null;
            WeaponLoader weaponLoader = new WeaponLoader();

            weaponLoader.Add(axe);
            weaponLoader.Add(sword);
            if (Path.GetExtension(filename).ToLower() == ".xml")
            {
                if (save)
                {
                    weaponLoader.SaveAsXML(filename);
                }
                else
                {
                    weaponLoader.LoadXML(filename);
                    Console.WriteLine(weaponLoader);
                }
            }
            else if (Path.GetExtension(filename).ToLower() == ".json")
            {
                if (save)
                {
                    SaveAsJson(weaponLoader, filename);
                    
                }
                else
                {
                    LoadJSON(out weapons, filename);
                    for (int i = 0; i < weapons.Count; i++)
                    {
                        Console.WriteLine(weapons[i]);
                    }
                }
            }
            

            //weaponLoader.SaveAsXML("weapons.xml");

            //weaponLoader.LoadXML("weapons.xml");




            //SaveAsJson(axe, "Axe.json");
            //Weapon weapon2 = null;
            //LoadJSON(out weapon2, "Axe.json");
            //Console.WriteLine(weapon2 == null ? "No data loaded" : weapon2.ToString());

            //Console.WriteLine(weaponLoader);
            Console.ReadKey();
        }


        public static void SaveAsJson(List<Weapon> weapons, string filename)
        {
            string jsonData = JsonConvert.SerializeObject(weapons, Formatting.Indented);
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.Write(jsonData);
            }
        }

        public static void LoadJSON(out List<Weapon> weapons, string filename)
        {
            weapons = null;
            using (StreamReader reader = new StreamReader(filename))
            {
                string jsonData = reader.ReadToEnd();
                weapons = JsonConvert.DeserializeObject<List<Weapon>>(jsonData);
            }
        }
    }
}
