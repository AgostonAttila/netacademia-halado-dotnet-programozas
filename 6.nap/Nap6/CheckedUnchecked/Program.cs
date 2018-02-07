using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckedUnchecked
{
    class Program
    {
        static int Osszead(int a, int b)
        {
            return a + b;
        }

        static void Main(string[] args)
        {

            checked
            {
                int a = 1500000000;
                int b = 1500000000;
                //int c = a + b;
                unchecked
                {
                    int c = a + b;
                }
            }

            int aa = 1500000000;
            int bb = 1500000000;
            int cc = unchecked(aa + bb);
            Console.WriteLine(cc);

            checked
            {
                // metodushivasra nem ervenyes !!!
                Console.WriteLine(Osszead(1500000000,1500000000));
            }



            Console.ReadLine();
        }
    }
}
