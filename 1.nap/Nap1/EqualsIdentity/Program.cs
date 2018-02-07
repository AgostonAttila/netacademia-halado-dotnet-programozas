using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EqualsIdentity
{
    class Pont : IEquatable<Pont>
    {
        public int X, Y;

        public override int GetHashCode()
        {
            return this.X ^ this.Y;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (this.GetType() != obj.GetType()) return false;
            Pont p = (Pont)obj;
            if (!this.X.Equals(p.X)) return false;
            if (!this.Y.Equals(p.Y)) return false;
            return true;
        }

        public bool Equals(Pont other)
        {
            if (other == null) return false;
            if (!this.X.Equals(other.X)) return false;
            if (!this.Y.Equals(other.Y)) return false;
            return true;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
