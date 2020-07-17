using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2
{
    class Program
    {
        static int Sum(int left, int right = 10)
        {
            return left + right;
        }


        static int Sum(int[] a)
        {
            int total = 0;
            for (int i = 0; i < a.Length; i++)
            {
                total += a[i];
            }
            return total;
        }


        static int Sum(int a, int b, params int[] c)
        {
            int total = a + b;
            for (int i = 0; i < c.Length; i++)
            {
                total += c[i];
            }
            return total;
        }

        static void Main(string[] args)
        {
            int some = Sum(right:1 , left:2);
            int total = Sum(10, 20,1,2,3,43,45,56);
            Console.WriteLine(total);

        }
    }
}
