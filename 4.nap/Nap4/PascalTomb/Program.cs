using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PascalTomb
{
    class PascalOutOfIndexException : Exception {}
 
    class PascalArray<T> : IEnumerable<T>
    {
        private T[] tomb;
        private int kezdo;
        public int Kezdo
        {
            get { return kezdo; }
        }
        private int veg;
        public int Veg
        {
            get { return veg; }
        }

        public PascalArray(int kezdo,int veg)
        {
            this.kezdo = kezdo;
            this.veg = veg;
            tomb = new T[veg - kezdo + 1];
        }

        public T this[int index]
        {
            get
            {
                if (index < kezdo || index > veg) throw new PascalOutOfIndexException();
                else return tomb[index - kezdo];
            }
            set
            {
                tomb[index - kezdo] = value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            List<T> lista = new List<T>(tomb);
            return lista.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return tomb.GetEnumerator();
        }
    }

    class Program
    {
        /*static T Add<T, T>(T a, T b)
        {
            T eredmeny = default(T);
            eredmeny = a + b;
            return eredmeny;
        }*/

        static void Main(string[] args)
        {
            PascalArray<DateTime> husvetok = new PascalArray<DateTime>(2000, 2003);
            husvetok[2000] = new DateTime(2000, 3, 12);
            husvetok[2001] = new DateTime(2001, 4, 1);
            husvetok[2002] = new DateTime(2002, 2, 28);
            husvetok[2003] = new DateTime(2003, 5, 11);
            for (int i = husvetok.Kezdo; i <= husvetok.Veg; i++)
            {
                Console.WriteLine(husvetok[i]);
            }

            foreach (var item in husvetok)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }



    


}
