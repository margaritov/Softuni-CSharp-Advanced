using System;
using System.IO;

namespace _2_LineNumbers
{
    class LineNumbers
    {
        static void Main(string[] args)
        {
            string path = "..//..//..//..//files//";
            using (StreamReader sr = new StreamReader(path + "text.txt"))
            {
                using (StreamWriter sw = new StreamWriter(path + "output.txt"))
                {
                    var line = sr.ReadLine();
                    int counter = 1;
                    while (line != null)
                    {
                        sw.WriteLine($"Line {counter++}:{line}");
                        line = sr.ReadLine();
                    }
                }
            }
        }
    }
}
