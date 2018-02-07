using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Delegates
{
    class Program
    {

        delegate void Logolas(string log);

        static void LogolasToConsole(string log)
        {
            Console.WriteLine("Console: " + log);
        }
        static void LogolasToMsgbox(string log)
        {
            Console.WriteLine("MsgBox: " + log);
        }
        void LogolasToFile(string log)
        {
            Console.WriteLine("File: " + log);
        }

        delegate object GetStream(FileStream stream);
        static string GetS1(FileStream stream)
        {
            // covariancia
            return "GetS1 stream";
        }
        static object GetS2(Stream stream)
        {
            // contra-variancia
            return new Object();
        }

        static void Main(string[] args)
        {
            Logolas l0 = new Program().LogolasToFile;
            Logolas l1 = new Logolas(LogolasToConsole);
            Logolas l2 = LogolasToMsgbox;
            
            Logolas l3 = delegate(string szoveg) { Console.WriteLine("Esemenynaplo: " + szoveg); };
            Logolas l4 = l1 + l2 + l3;
            Logolas l5 = l4 - l1;

            l5 = l5 + l1;

            l1("l1");
            l2("l2");
            l3("l3");
            l4("l4");
            l5("l5");

            Logolas l6 = (Logolas)Delegate.Combine(l4, l5);
            l6("l6");

            Delegate[] logolasok = new Delegate[] { l1, l2, l3 };
            Logolas l7 = (Logolas)Delegate.Combine(logolasok);
            l7("l7");

            // elore definalt delegate-k
            Action<string> a = LogolasToConsole;

            Func<int, int> duplaz = delegate(int szam) { return szam * 2; };
            Func<int, int> triplaz = szam => szam * 3;
            Func<int, int> negyszerez = x => x * 4;

            Func<int, int, double> osztas = (x, y) => (double)x / y;

            GetStream gs = GetS1;
            gs = GetS2;

            gs = GetS1;
            object o = gs(new FileStream(@"c:\temp\valami.txt",FileMode.Create));
            Console.WriteLine(o.GetType());

            Console.ReadLine();
        }
    }
}
