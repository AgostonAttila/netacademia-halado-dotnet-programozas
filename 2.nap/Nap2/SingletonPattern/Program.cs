using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SingletonPattern
{
    // ne lehessen peldanyositani
    class LoadBalancer
    {
        // SendRequest...
        // belso impl. szerverLista kollekcio
        private LoadBalancer() {}

        private readonly static LoadBalancer balancer;

        static LoadBalancer()
        {
            // thread safe
            balancer = new LoadBalancer();
        }

        public static LoadBalancer Balancer
        {
            get { return balancer; }
        }
    }

    public sealed class SingletonLazy
    {
        static SingletonLazy instance = null;
        static readonly object padlock = new object();

        SingletonLazy()
        {
        }

        public static SingletonLazy Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new SingletonLazy();
                    }
                    return instance;
                }
            }
        }
    }

    public sealed class SingletonLazyNice
    {
        SingletonLazyNice()
        {
        }
        public static SingletonLazyNice Instance
        {
            get
            {
                return Nested.instance;
            }
        }
        class Nested
        {
            static Nested()
            {
            }
            internal static readonly SingletonLazyNice instance = new SingletonLazyNice();
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            LoadBalancer balancer = LoadBalancer.Balancer;

        }
    }
}
