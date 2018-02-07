using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Konstansok
{
    class Program
    {
        class Sajat
        {
            public const int Size = 100;
            public const string Name = "IT Factory";
            // public const Random veletlen = null;

            public static readonly int MaxSize = 1000;
            public static readonly Random Veletlen = new Random(1);
            public static readonly List<string> Honapok =
                 new List<string>() { "Januar", "Februar", "stb" };

            public static readonly ReadOnlyCollection<string> Months =
                new ReadOnlyCollection<string>(Honapok);

            public readonly string Nev = "ismeretlen kolto";
            public Sajat(string nev)
            {
                this.Nev = nev;
            }
        }


        static void Main(string[] args)
        {

            // Sajat.Honapok = new List<string>(); // CTE
            
            Sajat.Honapok[0]="January";
            Sajat.Honapok.Add("December");

            // Sajat.Months[0] = "jan";

            Console.ReadLine();
        }
    }
}
