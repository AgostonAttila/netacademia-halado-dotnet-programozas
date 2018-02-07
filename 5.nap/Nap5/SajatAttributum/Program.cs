using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace SajatAttributum
{
    // [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true,
      Inherited = true)]
    public class SajatAttribute : Attribute
    {
        public SajatAttribute(string leiras)
        {
            this.leiras = leiras;
        }
        string leiras;
        public string Leiras
        {
            get { return leiras; }
        }

        public object o;
        public Type t;
        // primitiv tipusok, object, string, Type
    }

    [Sajat("Base osztaly attributum", o = null, t = typeof(int))]
    [Sajat("Base osztaly attributum 2")]
    public class Base { }

    [Sajat("Derived osztaly attributum")]
    public class Derived : Base
    {
        [Sajat("Derived M metodus attributum")]
        public void M() { }

        // [Sajat("Derived Mezo field attributum")]
        public string Mezo;
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(typeof(Base).IsDefined(typeof(SajatAttribute), false));
            Console.WriteLine(typeof(Derived).IsDefined(typeof(SajatAttribute), false));
            Console.WriteLine(typeof(Derived).IsDefined(typeof(SajatAttribute), true));

            // biztonsagos lekerdezes
            // CustomAttributeData.GetCustomAttributes(typeof(Base))

            Console.WriteLine("Base osztaly:");
            foreach (var item in typeof(Base).GetCustomAttributes(typeof(SajatAttribute), true))
            {
                SajatAttribute sajat = (SajatAttribute)item;
                Console.WriteLine(sajat.Leiras);
            }

            Console.WriteLine("Derived osztaly:");
            foreach (var item in typeof(Derived).GetCustomAttributes(typeof(SajatAttribute), true))
            {
                SajatAttribute sajat = (SajatAttribute)item;
                Console.WriteLine(sajat.Leiras);
            }

            Console.WriteLine("Metodus attributumok:");
            foreach (var met in typeof(Derived).GetMethods())
            {
                foreach (var item in met.GetCustomAttributes(typeof(SajatAttribute), true))
                {
                    SajatAttribute sajat = (SajatAttribute)item;
                    Console.WriteLine(sajat.Leiras);
                }
            }

            Console.ReadLine();
        }
    }
}
