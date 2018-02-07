// nem lehet static, sem sealed (implicite az), nem lehet abstract
public struct Valami // a struct csak interface-bol szarmazhat, es belole nem szarmazhat semmi (sealed) !!!
{
    // nem lehet benn abstract es virtual method
    // nem lehetni parameterless construktora
    public Valami(int x) { }
    // de mindig van neki implicite parameterless construktora !!! (IL-ben nincs, mert mashogy jon letre, 0-val inicializalodnak a mezok)
}

public struct Valami2
{
    public SomeVal v;
    public int x, y, z, a, b, c;
    // public int X = 5; // cte: nem lehet indulo erteket adni neki !!!
    public static int MaxSize = 100; // de ezt lehet !!!
    // a CTOR-ban pedig minden mezot inicializalni kell !!!
    // cte: 
    /*public Valami2(int x)
    {

    }*/
    // trukk:
    public Valami2(int x)
    {
        this = new Valami2();
    }
}


private class SomeRef { public Int32 x; }
// Value type (because of 'struct')
public struct SomeVal { public Int32 x; }

private interface IChangeBoxedPoint
{

    void Change(Int32 x, Int32 y);
}
// Point is a value type.
private struct Point : IChangeBoxedPoint
{
    private Int32 m_x, m_y;
    public Point(Int32 x, Int32 y)
    {
        m_x = x;
        m_y = y;
    }
    public void Change(Int32 x, Int32 y)
    {
        m_x = x; m_y = y;
    }
    public override String ToString()
    {
        return String.Format("({0}, {1})", m_x, m_y);
    }
}


static void Main(string[] args)
{

    SomeRef r1 = new SomeRef();   // Allocated in heap
    SomeVal v1 = new SomeVal();   // Allocated on stack
    Console.WriteLine(v1.x); // NULLA 
    SomeVal v3; // letrjin a stack-en csak nincs inicializalva a tagvaltozoja
    // Console.WriteLine(v3.x); // cte, unassigned v3.x !!!

    r1.x = 5;                     // Pointer dereference
    v1.x = 5;                     // Changed on stack
    SomeRef r2 = r1;              // Copies reference (pointer) only
    SomeVal v2 = v1;              // Allocate on stack & copies members !!!!!
    r1.x = 8;                     // Changes r1.x and r2.x
    v1.x = 9;                     // Changes v1.x, not v2.x
    Console.WriteLine(r1.x);      // Displays "8"
    Console.WriteLine(r2.x);      // Displays "8"
    Console.WriteLine(v1.x);      // Displays "9"
    Console.WriteLine(v2.x);      // Displays "5"

    v1.x = 5;
    v3.x = 5;
    Console.WriteLine(v1.Equals(v3)); // itt a mezoket hasonlitja ossze !!!
    // a System.Valuetype-ban az Equals es a GetHashCode override-olva van

    // boxing, unboxing
    //object o = null;
    //v1 = (SomeVal)o;  // nullreferenceexception
    //object o = 15;
    //v1 = (SomeVal)o; // invalidcast

    // ertek tipus nem lehet Thread safe, mert nincs benne sync resz

    // FUN
    Point p = new Point(1, 1);
    Console.WriteLine(p);
    p.Change(2, 2);
    Console.WriteLine(p);
    Object o = p;
    Console.WriteLine(o);
    ((Point)o).Change(3, 3);
    Console.WriteLine(o); // 2,2 !!!

    // Boxes p, changes the boxed object and discards it
    ((IChangeBoxedPoint)p).Change(4, 4);  // 2,2
    Console.WriteLine(p);

    // Changes the boxed object and shows it
    ((IChangeBoxedPoint)o).Change(5, 5); // 5,5 !!! itt n incs UNBOXING , azonnal a HEAP-hez nyul !!!
    Console.WriteLine(o);

    Valami vv1 = new Valami();
    Valami vv2 = new Valami();
    // Console.WriteLine(vv1==vv2); struct-nal csak akkor megy, ha overload-olva van az operator

    Valami2 vvv2 = new Valami2();
    System.Console.WriteLine(vvv2.v.x); // a belso strukture mar inicializalodott, nem kell neki new SomeVal()


    Console.ReadLine();
}
