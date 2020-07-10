using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello VGP232!");

            // std::vector<std::string>
            List<string> names = new List<string>() { "Lawrence", "Peter" };
            names.Add("Nelson");
            names.Add("Ken");
            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine("Name: {0}.", names[i]);
            }

            // std::string[]
            string[] heroes = new string[] { "Spiderman", "Batman", "Superman" };
            heroes[0] = "Ironman";

            int total = 0;
            List<Student> students = new List<Student>();
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine("Args[{0}]: {1}.", i, args[i]);
                if (args[i] == "gg")
                {
                    Console.WriteLine("Good Game!!");
                }

                if (args[i] == "123" || args[i] == "111")
                {
                    int number = int.Parse(args[i]);
                    total += number;
                }

                if (args[i] == "-i")
                {
                    int next = i + 1;
                    if (next < args.Length)
                    {
                        
                        string filename = args[next];
                        using (StreamReader reader = new StreamReader(filename))
                        {
                            reader.ReadLine();

                            while(reader.Peek() > 0)
                            {
                                string line = reader.ReadLine();
                                string[] elements = line.Split(',');

                                if (elements.Length > 1)
                                {
                                    Student s = new Student();
                                    s.Name = elements[0];
                                    s.Id = elements[1];

                                    students.Add(s);
                                }
                            }
                        }
                    }
                }
            }

            // Don't do this.
            // Console.WriteLine(students); // System.List<Student>

            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine(students[i]);
            }

            Console.WriteLine("The total is {0}", total);

            Console.ReadKey();
        }
    }
}
