using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Week03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Week3!");
            // string fileName = "skill.bin";
            // SaveSkill(fileName);
            // LoadSkill(fileName);


            // string savedFile = "skillbook.xml";
            string savedFile = "skillbook.json";

            SkillCollection sc = new SkillCollection()
            { 
                new Skill() { Name = "Fireball",Cost=5, Modifier=10  },
                new Skill() { Name = "IceBolt",Cost=3, Modifier=7  },
                new Skill() { Name = "LightningBolt",Cost=15, Modifier=40  },
                new Skill() { Name = "ShadowBall",Cost=50, Modifier=1000  },
                new Skill() { Name = "Bite",Cost=1, Modifier=99  },
            };

            sc.Save(savedFile);


            Console.WriteLine("Done");
        }

        private static void LoadSkill(string fileName)
        {
            
            FileStream fs = new FileStream(fileName, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            Skill loadedSkill = (Skill)bf.Deserialize(fs);
            Console.WriteLine(loadedSkill);
        }

        private static void SaveSkill(string fileName)
        {
            Skill skill1 = new Skill() { Name = "Fireball", Cost = 5, Modifier = 10 };

            FileStream fs = new FileStream(fileName, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, skill1);
            fs.Close();
        }
    }
}
