using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Week1
{
    public class Reader
    {
        List<string> lines = new List<string>();

        public Reader(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                while (reader.Peek() > 0)
                {
                    lines.Add(reader.ReadLine());
                }
            }
        }

        public void PrintAll()
        {
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
        }

    }
}
