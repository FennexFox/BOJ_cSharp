using System;
using System.Collections.Generic;
using System.Text;

namespace BOJ
{
    internal class Program16495
    {
        static void Main()
        {
            string s = Console.ReadLine();
            int converted = 0;

            foreach (char ch in s)
            {
                converted *= 26;
                converted += Convert.ToInt32(ch) - 64;
            }

            Console.WriteLine(converted);
        }
    }
}
