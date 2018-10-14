using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _7_DirectoryTraversal
{
    class DirectoryTraversal
    {

        static void Main(string[] args)
        {
            var directoryInfo = new Dictionary<string, Dictionary<string, decimal>>();

            string[] files = Directory.GetFiles("..//..//..//..//", "*.*", SearchOption.TopDirectoryOnly);
            foreach (var file in files)
            {
                var currentFile = File.Open(file, FileMode.Open);
                var fullName = Path.GetFileName(file);
                var extension = Path.GetExtension(file);
                var fileSize = Decimal.Divide(currentFile.Length, 1024);
                if (!directoryInfo.ContainsKey(extension))
                {
                    directoryInfo.Add(extension, new Dictionary<string, decimal>());
                }

                if(!directoryInfo[extension].ContainsKey(fullName))
                {
                    directoryInfo[extension].Add(fullName, fileSize);
                }

                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\report.txt";

                using (StreamWriter sw = new StreamWriter(path))
                    foreach(var kvp in directoryInfo.OrderByDescending( x => x.Value.Count).ThenBy(k=>k.Key))
                    {
                        sw.WriteLine(kvp.Key);
                        foreach(var fileInfo in kvp.Value.OrderBy(x=>x.Value))
                        {
                            sw.WriteLine($"--{fileInfo.Key} {fileInfo.Value:F2}kb");
                        }
                    }
                    Console.WriteLine(file);
            }


        ;
        }
    }
}
