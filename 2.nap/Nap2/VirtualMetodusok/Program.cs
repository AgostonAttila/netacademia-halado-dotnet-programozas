using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirtualMetodusok
{
    class A
    {
        public virtual void VM() { Console.WriteLine("VM: A"); }
        public void M() { Console.WriteLine("M: A"); }


        public virtual void MPar (int a) { }
    }
    class B : A
    {
        public new void M() { Console.WriteLine("M: B"); }
        public override void VM() { Console.WriteLine("VM: B"); }

        public override void MPar(int valami)
        {
            base.MPar(valami);
        }

    }
    class C : B
    {
        public new void M() { Console.WriteLine("M: C"); }
        public override void VM() { Console.WriteLine("VM: C"); }
    }
    class D : C
    {
        public new void M() { Console.WriteLine("M: D"); }
        public new virtual void VM() { Console.WriteLine("VM: D"); }
    }
    class E : D
    {
        public new void M() { Console.WriteLine("M: E"); }
        public override void VM() { Console.WriteLine("VM: E"); }
    }


    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            A b = new B();
            A c = new C();
            A d = new D();
            A e = new E();

            a.M();
            b.M();
            c.M();
            d.M();
            e.M();

            a.VM();
            b.VM();
            c.VM();
            d.VM();
            e.VM();


            D dd = (D)d;
            E ee = (E)e;
            dd.VM();
            ee.VM();





            Console.ReadLine();
        }
    }
}
