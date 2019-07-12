using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine(args[i]);
                if (args[i] == "-i")
                {
                    int nextIndex = i + 1;
                    string filePath = args[nextIndex];
                    Console.WriteLine(filePath);
                }
            }

            //foreach (var arg in args)
            //{
            //    Console.WriteLine(arg);
            //}

            Console.WriteLine("Hello world");
            Console.ReadKey();
        }
    }
}
