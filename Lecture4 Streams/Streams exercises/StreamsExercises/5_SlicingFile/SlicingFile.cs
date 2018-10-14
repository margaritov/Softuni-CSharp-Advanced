using System;
using System.Collections.Generic;
using System.IO;

namespace _5_SlicingFile
{
    class SlicingFile
    {
        static List<string> partsList;
        static void Main(string[] args)
        {
            string path = "..//..//..//..//files//";
            string sourceFile = path + "sliceMe.mp4";
            string destFile = path + "Assembled.mp4";
            int parts = 4;

            partsList = new List<string>();
            Slice(sourceFile, path, parts);
            Assemble(partsList, path);
        }

        static void Assemble(List<string> files, string destinationDirectory)
        {
            using (FileStream outputFile = new FileStream(destinationDirectory + "Assembled.mp4", FileMode.Create))
            {
                foreach (var slice in files)
                {
                    using (FileStream readFile = new FileStream(slice, FileMode.Open))
                    {
                        byte[] buffer = new byte[readFile.Length];
                        while (true)
                        {
                            int bytesRead = readFile.Read(buffer, 0, buffer.Length);
                            if (bytesRead == 0) break;
                            outputFile.Write(buffer, 0, bytesRead);
                        }
                    }
                }
            }
        }

        static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            using (FileStream readFile = new FileStream(sourceFile, FileMode.Open))
            {
                long size = (long)Math.Ceiling((double)readFile.Length / parts);
                byte[] buffer = new byte[4096];
                for (int i = 0; i < parts; i++)
                {
                    string slicePath = destinationDirectory + $"Part-{i}.mp4";
                    partsList.Add(slicePath);
                    using (FileStream destFile = new FileStream(slicePath, FileMode.Create))
                    {
                        long processedBytes = 0;
                        while (processedBytes < size)
                        {
                            int bytesCount = readFile.Read(buffer, 0, buffer.Length);
                            if (bytesCount == 0) break;
                            destFile.Write(buffer, 0, bytesCount);
                            processedBytes += bytesCount;
                        }
                    }
                }
            }
        }
    }
}
