using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfeszek
{

    internal interface ITopLevel { }

    class Program
    {
        public interface IPublicInterface {}
        protected interface IProtectedInterface { }
        private interface IPrivateInterface { }
        internal interface IInternalInterface { }
        internal protected interface IInternalProtectedInterface { }

        interface IProba
        {
            // public..., abstract , virtual, sealed egyik se !!!
            void Add(int szam);
            string Nev { get; set; }
            event EventHandler<EventArgs> LeveletKapott;
            string this[int id] { get;  }
        }

        //class Proba : osztaly(1 db), interface (0 ,1,  tobb)
        class Proba : IProba
        {

            public void Add(int szam)
            {
                throw new NotImplementedException();
            }

            public string Nev
            {
                get
                {
                    throw new NotImplementedException();
                }
                set
                {
                    throw new NotImplementedException();
                }
            }

            public event EventHandler<EventArgs> LeveletKapott;

            public string this[int id]
            {
                get { throw new NotImplementedException(); }
            }
        }


        class Base : IDisposable
        {
            public void Dispose()
            {
                Console.WriteLine("Base Dispose");
            }
        }

        class Derived : Base, IDisposable
        {
            public new virtual void Dispose()
            {
                Console.WriteLine("Derived Dispose");
            }
        }

        static void Main(string[] args)
        {

            Console.ReadLine();
        }
    }
}
