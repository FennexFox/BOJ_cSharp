// 최단경로 (https://www.acmicpc.net/problem/1753)
// tier: Gold 4
// tags: Graph, Shortest Path, Dijkstra

using System;
using System.Collections.Generic;
using System.IO;

namespace BOJ
{
    internal class Program1753
    {
        static StreamReader sr = new StreamReader(Console.OpenStandardInput());
        static StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

        static void Main()
        {
            string[] args = sr.ReadLine().Split();
            int nodes = int.Parse(args[0]);
            int edges = int.Parse(args[1]);
            int root = int.Parse(sr.ReadLine());

            List<(int node, int value)>[] graph = new List<(int node, int value)>[nodes + 1];
            int[] distances = new int[nodes + 1];

            for (int i = 1; i <= nodes; i++)
            {
                graph[i] = new List<(int node, int value)>();
                distances[i] = int.MaxValue;
            }

            for (int i = 1; i <= edges; i++)
            {
                args = sr.ReadLine().Split();
                int nodeStart = int.Parse(args[0]);
                int nodeEnd = int.Parse(args[1]);
                int distance = int.Parse(args[2]);

                graph[nodeStart].Add((nodeEnd, distance));
            }

            distances[root] = 0;
            PriorityQueue<(int node, int value), int> queue = new PriorityQueue<(int node, int value), int>();
            queue.Enqueue((root, 0), 0);

            while (queue.Count > 0)
            {
                (int currentNode, int currentDistance) = queue.Dequeue();
                foreach ((int nextNode, int nextDistance) in graph[currentNode])
                {
                    int newDistance = currentDistance + nextDistance;
                    if (distances[nextNode] > newDistance)
                    {
                        distances[nextNode] = newDistance;
                        queue.Enqueue((nextNode, newDistance), newDistance);
                    }
                }
            }

            for (int i = 1; i <= nodes; i++)
            {
                string value = distances[i] == int.MaxValue ? "INF" : distances[i].ToString();
                sw.WriteLine(value);
            }

            sr.Close();
            sw.Close();
        }
    }
}
