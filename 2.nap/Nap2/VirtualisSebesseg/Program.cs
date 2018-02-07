using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace VirtualisSebesseg
{
    class A
    {
        public static int Darab = 0;
        public virtual void VM() { Darab++; }
        public void M() { Darab++;  }
    }
    class B : A
    {
        public override void VM()
        {
            Darab++;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            int size = 10000000;
            A[] tomb = new A[size];
            for (int i = 0; i < size; i++)
            {
                tomb[i] = new B();
            }


            Stopwatch sw = new Stopwatch();
            sw.Restart();
            for (int i = 0; i < size; i++)
            {
                tomb[i].M();
            }
            Console.WriteLine(sw.ElapsedMilliseconds+" ms");

            sw.Restart();
            for (int i = 0; i < size; i++)
            {
                tomb[i].VM();
            }
            Console.WriteLine(sw.ElapsedMilliseconds + " ms");

            Console.ReadLine();
        }
    }
}
