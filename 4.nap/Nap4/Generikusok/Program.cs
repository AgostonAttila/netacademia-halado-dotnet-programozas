using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Diagnostics;

namespace Generikusok
{
    class Program
    {
        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        static void Swap(ref object a, ref object b)
        {
            object temp = a;
            a = b;
            b = temp;
        }

        static void Main(string[] args)
        {

            int a = 10;
            int b = 20;
            Swap(ref a, ref b);
            Console.WriteLine(a+", "+b);
            /*double x = 1;
            double y = 2;
            Swap(ref x, ref y);*/

            int n = 10000000;
            long kezdetimeret = GC.GetTotalMemory(true);
            List<int> lista = new List<int>();
            Stopwatch sw = new Stopwatch();
            sw.Restart();
            for (int i = 0; i < n; i++)
            {
                lista.Add(i);
            }
            Console.WriteLine(sw.ElapsedMilliseconds);
            long vegsomeret = GC.GetTotalMemory(true);
            Console.WriteLine(vegsomeret-kezdetimeret);

            kezdetimeret = GC.GetTotalMemory(true);
            ArrayList list = new ArrayList();
            sw.Restart();
            for (int i = 0; i < n; i++)
            {
                list.Add(i);
            }
            Console.WriteLine(sw.ElapsedMilliseconds);
            vegsomeret = GC.GetTotalMemory(true);
            Console.WriteLine(vegsomeret - kezdetimeret);

            


            Console.ReadLine();
        }
    }
}
