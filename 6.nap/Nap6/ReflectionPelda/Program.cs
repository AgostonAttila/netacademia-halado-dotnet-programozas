using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace ReflectionPelda
{
    class Program
    {
        public static void ListAllMethods(Type t)
        {
            MethodInfo[] allmethods = t.GetMethods();
            Console.WriteLine("  " + t.Name + ": ");
            foreach (var item in allmethods)
            {
                ParameterInfo[] pis = item.GetParameters();
                string p = "";
                for (int i = 0; i < pis.Length; i++)
                {
                    if (i > 0) p += ", ";
                    p += pis[i].Name;
                }
                Console.WriteLine("{0,20} ({2,20})  {1,20}", item.Name, item.ReturnType.FullName, p);
            }
        }

        public static void ListAllLocalVariables(MethodInfo mi)
        {
            MethodBody mb = mi.GetMethodBody();
            IList<LocalVariableInfo> lista = mb.LocalVariables;
            Console.WriteLine("  "+mi.Name+":");
            foreach (var item in lista)
            {
                Console.WriteLine(item.LocalType + " " + item.LocalIndex);
            }
        }

        static void Vacak()
        {
            int a;
            bool b;
            double d;
        }

        static void Main(string[] args)
        {
            ListAllMethods(typeof(Random));
            ListAllMethods(typeof(Program));

            ListAllLocalVariables(typeof(Program).GetMethod("Vacak",BindingFlags.NonPublic | BindingFlags.Static));
            ListAllLocalVariables(typeof(Program).GetMethod("ListAllLocalVariables",  BindingFlags.Static | BindingFlags.Public));

            Console.ReadLine();
        }
    }
}
