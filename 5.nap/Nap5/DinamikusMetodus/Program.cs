using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;

namespace DinamikusMetodus
{
    class Program
    {
        static int Osszeg()
        {
            int sum = 0;
            sum += 1;
            sum += 2;
            sum += 3;
            // ...
            return sum;
        }

        delegate int OsszegSzamlalalo();

        static void Main(string[] args)
        {
            // ------------------------------------
            // 1+2+3+4+5+...100
            DynamicMethod osszeg = new DynamicMethod("osszeg", typeof(int), new Type[0],
                typeof(Program).Module);
            ILGenerator generator = osszeg.GetILGenerator();
            generator.Emit(OpCodes.Ldc_I4_0);
            for (int i = 1; i <= 100; i++)
            {
                generator.Emit(OpCodes.Ldc_I4, i);
                generator.Emit(OpCodes.Add);
            }
            generator.EmitWriteLine("end of method");
            generator.Emit(OpCodes.Ret);
            // ------------------------------------

            // osszeg();

            OsszegSzamlalalo osz = (OsszegSzamlalalo)osszeg.CreateDelegate(typeof(OsszegSzamlalalo));
            int eredmeny = osz();
            Console.WriteLine("eredmeny= " + eredmeny);

            Console.ReadLine();

        }
    }
}
