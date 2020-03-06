using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;
using System.Globalization;
using System.Threading;

namespace Week9Localization
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("zh");

            Console.WriteLine(strings.Hello);
            Console.ReadLine();
        }
    }
}
