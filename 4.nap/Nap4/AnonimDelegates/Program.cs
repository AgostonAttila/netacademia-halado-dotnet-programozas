using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnonimDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = new int[] { 1, 2, 6, 5, 7, 13, 9, 11, 3, 2 };
            int e;

            e = Array.Find(input, delegate(int sz) { return sz % 3 == 0; });
            // FindAll
            Console.WriteLine(e);
            e = Array.FindIndex(input, x => x % 3 == 0);
            // Array.FindLastIndex
            Console.WriteLine(e);
            Console.WriteLine(Array.TrueForAll(input, x => x > 0));
            string[] s = Array.ConvertAll(input, x => "=" + x.ToString());
            Array.ForEach(s, delegate(string elem) { Console.WriteLine(elem); });

            
            Console.ReadLine();
        }
    }
}
