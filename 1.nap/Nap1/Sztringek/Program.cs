using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Sztringek
{
    class Program
    {
        static void Main(string[] args)
        {
            string errorcode = " 12";
            // immuatable
            string s1 = "Error" + errorcode;
            string s2 = "Error" + errorcode;
            Console.WriteLine(Object.ReferenceEquals(s1, s2));

            GCHandle h1 = GCHandle.Alloc(s1, GCHandleType.Pinned);
            GCHandle h2 = GCHandle.Alloc(s2, GCHandleType.Pinned);
            Console.WriteLine("Stack pointer:");
            Console.WriteLine(GCHandle.ToIntPtr(h1) + " " + GCHandle.ToIntPtr(h2));
            Console.WriteLine("heap address:");
            Console.WriteLine(h1.AddrOfPinnedObject() + " " + h2.AddrOfPinnedObject());
            s2 = "b";
            GCHandle h3 = GCHandle.Alloc(s2, GCHandleType.Pinned);
            Console.WriteLine(h3.AddrOfPinnedObject());

            Console.ReadLine();
        }
    }
}
