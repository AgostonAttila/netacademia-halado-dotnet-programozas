using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace EsemenyKezeles
{
    class OverflowEventArgs : EventArgs
    {
        public readonly int Mertek;
        public OverflowEventArgs(int mertek)
        {
            this.Mertek = mertek;
        }
    }
    class BankSzamla
    {
        private int egyenleg;
        public int Egyenleg
        {
            set { egyenleg = value; }
        }
        public BankSzamla(int egyenleg)
        {
            this.egyenleg = egyenleg;
        }

        public delegate void OverflowHandler(object sender, OverflowEventArgs e);
        // kihagytam valamit
        public event OverflowHandler Overflow = null;

        protected void OnOverflow(int mertek)
        {
            /*if (this.Overflow != null)
            {
                // masik szal
                Overflow(this, new OverflowEventArgs(mertek));
                // jobb: EventArgs.Empty
                // new EventArgs()
            }*/
            // immputable: Delagate, MulticastDelegate
            //OverflowHandler temp = this.Overflow;
            // thread safe atomic muveletek
            OverflowHandler temp = Interlocked.CompareExchange(ref this.Overflow, null, null);
            // Interlocked.CompareExchange(ref a, b, c)
            // old=a; if(a==c) a=b; return old; 
            /*long a = 500;
            a += 1000; */
            if (temp != null)
            {
                temp(this, new OverflowEventArgs(mertek));
            }
        }

        public void Kivesz(int penz)
        {
            if (penz > egyenleg)
            {
                // itt ut be a menyku
                OnOverflow(penz - egyenleg);
            }
            else
            {
                this.egyenleg -= penz;
                Console.WriteLine("penzkivetel tortent: " + penz);
            }
        }
        public void Berak(int penz)
        {
            if (penz > 0) this.egyenleg += penz;
        }
    }


    class Program
    {
        static void Kezelo(object sender, OverflowEventArgs e)
        {
            Console.WriteLine("nincs eleg penz a szamlan: " + e.Mertek + " ft-al tobbet akart kivenni");
        }

        static void Main(string[] args)
        {
            BankSzamla b = new BankSzamla(100000);

            // 1.es programozo
            //b.Overflow = Kezelo;

            // 2.es programozo
            /*b.Overflow = delegate(object sender, OverflowEventArgs e)
                            { Console.WriteLine("ejnye bejnye"); };*/

            b.Overflow += Kezelo;
            b.Overflow += delegate(object sender, OverflowEventArgs e)
                                { Console.WriteLine("ejnye bejnye"); };
            b.Overflow += new BankSzamla.OverflowHandler(b_Overflow);

            b.Overflow -= Kezelo;

            b.Kivesz(50000);
            b.Kivesz(70000);

            Console.ReadLine();
        }

        static void b_Overflow(object sender, OverflowEventArgs e)
        {
            Console.WriteLine("auto esemenykezelo");
        }
    }
}
