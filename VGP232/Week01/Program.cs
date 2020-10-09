using System;

namespace Week1
{
    // This is my project to show.
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Add a name.
            string name = "Lawrence";

            Console.WriteLine(name);

            Console.WriteLine("What is your favorite number?");
            string favNum = Console.ReadLine();
            try
            {
                int favInt = int.Parse(favNum);
                if (favInt == 9)
                {
                    Console.WriteLine("That's awesome!");
                }
                else
                {
                    Console.WriteLine("Cool.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("That is not a number. Good bye!");
            }
        }
    }
}
