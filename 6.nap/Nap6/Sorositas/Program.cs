using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization;

namespace Sorositas
{
    class Program
    {
        [Serializable]
        public class Tanulo
        {
            public Tanulo(int id)
            {
                this.id = id;
            }
            private int id;
            public string Nev;
            public int Eletkor;
            public string Varos;
            [NonSerialized]
            public string Kod;

            [OptionalField]
            public Tanulo Haver = null;

            public void KodCalculate()
            {
                Kod = Nev.Substring(0, 2) + id + "_" + Eletkor;
            }

            public override string ToString()
            {
                return String.Format("{0} {1} {2} {3} {4}", id, Nev, Eletkor, Varos, Kod);
            }

            [OnDeserialized]
            public void OD(StreamingContext context)
            {
                KodCalculate();
            }
        }


        static string ObjectToSOAP(object o)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                SoapFormatter f = new SoapFormatter();
                f.Serialize(stream, o);
                stream.Flush();
                return UTF8Encoding.UTF8.GetString(stream.GetBuffer(), 0, (int)stream.Position);
            }
        }

        static T SOAPToObject<T>(string s)
        {
            using (MemoryStream stream = new MemoryStream(UTF8Encoding.UTF8.GetBytes(s)))
            {
                SoapFormatter f = new SoapFormatter();
                return (T)f.Deserialize(stream);
            }
        }


        static void Main(string[] args)
        {
            Tanulo t = new Tanulo(1);
            t.Nev = "Gipsz Jakab";
            t.Eletkor = 23;
            t.Varos = "Budapest";
            t.Haver = t;
            //t.Haver = new Tanulo(3);

            string s = ObjectToSOAP(t);
            File.WriteAllText(@"c:\temp\jakab.soap", s);
            Console.WriteLine(s);
            s = s.Replace("Budapest", "Debrecen");

            s= File.ReadAllText(@"c:\temp\jakab2.soap");

            t = SOAPToObject<Tanulo>(s);
            Console.WriteLine(t);

            Console.ReadLine();
        }
    }
}
