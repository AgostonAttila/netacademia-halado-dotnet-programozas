using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enums
{
    class Program
    {
        enum Szinek
        {
            Feher, Piros, Zold, Kek // 0,1,2,3
        }
        enum Szinek2
        {
            Feher = 0,
            White = 0,
            Piros = 1,
            Red = 1,
            Zold = 2,
            Green = 2
        }

        [Flags]
        enum Muvelet
        {
            Read = 1,
            Write = 2,
            Delete = 4,
            Query = 8,
            Sync = 16,
            ReadWrite = Muvelet.Read | Muvelet.Write,
            SzinkronTorles = Delete | Sync
        }


        static void Main(string[] args)
        {

            Szinek sz = Szinek.Zold;
            Console.WriteLine(sz);
            Console.WriteLine((int)sz);
            Console.WriteLine(Enum.GetUnderlyingType(typeof(Szinek)));

            Szinek2 sz2 = (Szinek2)1;
            Console.WriteLine(sz2);


            System.Console.WriteLine((int)Muvelet.Query);

            foreach (var item in Enum.GetValues(typeof(Muvelet)))
            {
                Console.WriteLine((int)(Muvelet)item + " " + (Muvelet)item);
            }

            Muvelet m = Muvelet.Read | Muvelet.Write;
            Console.WriteLine(m);
            Console.WriteLine((int)m);

            m = Muvelet.Write | Muvelet.Sync;
            Console.WriteLine(m);
            Console.WriteLine((int)m);

            m = Muvelet.SzinkronTorles;
            Console.WriteLine(m);
            Console.WriteLine((int)m);

            Console.ReadLine();
        }
    }
}
