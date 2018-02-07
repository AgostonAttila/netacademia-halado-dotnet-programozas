using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using System.Data.SqlClient;

namespace DisposePattern
{
    class SajatOsztaly : IDisposable
    {
        private int in_dispose = 0;
        private IntPtr NemmenedzseltMemoria = IntPtr.Zero;
        private List<long> MenedzseltMemoria = new List<long>();
        volatile bool disposed = false;

        public SajatOsztaly()
        {
            NemmenedzseltMemoria = Marshal.AllocHGlobal(1000000);
            GC.AddMemoryPressure(1000000);
            for (int i = 0; i < 1000000; i++)
            {
                MenedzseltMemoria.Add(i);
            }
        }

        ~SajatOsztaly()
        {
            Console.WriteLine("finalizer");
            // meg kell hivni a dispose-t
            this.Dispose(false);
        }

        public void ValamiMetodus()
        {
            if (disposed || in_dispose == 1) 
                throw new ObjectDisposedException("SajatOsztaly felszabadult!");
            // ...
        }

        private void Dispose(bool disposing)
        {
            Console.WriteLine("dispose: " + disposing);
            // int old = in_dispose; in_dispose=1; return old;
            if (Interlocked.Exchange(ref in_dispose, 1) != 0) return;

            if (disposed == false)
            {
                if (disposing)
                {
                    // menedzselt eroforrasokat felszabaditani
                    // Dispose ,  Close: SqlConnection, Strem, Socket
                    // illik majd ezt thread safe-e tenni
                    if (MenedzseltMemoria != null)
                    {
                        MenedzseltMemoria.Clear();
                        MenedzseltMemoria = null;
                    }
                }
                // a nem menedzselt-et fel kell szabaditani
                if (NemmenedzseltMemoria != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(NemmenedzseltMemoria);
                    GC.RemoveMemoryPressure(1000000);
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            SajatOsztaly so = new SajatOsztaly();
            so.Dispose();
            so = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();


            using (SajatOsztaly sajat = new SajatOsztaly())
            {
                Console.WriteLine("using-on belul");
            }

            SajatOsztaly saj = new SajatOsztaly();
            try
            {
                // muveletek
                Console.WriteLine("tryf-on belul");
            }
            finally
            {
                if (saj != null) ((IDisposable)saj).Dispose();
            }

            //eletszeru pelda
            try
            {
                using (var conn = new SqlConnection("...."))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("select * from users", conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // egyesevel feldolgozas
                            }
                        }
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }



            Console.ReadLine();
        }
    }
}
