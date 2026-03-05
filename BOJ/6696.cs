using System;
using System.Collections.Generic;
using System.IO;

namespace BOJ
{
    internal class Program6696
    {
        static readonly StreamReader sr = new(Console.OpenStandardInput());
        static readonly StreamWriter sw = new(Console.OpenStandardOutput());
        const double denomConverted = 50 / Math.PI;

        static void Main()
        {
            string? line;
            while ((line = sr.ReadLine()) is not null)
            {
                String[] args = line.Split();
                double a = double.Parse(args[0]);
                double b = double.Parse(args[1]);

                if (a == 0 && b == 0) {break;}
                
                double areaConverted = (Math.Pow(a, 2) + Math.Pow(b, 2))/2;
                double hours = Math.Ceiling(areaConverted/denomConverted);
                sw.WriteLine($"The property will be flooded in hour {hours}.");
            }

            sw.Flush();
        }
    }
}
