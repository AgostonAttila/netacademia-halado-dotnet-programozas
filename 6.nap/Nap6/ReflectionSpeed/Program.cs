using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Reflection;

namespace ReflectionSpeed
{
    class Program
    {
        static string ReturnDate()
        {
            return DateTime.Now.ToString();
        }

        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Restart();
            for (int i = 0; i < 1000000; i++)
            {
                //string s = ReturnDate(); 3100
                string s = (string)typeof(Program).GetMethod("ReturnDate", BindingFlags.NonPublic | BindingFlags.Static)
                    .Invoke(null, null);
                // 6100
            }
            Console.WriteLine(sw.ElapsedMilliseconds + " ms");

            Console.ReadLine();
        }
    }
}
