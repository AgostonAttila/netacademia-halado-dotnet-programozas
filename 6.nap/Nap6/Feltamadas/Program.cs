using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Feltamadas
{
    class Program
    {
        class MyClass
        {
            public Random R = new Random();
            ~MyClass()
            {
                MC = this;
                Console.WriteLine("a finalizer lefutott");
            }
        }

        static MyClass MC;

        static void Main(string[] args)
        {
            MyClass mc = new MyClass();
            mc = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine(MC.ToString());
            Console.WriteLine(MC.R.ToString());

            Console.ReadLine();
        }
    }
}
