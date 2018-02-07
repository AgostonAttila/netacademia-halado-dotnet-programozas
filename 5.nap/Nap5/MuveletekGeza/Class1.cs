using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SzamologepInterface;

namespace MuveletekGeza
{
    [SzamologepPlugin("Ez egy szorzo gep", "0.1 beta")]
    public class BenaSzorzo : ISzamologep
    {
        public int Szamol(int a, int b)
        {
            int sum = 0;
            for (int i = 0; i < a; i++)
            {
                sum += b;
            }
            return sum;
        }

        public char MuveletiJel
        {
            get { return '*'; }
        }
    }
}
