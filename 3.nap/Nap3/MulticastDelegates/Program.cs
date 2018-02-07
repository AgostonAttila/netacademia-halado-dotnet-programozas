using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace MulticastDelegates
{
    class Program
    {
        delegate int Muvelet(int a, int b);
        public static Dictionary<string, string> results = new Dictionary<string, string>();

        static int Add(int a, int b)
        {
            results["+"] = "Error";
            int res = a + b;
            results["+"] = res.ToString();
            return res;
        }
        static int Substract(int a, int b)
        {
            results["-"] = "Error";
            int res = a - b;
            results["-"] = res.ToString();
            return res;
        }
        static int Divide(int a, int b)
        {
            results["/"] = "Error";
            int res = a / b;
            results["/"] = res.ToString();
            return res;
        }
        static int Modulus(int a, int b)
        {
            results["%"] = "Error";
            int res = a % b;
            results["%"] = res.ToString();
            return res;
        }
        static int Multiply(int a, int b)
        {
            results["*"] = "Error";
            int res = a * b;
            results["*"] = res.ToString();
            return res;
        }



        static void Main(string[] args)
        {
            Muvelet[] muveletek = new Muvelet[] { Add, Substract, Divide, Modulus, Multiply };
            Muvelet szamologep = (Muvelet)Delegate.Combine(muveletek);
            int a = 13;
            int b = 5;
            results.Clear();
            szamologep(a, b);
            foreach (var item in results)
            {
                Console.WriteLine("{0} {1} {2} = {3}",a,item.Key,b,item.Value);
            }

            a = 13;
            b = 0;
            results.Clear();
            try
            {
                szamologep(a, b);
            }
            catch (Exception)
            {
                Console.WriteLine("hiba van");
            }
            foreach (var item in results)
            {
                Console.WriteLine("{0} {1} {2} = {3}", a, item.Key, b, item.Value);
            }

            Console.WriteLine();
            Dictionary<string, Tuple<int, int>> mikormit = new Dictionary<string, Tuple<int, int>>();
            mikormit["Add"] = Tuple.Create(1, 1);
            mikormit["Substract"] = Tuple.Create(2, 2);
            mikormit["Divide"] = Tuple.Create(3, 3);
            mikormit["Modulus"] = Tuple.Create(4, 4);
            mikormit["Multiply"] = Tuple.Create(5, 5);

            // egyesevel bejarni
            Delegate[] lista = szamologep.GetInvocationList();
            foreach (var item in lista)
            {
                try
                {
                    a = mikormit[item.Method.Name].Item1;
                    b = mikormit[item.Method.Name].Item2;
                    int eredmeny = ((Muvelet)item)(a, b);

                }
                catch (Exception)
                {
                    Console.WriteLine("hiba volt");
                }
            }
            foreach (var item in results)
            {
                Console.WriteLine("{0} {1} {2} = {3}", a, item.Key, b, item.Value);
            }


            Console.WriteLine("Kerem A-t:");
            string sa = Console.ReadLine();
            Console.WriteLine("Kerem B-t:");
            string sb = Console.ReadLine();
            a = int.Parse(sa);
            b = int.Parse(sb);
            Console.WriteLine("Mit csinaljak veluk? Add, Substract, Multiply, Divide, Modulus");
            string muvelet = Console.ReadLine();
            MethodInfo mi = typeof(Program).GetMethod(muvelet, BindingFlags.NonPublic | BindingFlags.Static);
            if (mi == null)
            {
                Console.WriteLine("ejny ebejnye nincs ilyen muvelet");
            }
            else
            {
                Delegate m = Delegate.CreateDelegate(typeof(Muvelet), mi);
                object[] parameterek = new object[] { a, b };
                object eredmeny = m.DynamicInvoke(parameterek);
                Console.WriteLine("eredmeny= " + eredmeny);
            }

            
            Console.ReadLine();
        }
    }
}
