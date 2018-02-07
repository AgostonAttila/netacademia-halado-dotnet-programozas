using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace UnsafeProba
{
    class Program
    {
        static int a = 10;
        static int b = 20;
        static int c = 30;

        unsafe static void Proba1()
        {
            fixed (int* p = &a)
            {
                int* pa = p;
                pa++;
                *((int*)pa) = 25;
            }
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
        }

        static bool SafeEquals(byte[] a1, byte[] a2)
        {
            if (a1 == null || a2 == null || a1.Length != a2.Length) return false;
            for (int i = 0; i < a1.Length; i++)
            {
                if (a1[i] != a2[i]) return false;
            }
            return true;
        }

        static unsafe bool UnsafeEquals(byte[] a1, byte[] a2)
        {
            if (a1 == null || a2 == null || a1.Length != a2.Length)
                return false;
            fixed (byte* p1 = a1, p2 = a2)
            {
                byte* x1 = p1, x2 = p2;
                int l = a1.Length;
                for (int i = 0; i < l / 8; i++, x1 += 8, x2 += 8)
                    if (*((long*)x1) != *((long*)x2)) return false;
                if ((l & 4) != 0) { if (*((int*)x1) != *((int*)x2)) return false; x1 += 4; x2 += 4; }
                if ((l & 2) != 0) { if (*((short*)x1) != *((short*)x2)) return false; x1 += 2; x2 += 2; }
                if ((l & 1) != 0) if (*((byte*)x1) != *((byte*)x2)) return false;
                return true;
            }
        }
            
        // kulonbozo hivasi konvenciok vannak: ez torli a stack-et, es valtozo szamu parametert is kezel
        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern int memcmp(byte[] a1, byte[] a2, long count);
        static bool PinvokeEquals(byte[] a1, byte[] a2)
        {
            if (a1 == null || a2 == null || a1.Length != a2.Length)
                return false;
            // The CLR will automatically pin references to managed objects when the cross the PInvoke boundary
            return memcmp(a1, a2, a1.Length) == 0;
        }


        static void Main(string[] args)
        {
            Proba1();

            int size = 100000000;
            byte[] source = new byte[size];
            byte[] dest = new byte[size];
            for (int i = 0; i < size; i++)
            {
                source[i] = (byte)(i % 255);
                dest[i] = (byte)(i % 255);
            }

            // kerdes: azonos-e a ket tomb

            Stopwatch sw = new Stopwatch();

            sw.Restart();
            source.SequenceEqual(dest);
            Console.WriteLine(sw.ElapsedMilliseconds + " ms");

            sw.Restart();
            SafeEquals(source, dest);
            Console.WriteLine(sw.ElapsedMilliseconds+" ms");

            sw.Restart();
            UnsafeEquals(source, dest);
            Console.WriteLine(sw.ElapsedMilliseconds + " ms");

            sw.Restart();
            PinvokeEquals(source, dest);
            Console.WriteLine(sw.ElapsedMilliseconds + " ms");

            Console.ReadLine();
        }
    }
}
