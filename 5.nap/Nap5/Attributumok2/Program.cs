using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Attributumok2
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly a = Assembly.GetExecutingAssembly();
            foreach (var attr in a.GetCustomAttributes(false))
            {
                Console.WriteLine(attr.ToString());
            }

            object[] attribs = a.GetCustomAttributes(typeof(AssemblyFileVersionAttribute), true);
            if (attribs.Length > 0)
            {
                AssemblyFileVersionAttribute version = attribs[0] as AssemblyFileVersionAttribute;
                if (version != null)
                {
                    Console.WriteLine(version.Version);
                }
            }

            // AssemblyVersion:
            Console.WriteLine(a.GetName().Version);
            

            Console.ReadLine();
        }
    }
}
