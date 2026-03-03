using System;
using System.Collections.Generic;
using System.Text;

namespace BOJ
{
    internal class Program1000
    {
        static void Main()
        {
            string[] args = Console.ReadLine().Split();
            int a = int.Parse(args[0]);
            int b = int.Parse(args[1]);
            Console.WriteLine(a + b);
        }
    }
}