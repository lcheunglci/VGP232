using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2
{
    class Program
    {
        // A
        static void Sum(int left = 0, int right = 0, int total = 0)
        {
            total = left + right;
            Console.WriteLine(total);
        }

        // B
        static void Sum(int left, int right, ref int total)
        {
            total = left + right;
            Console.WriteLine(total);
        }


        static void SumOut(int left, int right, out int total)
        {
            total = left + right;
            Console.WriteLine(total);
        }

        static void Sum(int a, int b, params int[] numbers)
        {
            int total = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                total += numbers[i];
            }
            Console.WriteLine(total);
        }

        //static void Sum(int[] numbers)
        //{
        //    int total = 0;
        //    for (int i = 0; i < numbers.Length; i++)
        //    {
        //        total += numbers[i];
        //    }
        //    Console.WriteLine(total);
        //}


        static void Main(string[] args)
        {

            Sum();

            int l = 10;
            int r = 15;
            // throw new Exception("Barf");

            try
            {
                throw new Exception("Barf");
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            int total; // = 0;
            SumOut(l, r, out total);
            Console.WriteLine(total);
            Console.ReadKey();
            int a = 11;
            int b = 99;
            int c = 56;

            Sum(l, r, a, b, c, 1, 23, 2);
            int[] nums = new int[5] { 1, 2, 3, 4, 5 };
            //Sum(nums);


        }
    }
}
