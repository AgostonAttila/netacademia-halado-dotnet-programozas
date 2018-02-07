using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NullableTipus
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;
            //Console.WriteLine(a);

            Nullable<int> szam = 5;
            int? szam2 = null;

            Console.WriteLine(szam.HasValue);
            Console.WriteLine(szam2.GetValueOrDefault(13));

            int sz = (int)szam;
            Console.WriteLine(sz);

            int? x = 5;
            int? y = null;
            int? e = x + y;

            if (!e.HasValue) Console.WriteLine("E=null");

            Console.ReadLine();
        }
    }
}
