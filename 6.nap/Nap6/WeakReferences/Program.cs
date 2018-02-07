using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace WeakReferences
{
    class Program
    {
        public static WeakReference Dataweakref = new WeakReference(null, false);

        public static List<int> Adatok
        {
            get
            {
                if (Dataweakref.IsAlive) Console.WriteLine("LIVE");
                else Console.WriteLine("DEAD");

                List<int> Datastrongref = Dataweakref.Target as List<int>;
                if (Datastrongref == null)
                {
                    Datastrongref = new List<int>();
                    Random r = new Random();
                    Thread.Sleep(50);
                    for (int i = 0; i < 5; i++)
                    {
                        Datastrongref.Add(r.Next(1, 91));
                    }
                    Dataweakref.Target = Datastrongref;
                }
                return Datastrongref;
            }
        }

        static void Main(string[] args)
        {

            List<int> s;
            s = Adatok;
            for (int i = 0; i < s.Count; i++)
                Console.Write(s[i]+" ");
            Console.WriteLine();
            s = null;
            
            s = Adatok;
            for (int i = 0; i < s.Count; i++)
                Console.Write(s[i] + " ");
            Console.WriteLine();

            s = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            s = Adatok;
            for (int i = 0; i < s.Count; i++)
                Console.Write(s[i] + " ");
            Console.WriteLine();

            s = null;
            for (int i = 0; i < 1000; i++)
            {
                Thread.Sleep(10);
                StringBuilder sb = new StringBuilder(1024);
                Console.Write(Dataweakref.IsAlive);
            }
            s = Adatok;
            for (int i = 0; i < s.Count; i++)
                Console.Write(s[i] + " ");
            Console.WriteLine();


            Console.ReadLine();
        }
    }
}
