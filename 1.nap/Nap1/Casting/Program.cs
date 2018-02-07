using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Casting
{
    class A { }
    class B : A { }

    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            B b = new B();
            A ab = new B();
            object o = ab;
            ab = (A)o;
            // b = (B)a;

            // 1. megoldas
            if (o is B)
            {
                Console.WriteLine("igen o B tipusu");
                B peldany = (B)o;
                Console.WriteLine(peldany.ToString());
            }

            // 2. megoldas
            B p = o as B;
            if (p != null)
            {
                Console.WriteLine("igen o B tipusu");
            }

            // 3. megoldas 
            // try - catch
            object[] olist = new object[1000];
            for (int i = 0; i < olist.Length; i++)
            {
                if (i % 2 == 0) olist[i] = new A(); else olist[i] = new B();
            }


            Stopwatch sw = new Stopwatch();
            int siker = 0, hiba = 0;
            sw.Restart();
            for (int i = 0; i < olist.Length; i++)
            {
                try
                {
                    B bb = (B)olist[i];
                    siker++;
                }
                catch (Exception)
                {
                    hiba++;
                }
            }
            Console.WriteLine(sw.ElapsedMilliseconds + " ms");


            sw.Restart();
            siker = 0;
            hiba = 0;
            for (int i = 0; i < olist.Length; i++)
            {
                B bb = olist[i] as B;
                if (bb == null) hiba++; else siker++;
            }
            Console.WriteLine(sw.ElapsedMilliseconds + " ms");


            // ArrayList
            // generikus 

            Console.ReadLine();
        }
    }
}
