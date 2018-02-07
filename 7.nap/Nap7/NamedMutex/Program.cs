using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace NamedMutex
{
    class Program
    {
        static void Main(string[] args)
        {
            bool enyemamutex = false;
            using (Mutex m = new Mutex(true, "VirusIrto", out enyemamutex))
            {
                if (enyemamutex)
                {
                    Console.WriteLine("enyem a mutex");
                    //  muveletek
                    Console.ReadLine();
                    m.ReleaseMutex();
                }
                else
                {
                    Console.WriteLine("Masik peldanya fut a programnak");
                }
            }
            Console.ReadLine();
        }
    }
}
