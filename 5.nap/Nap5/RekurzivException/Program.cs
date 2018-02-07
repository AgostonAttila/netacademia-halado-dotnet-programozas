using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace RekurzivException
{
    class Program
    {
        static Random r = new Random();
        static int Rekurziv(int melyseg, int esely)
        {
            if (melyseg == 1)
            {
                try
                {
                    return 100000000 / r.Next(0, esely);
                }
                catch (Exception)
                {
                    //...
                    throw;
                }
            }
            else
            {
                try
                {
                    return Rekurziv(melyseg - 1, esely);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        static void Main(string[] args)
        {
            long sum = 0;
            int ex_darab = 0;
            Stopwatch sw = new Stopwatch();
            sw.Restart();
            for (int i = 0; i < 1000; i++)
            {
                try
                {
                    sum += Rekurziv(7, 100);
                }
                catch (Exception)
                {
                    ex_darab++;
                }

            }
            Console.WriteLine("ido = " + sw.ElapsedMilliseconds);
            Console.WriteLine("ex_darab = " + ex_darab);
            // 1:100
            // 7, 660ms       7, 5100
            // 8, 710ms       8, 6600

            // 1:20
            // 7, 3400ms
            // 8, 3500ms

            // int.TryParse

            //File.Exists()
            //StreamReader sr = new StreamReader("file.txt");

            

            checked
            {
                int a = 1500000000;
                int b = 1500000000;
                int c = a + b;
                Console.WriteLine(a + b);
            }

            Console.ReadLine();
        }
    }
}
