using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExplicitInterfeszek
{
    class Program
    {
        /*interface IUzlet
        {
            object GetArlista();
        }
        interface IWebshop
        {
            object GetArlista(string cssfile);
        }

        class SzamtechBolt : IUzlet, IWebshop
        {
            public object GetArlista()
            {
                Console.WriteLine("Uzlet GetArlista");
                return null;
            }
            public object GetArlista(string cssfile)
            {
                Console.WriteLine("Webshop GetArlista");
                return null;
            }
        }*/

        interface IUzlet
        {
            object GetArlista();
        }
        interface IWebshop
        {
            object GetArlista();
        }

        class SzamtechBolt : IUzlet, IWebshop
        {
            object IUzlet.GetArlista()
            {
                Console.WriteLine("IUzlet getarlista");
                return null;
            }
            object IWebshop.GetArlista()
            {
                Console.WriteLine("IWebshop getarlista");
                return null;
            }
        }

        static void Main(string[] args)
        {

            SzamtechBolt szb = new SzamtechBolt();
            //szb.GetArlista();
            ((IUzlet)szb).GetArlista();

            IWebshop ws = szb;
            ws.GetArlista();


            Console.ReadLine();
        }
    }
}
