using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Szinlista = GenerikusFinomsagok.GenericTipusWithEnum<GenerikusFinomsagok.Szinek>;
using System.IO;


namespace GenerikusFinomsagok
{
    class GenericTipusWithStatic<T>
    {
        static GenericTipusWithStatic()
        {
            Console.WriteLine(typeof(T).Name);
        }
    }

    class GenericTipusWithEnum<T>
    {
        static GenericTipusWithEnum()
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("Type member legyen ENUM !!!");
        }
    }

    enum Szinek { Feher, Fekete }

    class Program
    {

        static void Swap(ref int a, ref int b)
        {
            Console.WriteLine("sima int swap");
            int temp = a;
            a = b;
            b = temp;
        }

        static void Swap<T>(ref T a, ref T b)
        {
            Console.WriteLine("generikus swap");
            T temp = a;
            a = b;
            b = temp;
        }

        static T Minimum<T>(T a, T b) where T : IComparable<T>
        {
            if (a.CompareTo(b) < 0) return a; else return b;
        }

        interface IOsszeadas<T>
        {
            T Add(T a);
        }
        static T Osszeg<T>(T a, T b) where T : IOsszeadas<T>
        {
            return a.Add(b);
        }
        static T Osszeg2<T>(params T[] lista) where T : IOsszeadas<T>
        {
            // T valami = new T();
            T eredmeny = default(T);
            for (int i = 0; i < lista.Length; i++)
            {
                eredmeny = eredmeny.Add(lista[i]);
            }
            return eredmeny;
        }

        static void Bonyolult1<T>(T o) where T : class, IComparable<T>, IList<T>, IDisposable, new()
        {
            T valami = new T();
        }
        static void Bonyolult2<T>(T o) where T : Stream, IComparable<T>, IList<T>, IDisposable, new()
        {
            T valami = new T();
        }

        static void Bonyolult3<T>(T o) where T : struct
        {
            T valami = new T();
        }

        class Base
        {
            public virtual void VirtMet<T1, T2>()
                where T1 : struct
                where T2 : IList<T2>
            {

            }
        }

        class Leszarmazott : Base
        {
            /*public override void VirtMet<TResult, T>()
            {
                base.VirtMet<TResult, T>();
            }*/
            public new virtual void VirtMet<T1, T2>()
                where T1 : class
                where T2 : IDisposable
            {

            }
        }

        // konvertalo generikus method
        static List<T2> ConvertILIST<T, T2>(IList<T> lista) where T : T2
        {
            List<T2> eredmeny = new List<T2>(lista.Count);
            for (int i = 0; i < lista.Count; i++)
            {
                eredmeny.Add(lista[i]);
            }
            return eredmeny;
        }

        static void OsszehasonlitasNullAl<T>(T o)
        {
            // inkabb default szocska
            // if (o == default(T))
            if (o == null)
            {
                Console.WriteLine("ez null");
            }
        }

        static void OsszehasonlitasEgymassal<T>(T t1,T t2) where T : struct
        {
            /*if (t1 == t2)
            {

            }*/
        }

        static void Main(string[] args)
        {

            GenericTipusWithStatic<int> gti = new GenericTipusWithStatic<int>();
            GenericTipusWithStatic<string> gts = new GenericTipusWithStatic<string>();

            GenericTipusWithEnum<Szinek> sz = new GenericTipusWithEnum<Szinek>();
            // GenericTipusWithEnum<int> sz2 = new GenericTipusWithEnum<int>(); // RTE

            // !!! in es out szocskak
            Func<object, ArgumentException> f1 = null;
            Func<string, Exception> f2 = f1;

            // automatikus tipusfelismeres
            int a = 5;
            int b = 10;
            Swap(ref a, ref b);
            double x = 10;
            double y = 20;
            Swap(ref x, ref y);
            // Swap<double>(ref x, ref y);
            Swap<int>(ref a, ref b);

            Console.WriteLine(Minimum(5, 2));
            Console.WriteLine(Minimum("alma", "aladin"));
            Console.WriteLine(Minimum(2, 5.2));
            Console.WriteLine(Minimum("2", (5.2).ToString()));

            List<FileStream> fs = new List<FileStream>();
            List<Stream> s = ConvertILIST<FileStream, Stream>(fs); // lehetne object is

            OsszehasonlitasNullAl<int>(5);


            Console.ReadLine();
        }
    }
}
