using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Szalak
{
    class Ember
    {
        public string Nev;
        public int Eletkor;
    }

    class Program
    {
        static Ember Jakab = new Ember { Nev = "Gipsz Jakab", Eletkor = 23 };
        static object kapu = new object();

        static void Metodus()
        {
            Console.WriteLine("Metodus  start");
            lock (kapu)
            {
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(100);
                    Console.WriteLine("modositom az embert");
                    Jakab.Nev += ".";
                }
            }
            Console.WriteLine("Metodus end");
        }

        static void Main(string[] args)
        {

            for (int i = 0; i < 3; i++)
            {
                ThreadStart ts = new ThreadStart(Metodus);
                Thread t = new Thread(ts);
                t.Start();
            }

            Console.ReadLine();
        }
    }
}
