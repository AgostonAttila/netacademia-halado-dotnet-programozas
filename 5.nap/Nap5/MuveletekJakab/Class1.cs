using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SzamologepInterface;

namespace MuveletekJakab
{
    [SzamologepPlugin("Ez egy osszeado gep","1.0")]
    public class Osszeado : ISzamologep
    {
        public int Szamol(int a, int b)
        {
            return a + b;
        }

        public char MuveletiJel
        {
            get { return '+'; }
        }
    }

    [SzamologepPlugin("Ez egy szorzo gep", "1.0")]
    public class Szorzo : ISzamologep
    {
        public int Szamol(int a, int b)
        {
            return a * b;
        }

        public char MuveletiJel
        {
            get { return '*'; }
        }
    }
}
