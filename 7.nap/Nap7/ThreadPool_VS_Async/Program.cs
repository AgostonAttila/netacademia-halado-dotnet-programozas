using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ThreadPool_VS_Async
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> threadid = new HashSet<int>();

            int valtozo = 0;
            int n = 1000000;
            Action a = () => { 
                Interlocked.Increment(ref valtozo);
                //if (new Random().Next(100000) == 0) Thread.Sleep(300);
                threadid.Add(Thread.CurrentThread.ManagedThreadId);
             };

            Stopwatch sw = new Stopwatch();
            sw.Restart();
            for (int i = 0; i < n; i++)
            {
                //a.BeginInvoke(null, null); // 18000 ms
                Task.Factory.StartNew(a); // 700 ms
            }
            while (valtozo != n - 1) { }
            Console.WriteLine(sw.ElapsedMilliseconds+" ms");

            System.Console.WriteLine(threadid.Count);
            

            Console.ReadLine();
        }
    }
}
