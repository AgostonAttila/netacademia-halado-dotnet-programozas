using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;

namespace Properties
{
    class Dolgozo
    {

        public string Nev
        {
            get { return nev; }
            set { nev = value; }
        }

        /*public string get_Nev()
        {
            return this.nev;
        }*/

        public int Eletkor
        {
            get { return eletkor; }
            set
            {
                if (value >= 0)
                    eletkor = value;
                else throw new ArgumentOutOfRangeException();
            }
        }

        public string Jelszo
        {
            private get { return jelszo; }
            set { jelszo = value; }
        }

        public string Monogram
        {
            get { return this.Nev.Substring(0, 1) + this.Eletkor; }
        }

        public int Fizetes { get; set; }

        private string nev;
        private int eletkor;
        private string jelszo;
    }

    class Osztaly
    {
        public List<string> Tanulok
        {
            get { return tanulok; }
        }
        public Dictionary<string, int> Jegyek
        {
            get { return jegyek; }
        }

        List<string> tanulok = new List<string>();
        Dictionary<string, int> jegyek = new Dictionary<string, int>();
    }


    class Program
    {

        public static dynamic GetAnononimObject()
        {
            return new { Nev = "Aladar", SzuletesiEv = 1991 };
        }

        public static Tuple<int, int> GetMinMax(params int[] szamok)
        {
            // if szamok.Length==0
            int min = szamok[0];
            int max = szamok[0];
            for (int i = 0; i < szamok.Length; i++)
            {
                min = Math.Min(min, szamok[i]);
                max = Math.Max(max, szamok[i]);
            }
            return Tuple.Create<int, int>(min, max);
        }

        static void Main(string[] args)
        {
            Dolgozo d = new Dolgozo { Nev = "Gipsz Jakab", Eletkor = 23, Jelszo = "Dodo", Fizetes = 250000 };
            // Console.WriteLine(d.Jelszo);
            Console.WriteLine(d.Nev);
            // d.Eletkor = -3;

            Console.WriteLine(d.Monogram);
            Console.WriteLine(d.Fizetes);

            Osztaly o = new Osztaly { Tanulok = { "Aladar", "Bela" }, Jegyek = { { "Aladar", 1 }, { "Bela", 2 } } };
            //o.Tanulok = new List<string>();

            // anonymous tipusok
            var o1 = new { Nev = "Gipsz Jakab", SzuletesiEv = 1999 };
            var o2 = new { Nev = "Gipsz Jakab", SzuletesiEv = 1999 };

            // o1.Nev = "ssss"; // CTE
            Console.WriteLine(o1);
            Console.WriteLine(o2);

            Console.WriteLine(o1.Equals(o2));
            Console.WriteLine(o1.GetHashCode());
            Console.WriteLine(o2.GetHashCode());
            Console.WriteLine(o1 == o2);
            Console.WriteLine(object.ReferenceEquals(o1, o2));

            Console.WriteLine(o1.GetType());
            Console.WriteLine(o2.GetType());


            var o4 = GetAnononimObject();
            Console.WriteLine(o4.GetType());
            // Console.WriteLine(o4.Nev); // property nev???
            Console.WriteLine(o4.Nev);
            // DynamicInvoke()


            var o3 = new { SzuletesiEv = 1999, Nev = "Gipsz Jakab" };
            Console.WriteLine(o3.GetType());


            var specianonymousobjektum = new { Elsoelem = o1, Masodikelem = o2 };
            Console.WriteLine(specianonymousobjektum.GetType());
            var specianonymousobjektumtomb = new[] { o1, o2 };

            var minmax = GetMinMax(13, 14, 2, 3, 7, 9);
            Console.WriteLine(minmax.Item1);
            Console.WriteLine(minmax.Item2);
            Console.WriteLine(minmax);


            dynamic din = new ExpandoObject();
            din.X = 12;
            din.Y = 13;
            Console.WriteLine(din.X);

            foreach (var item in (IDictionary<string, object>)din)
            {
                Console.WriteLine(item);
            }
            // eltavolitas: remove

            Console.ReadLine();

        }
    }
}
