using System;
using System.IO;

namespace _1_OddLines
{
    class OddLines
    {
        static void Main(string[] args)
        {
            string path = "..//..//..//..//files//";
            using (StreamReader sr = new StreamReader(path + "text.txt"))
            {
                var line = sr.ReadLine();
                int counter = 0;
                while (line != null)
                {

                    if (counter % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }
                    counter++;

                    line = sr.ReadLine();
                }
            }
        }
    }
}

