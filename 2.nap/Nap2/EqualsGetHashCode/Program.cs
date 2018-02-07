using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace EqualsGetHashCode
{

    class Tanulo : IEquatable<Tanulo>
    {
        public int Eletkor = 0;
        public string Nev = null;

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (this.GetType() != obj.GetType()) return false;
            Tanulo t = (Tanulo)obj;
            if (!this.Nev.Equals(t.Nev)) return false;
            if (this.Eletkor != t.Eletkor) return false;
            return true;
        }

        public bool Equals(Tanulo t)
        {
            if (t == null) return false;
            if (!this.Nev.Equals(t.Nev)) return false;
            if (this.Eletkor != t.Eletkor) return false;
            return true;
        }

        public override int GetHashCode()
        {
            //return base.GetHashCode();
            // IL: CALL
            // IL: CALLVIRT (nem!)

            //return this.Nev.GetHashCode() ^ this.Eletkor;
            return this.Nev.Length ^ this.Eletkor;
        }

        public static bool operator ==(Tanulo t1,Tanulo t2)
        {
            if ((object)t1 == null || (object)t2 == null) return false;
            return t1.Equals(t2);
        }

        public static bool operator !=(Tanulo t1, Tanulo t2)
        {
            return !(t1 == t2);
        }

        /*public static bool op_Equality(Tanulo t1, Tanulo t2)
        {
            return true;
        }*/

    }

    class Program
    {
        static void Main(string[] args)
        {
            Tanulo t1 = new Tanulo { Nev = "Gipsz Jakab", Eletkor = 23 };
            Tanulo t2 = new Tanulo { Nev = "Gipsz Jakab", Eletkor = 23 };

            Dictionary<Tanulo, int> magatartas = new Dictionary<Tanulo, int>();
            magatartas[t1] = 4;
            magatartas[t2] = 5;
            Console.WriteLine("elemek szama: " + magatartas.Count);

            Console.WriteLine(t1.GetHashCode());
            Console.WriteLine(t2.GetHashCode());

            Console.WriteLine(t1.Equals(t2));
            Console.WriteLine(t1==t2);
            object o1 = t1;
            object o2 = t2;
            Console.WriteLine(object.Equals(o1, o2));
            Console.WriteLine(o1==o2);
            // IL: callvirt
            Console.WriteLine(o1.Equals(o2));

            t1.Nev = "0123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789";
            Stopwatch sw = new Stopwatch();
            sw.Restart();
            // kod
            for (int i = 0; i < 10000000; i++)
            {
                magatartas[t1] = i;
            }
            Console.WriteLine(sw.ElapsedMilliseconds+" ms");


           

            Console.ReadLine();
        }
    }
}
