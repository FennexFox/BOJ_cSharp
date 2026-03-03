using System;
using System.Collections.Generic;

namespace BOJ
{
    internal class Program28064
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var names = new List<string>(n);
            for (int i = 0; i < n; i++) names.Add(Console.ReadLine());

            int count = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    int minL = Math.Min(names[i].Length, names[j].Length);
                    bool matched = false;
                    for (int k = 1; k <= minL; k++)
                    {
                        var sufI = names[i].AsSpan(names[i].Length - k, k);
                        var preJ = names[j].AsSpan(0, k);
                        if (sufI.SequenceEqual(preJ)) { matched = true; break; }

                        var sufJ = names[j].AsSpan(names[j].Length - k, k);
                        var preI = names[i].AsSpan(0, k);
                        if (sufJ.SequenceEqual(preI)) { matched = true; break; }
                    }
                    if (matched) count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}