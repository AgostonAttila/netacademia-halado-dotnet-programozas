using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace AsyncFile
{
    class Program
    {
        static Stream inputstream;
        static int buffersize = 100000;
        static byte[] buffer = new byte[buffersize];

        static void Felolvasta(IAsyncResult ar)
        {
            int mennyit = inputstream.EndRead(ar);
            if (mennyit > 0)
            {
                Console.WriteLine("Felolvasva: "+mennyit);
                Thread.Sleep(200);
                inputstream.BeginRead(buffer, 0, buffersize, Felolvasta, null);
            }
            else
            {
                Console.WriteLine("vege a felolvasasnak");
                inputstream.Close();
            }
        }

        static void Main(string[] args)
        {
            FileStream fs = new FileStream("test.txt", FileMode.Create);
            fs.SetLength(1005000);
            fs.Close();

            inputstream = new FileStream("test.txt", FileMode.Open, FileAccess.Read, FileShare.Read, buffersize, true);
            inputstream.BeginRead(buffer, 0, buffersize, Felolvasta, null);

            Console.ReadLine();
        }
    }
}
