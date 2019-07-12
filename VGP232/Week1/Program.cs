using System;

namespace Week1
{
    class Program
    {
        enum CharacterType { Warrior = 0, Archer, Paladin, Knight}

        static void Example1()
        {
            int number = 10;
            char letter = 'c';
            float pi = 3.14f;
            double preciseNumber = 1.321321321321;
            CharacterType character = CharacterType.Warrior;

            Console.Write("number is ");
            Console.WriteLine(number);
            Console.WriteLine("{0} {1} {2} {3}", 
                number, letter, pi, preciseNumber);
            Console.WriteLine(character);
            Console.WriteLine($"{pi} text text text {letter}");
            Console.WriteLine(pi.ToString() + letter.ToString() + "other string" );

            // Using string
            string name = "   Lawrence   ";
            Console.WriteLine(name[2]);
            // name[0] = 'j';
            Console.WriteLine(name);
            Console.WriteLine(name.TrimStart());
            Console.WriteLine(name.ToUpper());
            Console.WriteLine(name.Substring(6));
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Hello VGP232 Class!");

            //Example1();
            //Example2();
            //int total = Sum(1,2);
            //Example3();

            Reader myReader = new Reader("data.txt");
            myReader.PrintAll();

            Console.ReadKey();
        }

        private static int Sum(int left, int right)
        {
            return left + right;
        }

        private static void Example2()
        {
            Console.WriteLine("Enter your name");
            string input = Console.ReadLine();

            if (input == "Lawrence")
            {
                Console.WriteLine($"Welcome to the class, {input}");
            }
            else if (input == "Justin")
            {
                Console.WriteLine($"Nice to see you again {input}");
            }
            else
            {
                Console.WriteLine($"Hello {input}");
            }
            //bool myCondition = false;
        }

        static void Example3()
        {
            string[] names = new string[] { "Lawrence", "Rena", "Allen" };

            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine(names[i]);
            }

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

            int count = 10;
            while (count > 0)
            {
                Console.WriteLine(count);
                count--;

                if (count == 5)
                {
                    break;
                }
                else if (count%2 == 0)
                {
                    Console.WriteLine("...");
                }
                else
                {
                    continue;
                }

                Console.Write("next");
            }
        }

    }
}
