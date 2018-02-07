using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirtualFromCtor
{

    class Szemely
    {
        public string Nev = null;
        public Szemely()
        {
            this.Nev = "Szemely";
            this.Show(); // ilyet ne csinaljunk
        }

        public virtual void Show()
        {
            Console.WriteLine("Szemely::Show");
            Console.WriteLine("Nev = " + this.Nev);
        }
    }

    class Tanulo : Szemely
    {
        public int[] Osztalyzatok = null;
        public Tanulo()
        {
            this.Nev = "Tanulo";
            this.Osztalyzatok = new int[] { 4, 2, 5 };
        }

        public override void Show()
        {
            Console.WriteLine("Tanulo::Show");
            Console.WriteLine("Nev = " + this.Nev);
            Console.WriteLine("Osztalyzatok");
            for (int i = 0; i < this.Osztalyzatok.Length; i++)
            {
                Console.WriteLine(this.Osztalyzatok[i]);
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Tanulo t = new Tanulo();

            Console.ReadLine();
        }
    }
}
