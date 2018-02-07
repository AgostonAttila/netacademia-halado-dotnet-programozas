using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Finalizer
{

    class Program
    {
        class MyClass
        {
            ~MyClass()
            {
                Console.WriteLine("a finalizer lefutott");
            }
        }


        static void Main(string[] args)
        {
            MyClass mc = new MyClass();
            Console.WriteLine(GC.GetGeneration(mc));
            GC.Collect(2);
            Console.WriteLine(GC.GetGeneration(mc));
            GC.Collect(2);
            Console.WriteLine(GC.GetGeneration(mc));
            GC.Collect(2);
            Console.WriteLine(GC.GetGeneration(mc));
            mc = null;

            // specialis queue : finalizer q.

            // f-reachable queue

            GC.Collect(0);
            GC.WaitForPendingFinalizers();
            GC.Collect(1);
            GC.WaitForPendingFinalizers();
            GC.Collect(2);
            GC.WaitForPendingFinalizers();

            List<int> lista = new List<int>();
            Console.WriteLine(GC.GetGeneration(lista));
            for (int i = 0; i < 1000; i++)
            {
                Thread.Sleep(50);
                StringBuilder sb = new StringBuilder(1024);
                Console.Write(GC.GetGeneration(lista));
            }

            Console.ReadLine();
        }
    }
}
