using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace GyerekTaszkok
{
    class Program
    {
        static Task t;

        static void Feladat()
        {
            Console.WriteLine("Feladat: " + t.Status);
        }
        static void NehezFeladat()
        {
            Thread.Sleep(500);
            Console.WriteLine("NehezFeladat: " + t.Status);
        }

        static void Main(string[] args)
        {
            t = new Task(
                () =>
                {
                    Feladat();
                    Task.Factory.StartNew(
                        () => NehezFeladat(), TaskCreationOptions.AttachedToParent
                        );
                    Feladat();
                }
                );

            t.Start();
            Console.WriteLine("status=" + t.Status);
            Thread.Sleep(200);
            Console.WriteLine("status=" + t.Status);
            Thread.Sleep(1000);
            Console.WriteLine("status=" + t.Status);

            Console.ReadLine();
        }
    }
}
