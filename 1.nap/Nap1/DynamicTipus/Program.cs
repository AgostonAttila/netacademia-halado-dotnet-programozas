using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace DynamicTipus
{
    // nem a mienk
    class Calculator
    {
        public int Calc(int a, int b)
        {
            return a + b;
        }
    }


    class Program
    {
        static Calculator GetPluginInstance()
        {
            return new Calculator();
        }

        static void Main(string[] args)
        {
            dynamic plugin = GetPluginInstance();
            try
            {
                Console.WriteLine(plugin.Add(1, 3));
            }
            catch (Exception)
            {
                Console.WriteLine("nincs Add");
            }
            try
            {
                Console.WriteLine(plugin.Calc(1, 3));
            }
            catch (Exception)
            {
                Console.WriteLine("nincs Calc");
            }

            // regen:
            object target = "IT Factory";
            object ar = "IT";
            Type[] argTypes = new Type[] { ar.GetType() };
            MethodInfo method = target.GetType().GetMethod("Contains", argTypes);
            object[] arguments = new object[] { ar };
            bool res = Convert.ToBoolean(method.Invoke(target, arguments));
            Console.WriteLine(res);

            //((string)target).Contains((string)ar);

            

            Console.ReadLine();
        }
    }
}
