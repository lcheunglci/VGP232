using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2
{
    class Program
    {
        static int Sum(int a, int b = 10)
        {
            return a + b;
        }
        
        static int Sum(int a, params int[] vaList)
        {
            int total = a;
            //for (int i = 0; i < vaList.Length; i++)
            //{
            //    total += vaList[i];
            //}

            total += vaList.Sum();
            return total;

        }

        static void Sum(int a, int b, out int total)
        {
            total = a + b;
        }

        static void RunningSum(int a, int b, ref int total)
        {
            total += a + b;
        }

        static void ComplicatedFunction(string name, int number, float speed, ref decimal cost)
        {
            // does stuff
        }

        static void Main(string[] args)
        {
            Console.WriteLine(Sum(1, 2));
            int total;
            Sum(12, 14, out total);

            int otherTotal = 0;
            RunningSum(12, 14, ref otherTotal);

            Sum(10);
            Sum(12, 12, 12, 12);
            Sum(10,12,1,33,123,1,312,321,3,123,21,321);

            Decimal specialCost = 100M;
            ComplicatedFunction(number: 5, name: "Lawrence", speed:10f,  cost: ref specialCost);

            string strNumber = "One Hundred";
            int number = 0;
            try
            {
                number = int.Parse(strNumber);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (int.TryParse(strNumber, out number))
            {
                Console.WriteLine(number);
            }
            else
            {
                Console.WriteLine("Not a integer");
            }

            Console.ReadKey();

        }
    }
}
