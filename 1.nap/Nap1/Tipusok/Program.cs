using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tipusok
{
    class Program
    {
        class A
        {
            public static int MaxValami = 100;
            public int PeldanyMezo;
            public void MA() { }
        }

        class B : A
        {
            public int PeldanyMezoB;
            public void MB(int p) { }
            public void MB2(int p, int p2) { }
        }

        class SajatRef { public int X; }
        struct SajatVal { public int X; }

        struct SajatValExtra
        { 
            public int X;
            public int[] tomb;
            public string s;
        }

        static void Main(string[] args)
        {
            // stack: 1MB
            // heap
            // A tipus objektum: type pointer (System.Type), sync blokk, statikus mezoket, 
            //    metodusok definicio
            // B tipus objektum: type pointer (System.Type), sync blokk, statikus mezoket, 
            //    metodusok definicio

            A a = new A();
            // A peldany jon letre a heap-en: type pointer (Tipusok.Program.A)
            //  sync blokk, peldany szintu mezok
            // stack-en is letrejon a valtozo (8byte) mutato a heap-re

            A a2 = null; // strack-en, csak nem mutat sehova

            B b = new B();
            // B peldany jon letre a heap-en: type pointer (Tipusok.Program.B)
            //  sync blokk, peldany szintu mezok
            // stack-en letrejon egy b

            a.MA();
            b.MB(1);
            b.MB2(2,3);

            // milyen tipusok vannak
            // value type: mindig stack, referencia type: heap-en
            // primitive type: int, bool, double, decimal (string NEM!)
            // System.Int32

            Int32 int32 = new Int32();
            int int32_ = 0;
            string s = "";

            Console.WriteLine("Int: "+typeof(int).IsPrimitive);
            Console.WriteLine("String: " + typeof(string).IsPrimitive);
            Console.WriteLine("Bool: " + typeof(bool).IsPrimitive);

            // value type: int, bool, double, char, DateTime, Guid, Point
            SajatRef sr = new SajatRef(); // stack-en sr (ptr=8459) + gomboc a heapen
            SajatVal sv = new SajatVal(); // csak stack : 5
            sr.X = 5;
            sv.X = 5;
            Console.WriteLine(sr.X);
            Console.WriteLine(sv.X);

            SajatRef sr2 = sr;  // stack sr2 (ptr=8459)
            SajatVal sv2 = sv;  // stack : 5
            //Console.WriteLine(sr.X);
            //Console.WriteLine(sv.X);
            sr.X = 10;
            sv.X = 11;
            Console.WriteLine(sr2.X);
            Console.WriteLine(sv2.X);


            SajatValExtra sve = new SajatValExtra();
            sve.X = 5;
            sve.tomb = new int[] { 1,2,3,4 };
            sve.s = "alma";
            // stack: 4byte: X, 8byte: tombreferencia
            SajatValExtra sve2 = sve;
            Console.WriteLine(sve2.X);
            Console.WriteLine(sve2.tomb[0]);

            sve.X = 10;
            sve.tomb[0] = 123;
            sve.s = "korte";
            Console.WriteLine(sve2.X);
            Console.WriteLine(sve2.tomb[0]);
            Console.WriteLine(sve2.s);

            Console.ReadLine();
        }
    }
}
