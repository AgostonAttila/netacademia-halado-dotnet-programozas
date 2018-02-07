using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using SzamologepInterface;

namespace SzamologepHost
{
    class Program
    {
        static void Main(string[] args)
        {
            int x, y;
            string s;

            Console.WriteLine("Kerem X-et");
            s = Console.ReadLine();
            x = int.Parse(s);
            Console.WriteLine("Kerem Y-t");
            s = Console.ReadLine();
            y = int.Parse(s);

            // pluginek beolvasa
            DirectoryInfo di = new DirectoryInfo("plugin");
            foreach (var item in di.GetFiles())
            {
                if (item.Extension == ".dll")
                {
                    Console.WriteLine(item.FullName);
                    Assembly a = Assembly.LoadFile(item.FullName);
                    foreach (var type in a.GetTypes())
                    {
                        object[] attribs = type.GetCustomAttributes(typeof(SzamologepPluginAttribute),true);
                        if (!(attribs == null || attribs.Length == 0) &&
                             type.GetInterfaces().Contains(typeof(ISzamologep)))
                        {
                            SzamologepPluginAttribute att = (SzamologepPluginAttribute)attribs[0];
                            Console.WriteLine(att.Leiras);
                            Console.WriteLine(att.Verzio);
                            Console.WriteLine(type.Name);

                            ISzamologep szamologep = (ISzamologep)Activator.CreateInstance(type);
                            int eredmeny = szamologep.Szamol(x, y);
                            Console.WriteLine("{0} {1} {2} = {3}",x,szamologep.MuveletiJel,y,eredmeny);
                        }
                    }

                }
            }

          


            Console.ReadLine();
        }
    }
}
