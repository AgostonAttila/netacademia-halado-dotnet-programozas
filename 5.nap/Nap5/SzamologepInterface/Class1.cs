using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SzamologepInterface
{
    public interface ISzamologep
    {
        int Szamol(int a, int b);
        char MuveletiJel { get; }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class SzamologepPluginAttribute : Attribute
    {
        public SzamologepPluginAttribute(string leiras, string verzio)
        {
            this.leiras = leiras;
            this.verzio = verzio;
        }
        string leiras;
        string verzio;
        public string Leiras { get {return leiras;}}
        public string Verzio { get { return verzio; } }
    }
}
