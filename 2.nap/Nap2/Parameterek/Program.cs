using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parameterek
{
    class Program
    {
        /*public static void RefValMethod(int a, int[] tomb)
        {
            a = 10;
            //tomb[0] = 10;
            tomb = new int[] { 10 };
            Console.WriteLine(a + " , " + tomb[0]);
        }*/
        public static void RefValMethod(ref int a, ref int[] tomb)
        {
            a = 10;
            //tomb[0] = 10;
            tomb = new int[] { 10 };
            Console.WriteLine(a + " , " + tomb[0]);
        }

        public static void OutMethod(int a, out int dupla)
        {
            // Console.WriteLine(dupla);
            // int.TryParse()
            dupla = a * 2;
            Console.WriteLine(dupla);
        }

        public void M(int a) { }
        //public void M(ref int a) { }
        public void M(out int a)
        {
            try
            {
                a = 1;
            }
            catch (Exception)
            {
                //a = 2;
                throw;
            }
            finally
            {
                a = 3;
            }
        }
        public void M(string a) { }


        public static int add(params int[] ertekek)
        {
            int sum = 0;
            if (ertekek != null)
                for (int i = 0; i < ertekek.Length; i++)
                {
                    sum += ertekek[i];
                }
            return sum;
        }

        /*public static int add(params object[] kulcsok,int szam)
        {
            return 0;
        }*/


        public static void DefMethod(int x = 0, string s = "unknow",
                       DateTime datum = default(DateTime), Guid guid = new Guid(), Random random = null,
            params int[] szamok)
        {
            Console.WriteLine("x={0} s={1} datum={2} guid={3} random={4}", x, s, datum, guid, random);
        }

        public static void M2(ref int a, ref int b)
        {
        }

        public class SakkTabla
        {
            public string this[int sor = 1, int oszlop = 1]
            {
                get
                {
                    Console.WriteLine("soroszlop: " + sor + " " + oszlop);
                    return "gyalog";
                }
            }
        }



        static void Main(string[] args)
        {
            int szam = 0;
            int[] tomb = new int[] { 1, 2, 3 };  // tomb : 5424698 heap cimre
            Console.WriteLine(szam + " , " + tomb[0]);
            RefValMethod(ref szam, ref tomb);
            // RefValMethod(ref 12, ref tomb);

            Console.WriteLine(szam + " , " + tomb[0] + " " + tomb.Length);
            int b, ketszeres;
            OutMethod(13, out ketszeres);
            Console.WriteLine(ketszeres);

            Console.WriteLine(add(1, 2, 3));
            Console.WriteLine(add(1));
            Console.WriteLine(add(1, 2));
            Console.WriteLine(add(new int[] { 1, 2, 3, 4 }));
            Console.WriteLine(add());
            Console.WriteLine(add(null));

            DefMethod();
            DefMethod(566);
            DefMethod(23, "alma");
            DefMethod(5, guid: Guid.NewGuid(), datum: DateTime.Now);
            DefMethod(szamok: new int[] { 1, 2, 3 });

            int szamlalo = 0;
            DefMethod(szamlalo++, (szamlalo++).ToString());
            Console.WriteLine(szamlalo);
            DefMethod(s: (szamlalo++).ToString(), x: szamlalo++);
            int x = 0, y = 0;
            M2(ref x, ref y);
            M2(b: ref x, a: ref y);

            SakkTabla st = new SakkTabla();

            Console.WriteLine(st[1, 5]);
            Console.WriteLine(st[3]);
            Console.WriteLine(st[oszlop: 3]);
            // Console.WriteLine(st[]);

            Console.ReadLine();
        }
    }
}
