using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week3Lib;

using Newtonsoft.Json;
using System.IO;

namespace Week3
{
    class Program
    {
        static void Main(string[] args)
        {
            //string myFile = "somefilename.xml";

            //string fileExtension = Path.GetExtension(myFile);
            //if (fileExtension == ".xml")
            //{
            //    //LoadXml(path);
            //}
            //Console.WriteLine(fileExtension);

            JsonExamples();

            //SaveWeapons();
            //LoadWeapons();

            Console.ReadKey();
        }

        private static void JsonExamples()
        {
            Weapon weapon = new Weapon();
            weapon.Name = "Sword";
            weapon.Damage = 100;
            weapon.Range = 2.4f;
            weapon.AttackSpeed = 4;

            // Saving
            string json = JsonConvert.SerializeObject(weapon);
            using (StreamWriter writer = new StreamWriter("weapons.json"))
            {
                writer.Write(json);
            }

            // Loading
            
            using (StreamReader reader = new StreamReader("weapons.json"))
            {
                string data = reader.ReadToEnd();
                Weapon loadedWeapon = JsonConvert.DeserializeObject<Weapon>(data);
                Console.WriteLine(loadedWeapon);
            }
        }

        private static void LoadWeapons()
        {
            WeaponLibrary weaponLib = new WeaponLibrary();
            bool result = weaponLib.LoadXML("weapons.xml");
            if (result)
            {
                Console.WriteLine("Successfully loaded.");
                for (int i = 0; i < weaponLib.Count; i++)
                {
                    Console.WriteLine(weaponLib[i]);
                }
            }
            else
            {
                Console.WriteLine("Failed to load.");
            }
        }

        static void SaveWeapons()
        {
            Weapon weapon = new Weapon();
            weapon.Name = "Sword";
            weapon.Damage = 100;
            weapon.Range = 2.4f;
            weapon.AttackSpeed = 4;

            Weapon weapon2 = new Weapon();
            weapon2.Name = "Axe";
            weapon2.Damage = 200;
            weapon2.Range = 2.0f;
            weapon2.AttackSpeed = 2;

            WeaponLibrary weaponLib = new WeaponLibrary();
            weaponLib.Add(weapon);
            weaponLib.Add(weapon2);

            bool result = weaponLib.SaveXML("weapons.xml");
            if (result)
            {
                Console.WriteLine("Successfully saved.");
            }
            else
            {
                Console.WriteLine("Failed to save.");
            }
        }
    }
}
