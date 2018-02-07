using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

// virag@chem.elte.hu

namespace Szemafor
{
    class Program
    {
        static Semaphore penztargep;

        static void Main(string[] args)
        {
            penztargep = new Semaphore(0, 3);
            for (int i = 0; i < 10; i++)
            {
                Thread t = new Thread(new ParameterizedThreadStart(DolgozoSzal));
                t.Start(i);
            }
            Console.WriteLine("lathatoan minden penztar teli");
            Thread.Sleep(1000);
            penztargep.Release(3);

            Console.ReadLine();
        }

        static void DolgozoSzal(object szam)
        {
            penztargep.WaitOne();
            int sz = (int)szam;
            Console.WriteLine("Szam: "+sz);
            Thread.Sleep(1000);
            Console.WriteLine("vegzett a dolgozo: "+sz);
            penztargep.Release();
        }

    }
}
