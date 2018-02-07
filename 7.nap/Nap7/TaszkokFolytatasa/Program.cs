using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TaszkokFolytatasa
{
    class Program
    {
        static int Szamol(int n) {
            Console.WriteLine("ThreadID: "+Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(500);
            int sum=0;
            for (int i = 0; i <= n; i++)
                sum += i;
            return sum;
        }

        static void Main(string[] args)
        {
            Task<int> t = new Task<int>(
                () => { Console.WriteLine("eloszamitas"); Thread.Sleep(2000); return 100; }
                );

            Task<int> t1 = t.ContinueWith<int>(
                task => { Console.WriteLine("t1"); int e = Szamol(task.Result); return e; }
                );
            Task<int> t2 = t.ContinueWith<int>(
                task => { Console.WriteLine("t2"); int e = Szamol(task.Result/2); return e; }
                );
            Task<int> t3 = t.ContinueWith<int>(
                task => { Console.WriteLine("t3"); int e = Szamol(task.Result/4); return e; }
                );

            Task<int> tfinish = Task.Factory.ContinueWhenAll(
                new Task<int>[] { t1, t2, t3 },
                tasks => {
                    Console.WriteLine("tfinish");
                    int sum = 0;
                    foreach (var item in tasks)
                    {
                        sum += item.Result;
                    }
                    return sum;
                }
                );

            t.Start();
            Console.WriteLine(t1.Result);
            Console.WriteLine(t2.Result);
            Console.WriteLine(t3.Result);

            Console.WriteLine(tfinish.Result);

            Console.ReadLine();
        }
    }
}
