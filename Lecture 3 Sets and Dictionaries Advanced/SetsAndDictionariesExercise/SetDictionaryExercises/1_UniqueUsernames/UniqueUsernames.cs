using System;
using System.Collections.Generic;
using System.Linq;

namespace _1_UniqueUsernames
{
    class UniqueUsernames
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string,int> userNames = new Dictionary<string,int>(n);
            while (n-->0)
            {
                userNames[Console.ReadLine()] = 0;
            }

           
            foreach (var userName in userNames)
            {
                Console.WriteLine(userName.Key);
            }
        }
    }
}
