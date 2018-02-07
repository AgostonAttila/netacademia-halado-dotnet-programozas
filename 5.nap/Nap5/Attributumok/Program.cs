// #define SQLLOG

// WebMethod
// CacheDuration

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace Attributumok
{

    class Program
    {

        [method: Obsolete("ez a metodus elavult, hasznald helyette az UjMetodus-t", false)]
        static void ElavultMetodus() { }

        static void UjMetodus() { }

        [DebuggerDisplay("Név = {Nev} Életkor = {Eletkor}")]
        [Serializable]
        class Tanulo
        {
            public string Nev;
            public int Eletkor;
            
            [NonSerialized]
            public string Cim;
        }

        [Conditional("SQLLOG")]
        [Conditional("DEBUG")]
        static void SqlLogolas(string log)
        {
            Console.WriteLine("SQL: " + log);
        }

        static void ConsoleLogolas(string log)
        {
            Console.WriteLine("Console: " + log);
        }

        [DebuggerStepThrough]
        static int Add(int a, int b)
        {
            return a + b;
        }

        static int Minus(int a, int b)
        {
            return a - b;
        }

        static MemoryStream SorositToMemoria(object o)
        {
            MemoryStream m = new MemoryStream();
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(m, o);
            return m;
        }

        static object MemoriaToObject(MemoryStream m)
        {
            IFormatter formatter = new BinaryFormatter();
            m.Seek(0, SeekOrigin.Begin);
            return formatter.Deserialize(m);
        }

        static void Main(string[] args)
        {
            ElavultMetodus();
            UjMetodus();

            SqlLogolas("hiba tortent");
            ConsoleLogolas("hiba tortent");
            int e1 = Add(4, 5);
            int e2 = Minus(4, 5);

            Tanulo t = new Tanulo { Nev = "Gipsz Jakab", Eletkor = 13, Cim = "Sasad u. 34" };

            MemoryStream m = SorositToMemoria(t);
            Tanulo t2 = (Tanulo)MemoriaToObject(m);
            Console.WriteLine("Nev=" + t2.Nev);
            Console.WriteLine("Eletkor=" + t2.Eletkor);
            Console.WriteLine("Cim=" + t2.Cim);

            Tanulo[] tanulok = new Tanulo[] { t, t, t };

            Console.ReadLine();
        }
    }
}
