using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Threading;

namespace ParallelVegrehajtasok
{
    class Program
    {
        static void Munka(int i)
        {
            Thread.Sleep(i % 31);
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId+" "+i);
        }

        static void Main(string[] args)
        {
            List<string> url = new List<string> { "a", "b", "c", "d", "e" };
            /*foreach (var item in url)
            {
                // feldolgozas
            }*/
            ParallelOptions po = new ParallelOptions();
            po.MaxDegreeOfParallelism = 2;
            Parallel.ForEach(url,po,
                u =>
                {
                    // ide jon letoltes
                    var w = new WebClient();
                    // w.DownloadString
                    Thread.Sleep(100);
                    Console.WriteLine("letoltve: "+u+" "+Thread.CurrentThread.ManagedThreadId);
                }
                );
            Console.WriteLine("vege a foreach");

            Parallel.For(0, 100, i => Munka(i));

            // metodusok
            Parallel.Invoke(() => Munka(100), () => Munka(50), () => Munka(25));


            Console.ReadLine();
        }
    }
}
