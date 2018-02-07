using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadPoolPelda
{
    class Program
    {
        static void Metodus(object o)
        {
            Console.WriteLine("ez a thread pool-ban hajtodik vegre");
            Thread.Sleep(1000);
            Console.WriteLine("vegrehajtodott");
        }

        static void Main(string[] args)
        {
            /*ThreadPool.SetMaxThreads(1, 300);
            ThreadPool.QueueUserWorkItem(Metodus);
            ThreadPool.QueueUserWorkItem(o => { Console.WriteLine("lamba kifejezes 1"); });
            ThreadPool.QueueUserWorkItem(o => { Console.WriteLine("lamba kifejezes 2"); });*/

            ThreadPool.SetMaxThreads(2, 300);
            ManualResetEvent mre = new ManualResetEvent(false);
            ThreadPool.QueueUserWorkItem(o => { Console.WriteLine("1"); mre.WaitOne(); });
            ThreadPool.QueueUserWorkItem(o => { Console.WriteLine("2"); mre.WaitOne(); });
            ThreadPool.QueueUserWorkItem(o => { Console.WriteLine("3"); mre.Set(); });

            Console.WriteLine("foprogram");

            Console.ReadLine();
        }
    }
}
