class A
{

}
class B : A
{
    public new Type GetType()
    {
        return typeof(int);
    }
}

enum Szinek { Red, Green, Blue }
// belso=2, Cirada=3
enum Feature { Alak = 1, Belso, Cirada }

[Flags]
enum Forma { Kerek = 1, Szines = 2, Hosszu = 4 }

static void Main(string[] args)
{
    A a = new A();
    A b = new B();
    B bb = new B();
    Console.WriteLine(a.GetType().FullName); // A
    Console.WriteLine(b.GetType().FullName); // B
    Console.WriteLine(bb.GetType().FullName); // Int32 !!!, erdekes
    // static: Equals, ReferenceEquals
    // Virtual: Equals,GetHashCode,ToString
    // Nonvirtual: GetType

    //B bbb = (B)(new A()); // InvalidCast
    // B bbb = b; // cte !!!

    // A a2;
    // a2.ToString(); // cte
    //A a3 = null;
    //a3.ToString(); // nullreference exception

    object[] olist = new object[1000];
    for (int ii = 0; ii < olist.Length; ii++)
    {
        if (ii % 2 == 0) olist[ii] = new A(); else olist[ii] = new B();
    }
    Stopwatch sw = new Stopwatch();
    sw.Restart();
    int darab = 0, hiba = 0;
    for (int ii = 0; ii < olist.Length; ii++)
    {
        try
        {
            B peldany = (B)olist[ii];
            darab++;
        }
        catch (Exception)
        {
            hiba++;
        }
    }
    Console.WriteLine("darab=" + darab + " hiba=" + hiba);
    Console.WriteLine(sw.ElapsedMilliseconds + " ms");
    sw.Restart();
    darab = 0;
    hiba = 0;
    for (int ii = 0; ii < olist.Length; ii++)
    {
        B peldany = olist[ii] as B;
        if (peldany == null) hiba++; else darab++;
    }
    Console.WriteLine("darab=" + darab + " hiba=" + hiba);
    Console.WriteLine(sw.ElapsedMilliseconds + " ms");


    // DEFAULT ertekek

    int i = default(int); // 0
    Console.WriteLine(i);
    string s = default(string); // null
    Console.WriteLine(s);
    // Console.WriteLine(s.ToString()); nullreference exception
    bool logikai = default(bool); // false
    Console.WriteLine(logikai);
    object o = default(object); // null
    Console.WriteLine(o);

    DateTime dt = default(DateTime);
    Console.WriteLine(dt);
    Console.WriteLine(dt.ToLongDateString());
    Console.WriteLine(dt.ToLongTimeString());
    Guid g = default(Guid);
    Console.WriteLine(g);
    Point p = default(Point);
    Console.WriteLine(p);

    // Enum !!!
    Szinek sz = default(Szinek);
    Console.WriteLine(sz); // red
    Console.WriteLine((int)sz); // 0

    Feature f = default(Feature);
    Console.WriteLine(f); // 0
    Console.WriteLine((int)Feature.Alak); // 1 
    Console.WriteLine((int)Feature.Belso); // 2
    Console.WriteLine((int)Feature.Cirada); // 3
    f = (Feature)3;
    Console.WriteLine(f);

    Console.WriteLine((Forma)7);

    Console.ReadLine();
}
