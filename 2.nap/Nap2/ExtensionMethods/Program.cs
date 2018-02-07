using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtensionMethods
{
    static class SajatExtensionMethods
    {
        public static int IndexOf(this StringBuilder sb,char c) {
            for (int i = 0; i < sb.Length; i++)
            {
                if (sb[i] == c) return i;
            }
            return -1;
        }

        // felulcspani nem lehet
        public static string ToString(this object o)
        {
            return "LOG: " + o.ToString();
        }

        // compiler intenziv
        public static string ToString2(this object o)
        {
            return "LOG: " + o.ToString();
        }

        public static void ShowItems<T>(this IEnumerable<T> kollekcio)
        {
            foreach (var item in kollekcio)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder("abcdefgh");

            //SajatExtensionMethods.IndexOf(sb, 'd');
            Console.WriteLine(sb.IndexOf('d'));

            Random r = new Random();

            "ABCD".ShowItems();
            new int[] { 1, 2, 4, 3, 1 }.ShowItems();

            int a = 25;

            Console.WriteLine(r.ToString());

            Console.ReadLine();
        }
    }
}
