using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TimerPelda
{
    class Program
    {
        static void KetyegoOra(object o)
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString()+" "+DateTime.Now.Millisecond);
        }

        static void Main(string[] args)
        {
            Timer timer = new Timer(KetyegoOra, null, 1000, 1000);
            // timer.Change()
            Timer ketsecmulva = new Timer(
                o => { Console.WriteLine("Haho kesz a TEA"); },null,DateTime.Now.AddSeconds(4)-DateTime.Now,new TimeSpan(-1)
                );

            Console.ReadLine();
        }
    }
}
