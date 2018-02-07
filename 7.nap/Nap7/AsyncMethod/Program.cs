using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AsyncMethod
{
    class Program
    {
        public delegate DateTime AsyncMethodDelegate(int ido, string nev);
        static DateTime Metodus(int ido, string nev)
        {
            Console.WriteLine("Start Nev: "+nev+" "+DateTime.Now.ToString());
            Thread.Sleep(ido);
            Console.WriteLine("End Nev:"+nev);
            return DateTime.Now;
        }

        static void Main(string[] args)
        {
            AsyncMethodDelegate am = Metodus;
            IAsyncResult ia =  am.BeginInvoke(2000, "metodus", null, null);
            Console.WriteLine("mar elinditottam a metodust");
            System.Console.WriteLine("IsCompleted: " + ia.IsCompleted);
            
            // blokkolas
            /*DateTime vege = am.EndInvoke(ia);
            Console.WriteLine(vege.ToString());*/

            // polling
            /*while (!ia.IsCompleted)
            {
                Console.WriteLine("varakozok...");
                // itt lehet valamit csinalni
                Thread.Sleep(200);
            }
            DateTime vege = am.EndInvoke(ia);
            Console.WriteLine(vege.ToString());*/

            // wait megoldas
            while (!ia.AsyncWaitHandle.WaitOne(300))
            {
                Console.WriteLine("most is varakozok...");
            }
            DateTime vege = am.EndInvoke(ia);
            Console.WriteLine(vege.ToString());

            Console.WriteLine("tobbszoros pelda");
            IAsyncResult ia1 = am.BeginInvoke(3000, "metodus-1", null, null);
            IAsyncResult ia2 = am.BeginInvoke(2500, "metodus-2", null, null);
            IAsyncResult ia3 = am.BeginInvoke(1500, "metodus-3", null, null);

            WaitHandle[] handles = new WaitHandle[] {
                ia1.AsyncWaitHandle,ia2.AsyncWaitHandle,ia3.AsyncWaitHandle
            };
            WaitHandle.WaitAll(handles);
            Console.WriteLine("befejezodtek");
            Console.WriteLine(am.EndInvoke(ia1));
            Console.WriteLine(am.EndInvoke(ia2));
            Console.WriteLine(am.EndInvoke(ia3));

            // callback
            am.BeginInvoke(3000, "callback pelda", FeldolgozoCallback, am);

            Console.ReadLine();
        }

        public static void FeldolgozoCallback(IAsyncResult result)
        {
            AsyncMethodDelegate am = (AsyncMethodDelegate)result.AsyncState;
            Console.WriteLine("feldolgozas megtortent: "+am.EndInvoke(result));
        }

    }
}
