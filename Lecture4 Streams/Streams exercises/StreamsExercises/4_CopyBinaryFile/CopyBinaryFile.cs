using System;
using System.IO;

namespace _4_CopyBinaryFile
{
    class CopyBinaryFile
    {
        static void Main(string[] args)
        {
            string path = "..//..//..//..//files//";
            using (FileStream source = new FileStream(path + "copyme.png", FileMode.Open))
            {
                using (FileStream destFile = new FileStream(path + "copyMe-copy.png", FileMode.Create))
                {
                    var size = source.Length;
                    byte[] buffer = new byte[4096];

                    while (true)
                    {
                        int bytesRead = source.Read(buffer, 0, buffer.Length);
                        if (bytesRead == 0)
                        {
                            break;
                        }
                        destFile.Write(buffer, 0, bytesRead);
                    }
                }
            }
        }
    }
}
