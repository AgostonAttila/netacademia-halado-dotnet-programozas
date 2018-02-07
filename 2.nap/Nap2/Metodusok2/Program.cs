using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metodusok2
{

    class Homerseklet
    {
        public int T;
        public Homerseklet(int t)
        {
            this.T = t;
        }
        public static implicit operator double(Homerseklet h)
        {
            return h.T+273.15;
        }
        public static explicit operator int(Homerseklet h)
        {
            return h.T;
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            Homerseklet h = new Homerseklet(0);
            double h2 = h;
            Console.WriteLine(h2);

            int hom = (int)h;
            Console.WriteLine(hom);

            Console.ReadLine();
        }
    }
}
