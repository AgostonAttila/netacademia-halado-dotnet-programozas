// lehet: IComparable<Point>
class Point : IEquatable<Point>
{
    public int X, Y;
    public override bool Equals(object obj)
    {
        if (obj == null) return false;
        if (this.GetType() != obj.GetType()) return false;
        Point p = (Point)obj;
        if (!this.X.Equals(p.X)) return false;
        if (!this.Y.Equals(p.Y)) return false;
        return true;
    }

    // ha modositunk egy elemet (KEY reszet) egy Key-Value HashTablaban akkor ki kell venni es ujra berakni
    // ezert pl. csak immputable tipusoknal definialjuk felul a == operatort
    // == : compile time-ban dol el mi hivodik meg, Equals: runtime dol el
    public override int GetHashCode()
    {
        return this.X ^ this.Y; // XOR
    }

    #region IEquatable<Point> Members

    public bool Equals(Point other)
    {
        if (other == null) return false;
        if (this.GetType() != other.GetType()) return false;
        Point p = (Point)other;
        if (!this.X.Equals(p.X)) return false;
        if (!this.Y.Equals(p.Y)) return false;
        return true;
    }

    #endregion

    public static bool operator ==(Point p1, Point p2)
    {
        if (System.Object.ReferenceEquals(p1, p2)) return true;
        // If one is null, but not both, return false.
        if (((object)p1 == null) || ((object)p2 == null)) return false;
        //return object.Equals(p1,p2);
        return p1.Equals(p2);
    }
    public static bool operator !=(Point p1, Point p2)
    {
        return !(p1 == p2);
    }
}

static void Main(string[] args)
{
    Point p1 = new Point { X = 1, Y = 1 };
    Point p2 = new Point { X = 1, Y = 1 };
    Console.WriteLine(p1.Equals(p2));
    Console.WriteLine(Object.ReferenceEquals(p1, p2));

    // ha overrideoltuk a GetHashCode-ot
    System.Console.WriteLine(RuntimeHelpers.GetHashCode(p1));
    System.Console.WriteLine(RuntimeHelpers.GetHashCode(p2));

    Console.ReadLine();
}
