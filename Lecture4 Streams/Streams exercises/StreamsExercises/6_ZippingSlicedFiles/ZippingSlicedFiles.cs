using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace _6_ZippingSlicedFiles
{
    class ZippingSlicedFiles
    {
        static List<string> partsZipList;

        static List<string> partsList;
        static void Main(string[] args)
        {
            string path = "..//..//..//..//files//";
            string sourceFile = path + "sliceMe.mp4";
            string destFile = path + "Assembled.mp4";
            int parts = 4;

            partsList = new List<string>();
            partsZipList = new List<string>();

            Slice(sourceFile, path, parts);
            Assemble(partsList, path);
        }

        static void Assemble(List<string> files, string destinationDirectory)
        {
            using (FileStream outputFile = new FileStream(destinationDirectory + "Assembled.mp4", FileMode.Create))
            {

              //  foreach(var zipped in )

                foreach (var slice in files)
                {
                   // using (GZipStream zip)

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
                    string sliceZipPath = destinationDirectory + $"Part-{i}.gz";
                    partsList.Add(slicePath);
                    partsZipList.Add(sliceZipPath);
                    using (GZipStream gz = new GZipStream(new FileStream(sliceZipPath, FileMode.Create), CompressionMode.Compress, false))
                    {
                        using (FileStream destFile = new FileStream(slicePath, FileMode.Create))
                        {
                            long processedBytes = 0;
                            while (processedBytes < size)
                            {
                                int bytesCount = readFile.Read(buffer, 0, buffer.Length);
                                if (bytesCount == 0) break;
                                destFile.Write(buffer, 0, bytesCount);
                                gz.Write(buffer, 0, bytesCount);
                                processedBytes += bytesCount;
                            }
                        }
                    }



                }
            }
        }
    }
}
