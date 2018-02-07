using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace BeepitettInterfeszek
{
    class Program
    {
        class Ember : IEquatable<Ember>
        {
            public string nev;
            public int eletkor;
            public bool Equals(Ember other)
            {
                return this.nev.Equals(other.nev) && this.eletkor.Equals(other.eletkor);
            }
        }

        static void Valami<T>() where T : IList<T>, new()
        {
            T v = new T();
        }


        class BejarhatoBetuk : IEnumerable<char>
        {

            public IEnumerator<char> GetEnumerator()
            {
                return new Betuk();
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return new Betuk();
            }
        }


        class Betuk : IEnumerator<char>
        {
            int pozicio = -1;
            char[] lista = new char[] { 'A', 'B', 'C' };

            public char Current
            {
                get
                {
                    return lista[pozicio];
                }
            }

            public void Dispose()
            {

            }

            object System.Collections.IEnumerator.Current
            {
                get { return Current; }
            }

            public bool MoveNext()
            {
                pozicio++;
                return pozicio < lista.Length;
            }

            public void Reset()
            {
                pozicio = -1;
            }
        }


        class Tanulo : ICloneable
        {
            public string Name;
            public int Eletkor;
            public int[] jegyek = new int[5];
            public override string ToString()
            {
                string res = Name + " " + Eletkor + " - ";
                for (int i = 0; i < 5; i++)
                    res += " " + jegyek[i];
                return res;
            }

            public Tanulo SajatClone()
            {
                return (Tanulo)this.MemberwiseClone();
            }

            public object Clone()
            {
                Tanulo t = new Tanulo();
                t.Name = Name;
                t.Eletkor = Eletkor;
                //t.jegyek = new int[this.jegyek.Length];
                //Array.Copy(this.jegyek, t.jegyek, this.jegyek.Length);
                t.jegyek = (int[])this.jegyek.Clone();
                return t;
            }
        }


        static T[] ArrayClone<T>(T[] lista) where T : class,ICloneable, new()
        {
            return null;
        }


        class Homerseklet : IFormattable
        {
            public int T;
            public string ToString(string format, IFormatProvider formatProvider)
            {
                // "{0:valami} {1}"
                if (formatProvider == null)
                    formatProvider = CultureInfo.CurrentCulture;
                if (String.IsNullOrEmpty(format)) format = "C";
                if (format.ToUpper() == "K")
                    return String.Format(formatProvider, "{0} Kelvin", T + 273.15);
                else
                    return String.Format(formatProvider, "{0} Celsius", T);
            }
        }


        static void Main(string[] args)
        {

            foreach (var item in new BejarhatoBetuk())
            {
                Console.WriteLine(item);
            }

            Tanulo t1 = new Tanulo();
            t1.Eletkor = 23;
            t1.Name = "Gipsz Jakab";
            t1.jegyek = new int[] { 1, 4, 2, 5, 2 };

            // referencia masolas
            Tanulo t2 = t1;

            t2.Name = "ifj Gipsz Jakab";
            Console.WriteLine(t1);
            Console.WriteLine(t2);

            // shallow copy
            t2 = t1.SajatClone();
            t2.Eletkor = 56;
            t2.Name = "idosebb Gipsz Jakab";
            t2.jegyek[0] = 5;
            Console.WriteLine(t1);
            Console.WriteLine(t2);


            // deep copy
            t2 = (Tanulo)t1.Clone();
            t2.Eletkor = 56;
            t2.Name = "idosebb Gipsz Jakab";
            t2.jegyek[0] = 0;
            Console.WriteLine(t1);
            Console.WriteLine(t2);

            Homerseklet h = new Homerseklet { T = 25 };
            Console.WriteLine("{0:C}", h);
            Console.WriteLine("{0:K}", h);

            Console.ReadLine();
        }
    }
}
