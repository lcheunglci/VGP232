using System;
using System.Collections.Generic;

namespace Week02
{
    class Program
    {
        static int SumMulti(params int[] numbers)
        {
            int total = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                total += numbers[i];
            }
            return total;
        }

        static int Sum(int[] numbers)
        {
            int total = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                total += numbers[i];
            }
            return total;
        }

        static int Sum(int left, int right = 11) // default value of 11
        {
            // left = 11;

            return left + right;
        }

        static void Sum(int left, int right, out int total)
        {
            total = left + right;
        }

        static void RunningSum(int left, ref int total)
        {
            total += left;
        }

        static void SetConfiguration(bool fullScreenEnabled, int width, int height)
        {
            Console.WriteLine("Configuration set");
        }

        static void Main(string[] args)
        {
            //for (int i = 0; i < args.Length; i++)
            //{
            //    // string.Format("{0} --- {0} {1}", 1, 2);
            //    Console.WriteLine("args[{0}] = {1}", i, args[i]);
            //}

            //FunctionExamples();

            List<int> numbers = new List<int>();
            numbers.Add(123);
            numbers.Add(223);
            numbers.Add(323);
            numbers.Add(423);
            numbers.Add(623);
            numbers.RemoveAt(4);

            for (int i = 0; i < numbers.Count; i++)
            {
                Console.WriteLine(numbers[i]);
            }

            List<string> names = new List<string>(){ "HaoRu", "Rodrigo", "Jaime" };
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

            Dictionary<int, string> hotelRooms = new Dictionary<int, string>();
            hotelRooms[100] = "Bruce";
            hotelRooms[102] = "Joe";
            hotelRooms[200] = "Jenny";
            hotelRooms[201] = "Mark";

            foreach (var kvp in hotelRooms)
            {
                Console.WriteLine("Room: {0} ---- Occupant: {1}", kvp.Key, kvp.Value);
            }
        }

        private static void FunctionExamples()
        {
            Console.WriteLine("Hello Week2!");

            int num1 = 10;
            int num2 = 8;

            //int total = Sum(num1, num2);

            // Console.WriteLine(num1);
            //Console.WriteLine(total);

            int newTotal;
            Sum(num1, num2, out newTotal);

            Console.WriteLine(newTotal);

            int newTotal2 = 12;
            RunningSum(num1, ref newTotal2);
            RunningSum(num1, ref newTotal2);
            RunningSum(num1, ref newTotal2);
            Console.WriteLine(newTotal2);

            int[] numbers = new int[] { 1, 2, 3, 4, 5, 5, 6, 778, 100 };
            int newTotal3 = Sum(numbers);

            int newTotal4 = SumMulti(1, 2, 3, 45, 6, 76, 7, 87);

            Console.WriteLine(Sum(2));

            SetConfiguration(width: 100, height: 200, fullScreenEnabled: false);
        }
    }
}
