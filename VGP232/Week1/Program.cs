using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1
{
    class Program
    {
        static void SumNumbers()
        {
            Console.WriteLine("Enter some numbers: ");
            string input = Console.ReadLine();
            int sum = 0;
            while(!input.Equals("done", StringComparison.OrdinalIgnoreCase))
            {
                //int number = Convert.ToInt32(input);
                //int number = int.Parse(input); //" zero" || "one" != 1 throws an exception
                int number = 0;
                if (int.TryParse(input, out number))
                {
                    sum += number;
                }
                Console.WriteLine("The total is: {0}", sum);
                input = Console.ReadLine();
            }
        }

        static void WhatIsYourName()
        {

            Console.WriteLine("What is your name?");

            string name = Console.ReadLine();

            Console.Write("Welcome " + name);
            //if (name.Equals("Lawrence", StringComparison.OrdinalIgnoreCase))
            if (name.ToLower() == "lawrence")
            {
                Console.WriteLine(", Have a nice day!");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello VGP232");

            bool nameMode = false;
            bool sumMode = false;

            // Print out all the command line arguments
            for (int i = 0; i < args.Length; i++)
            {
                //Console.WriteLine(args[i]);
                if (args[i] == "-n")
                {
                    nameMode = true;
                }
                else if (args[i] == "-s")
                {
                    sumMode = true;
                }

            }

            if (nameMode)
            {
                WhatIsYourName();
            }

            if (sumMode)
            {
                SumNumbers();
            }

            Console.ReadKey();
        }
    }
}
