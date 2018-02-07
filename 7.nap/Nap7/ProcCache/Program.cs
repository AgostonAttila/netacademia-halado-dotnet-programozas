using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace ProcCache
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 20000000;
            int[] e = new int[n];
            int[] idx1 = new int[n];
            int[] idx2 = new int[n];
            Random r = new Random();
            for (int i = 0; i < n; i++)
            {
                e[i] = r.Next(100);
                idx1[i] = i;
                idx2[i] = i;
            }
            for (int i = 0; i < n; i++)
            {
                int pos1 = r.Next(n);
                int pos2 = r.Next(n);
                int puff = idx2[pos1];
                idx2[pos1] = idx2[pos2];
                idx2[pos2] = puff;
            }

            Stopwatch sw = new Stopwatch();
            sw.Restart();
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                //sum += e[idx1[i]]; // 148 ms
                sum += e[idx2[i]]; // 813 ms
            }
            Console.WriteLine(sw.ElapsedMilliseconds+" ms");



            Console.ReadLine();
        }
    }
}
