using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2
{
    class Program
    {
        static void SuperHeroExample()
        {
            Stack<string> superheroes = new Stack<string>();
            superheroes.Push("Batman");
            superheroes.Push("Ironman");
            superheroes.Push("Spiderman");
            superheroes.Push("Thor");
            superheroes.Push("Dr. Strange");

            foreach (var hero in superheroes)
            {
                Console.WriteLine(hero);
            }

            while (superheroes.Count > 0)
            {
                Console.WriteLine(superheroes.Pop());
            }
            Console.WriteLine(superheroes.Count);
        }
        static void SuperVillianExample()
        {
            Queue<string> supervillian = new Queue<string>();
            supervillian.Enqueue("Joker");
            supervillian.Enqueue("Mandarin");
            supervillian.Enqueue("Vemon");
            supervillian.Enqueue("Loki");
            supervillian.Enqueue("Domamu");

            foreach (var hero in supervillian)
            {
                Console.WriteLine(hero);
            }
            while (supervillian.Count > 0)
            {
                Console.WriteLine(supervillian.Dequeue());
            }
            Console.WriteLine(supervillian.Count);
        }

        static void Sum(int left, int right, ref int total)
        {
            total = left + right;
        }

        static void GenerateNumber(int min, int max, out int number)
        {
            Random rand = new Random();
            number = rand.Next(min, max);
        }

        static void Sum(params int[] numbers)
        {
            int total = 0;
            foreach(int number in numbers)
            {
                total += number;
            }
            Console.WriteLine(total);
        }

        static void DoWork(bool verbose = false)
        {
            if (verbose)
            {
                Console.WriteLine("...");
            }
        }

        static void Main(string[] args)
        {
            //SuperHeroExample();
            //SuperVillianExample();

            int a = 10;
            int b = 5;
            int total = 0;
            Sum(a, b, ref total);
            Console.WriteLine(total);

            int magicNumber;
            GenerateNumber(0, 100, out magicNumber);
            Console.WriteLine(magicNumber);

            Sum(1, 2, 3, 4, 5, 6, 7, 8);

            string name = string.Format("{0} {1} {2} {3} {4}", 1, 2, 3, 4, 5);

            DoWork();

            DoWork(verbose: false);

            DoWork(false);

            //SumStuff();
            Console.ReadKey();
            //AdditionFunction();
        }

        private static void AdditionFunction()
        {
            int left = 10;
            int right = 11;
            int total = left + right;
            Console.WriteLine(total);
        }

        private static void SumStuff()
        {
            int sum = 1 + 4;
            Console.WriteLine(sum);
        }
    }
}
