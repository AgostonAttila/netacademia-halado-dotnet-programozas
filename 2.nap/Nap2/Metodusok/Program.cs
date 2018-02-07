using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.CompilerServices;

namespace Metodusok
{
    class A
    {
        public int X = -1;

        public A(int x)
        {
            this.X = x;
            Console.WriteLine("A ctor");
        }
    }

    class B : A
    {
        public int Y = -1;
        public B()
            : base(0)
        {
            Console.WriteLine("B ctor");
        }
    }

    class ReferenciaTipus
    {
        public readonly static int EuroForintArfolyam;

        static ReferenciaTipus()
        {
            Console.WriteLine("ReferenciaTipus static ctor");
            // adatbazis, webservice
            // lassu
            //throw new Exception("baj van");
            Thread.Sleep(2000);
            EuroForintArfolyam = 295;
        }
    }

    struct ErtekTipus
    {
        static ErtekTipus()
        {
            Allando = 273;
            Console.WriteLine("ErtekTipus static ctor");
        }
        public static int Allando;
        public static void StaticMethod()
        {

        }
        public int X;
    }


    class Program
    {
        static void Main(string[] args)
        {
            //RuntimeTypeHandle th = typeof(ReferenciaTipus).TypeHandle;
            RuntimeHelpers.RunClassConstructor(typeof(ReferenciaTipus).TypeHandle);
            RuntimeHelpers.RunClassConstructor(typeof(ReferenciaTipus).TypeHandle);

            A a = new A(1);
            B b = new B();

            Console.WriteLine(ReferenciaTipus.EuroForintArfolyam);

            ReferenciaTipus rt = new ReferenciaTipus();

            ErtekTipus et = new ErtekTipus();
            Console.WriteLine(ErtekTipus.Allando);


            Console.ReadLine();
        }
    }
}
