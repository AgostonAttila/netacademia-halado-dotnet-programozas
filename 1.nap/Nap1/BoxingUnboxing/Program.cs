using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoxingUnboxing
{
    class Program
    {
        void M(object o)
        {

        }

        static void Pelda1()
        {
            int a = 5;
            object o = 5;
            a = 10;
            Console.WriteLine(a + ", " + (int)o);
        }

        static void Pelda2()
        {
            int a = 5;
            object o = 5;
            a = 10;
            Console.WriteLine(a.ToString() + ", " + o);
        }

        static void Pelda3()
        {
            int a = 5;
            Console.WriteLine("{0} {1} {2}", a, a, a);
        }

        // box, polimorfizmus ToString -> int

        // tostring
        static void Pelda4()
        {
            int a = 5;
            Console.WriteLine("{0} {1} {2}", a.ToString(), a.ToString(), a.ToString());
        }

        static void Main(string[] args)
        {
            int szam = 13;
            object o = szam;
            szam = 23;
            Console.WriteLine(szam);
            Console.WriteLine(o);

            int szam2 = (int)o;
            Console.WriteLine(szam2);


            Pelda1();

            Console.ReadLine();
        }
    }
}
