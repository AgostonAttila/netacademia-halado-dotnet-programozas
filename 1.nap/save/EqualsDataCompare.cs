static void Main(string[] args)
{
    // forditasi idoben egy helyre rakja a HEAP-ben
    string literal1 = "a";
    string literal2 = "a";
    Console.WriteLine(object.ReferenceEquals(literal1, literal2));

    GCHandle handle1 = GCHandle.Alloc(literal1, GCHandleType.Pinned);
    GCHandle handle2 = GCHandle.Alloc(literal2, GCHandleType.Pinned);
    Console.WriteLine(GCHandle.ToIntPtr(handle1) + " " + GCHandle.ToIntPtr(handle2));
    Console.WriteLine(handle1.AddrOfPinnedObject() + " " + handle2.AddrOfPinnedObject());
    handle1.Free();
    handle2.Free();
    Console.WriteLine(object.ReferenceEquals(literal1, literal2));

    literal1 += "b";
    Console.WriteLine(object.ReferenceEquals(literal1, literal2));
    literal2 += "b";
    Console.WriteLine(object.ReferenceEquals(literal1, literal2));
    StringBuilder s1 = new StringBuilder("hello");
    StringBuilder s2 = new StringBuilder("hello");
    literal1 = s1.ToString();
    literal2 = s2.ToString();
    Console.WriteLine(object.ReferenceEquals(literal1, literal2));

    // --------------------------------------------------------------------------

    Console.WriteLine(object.ReferenceEquals(null, null));
    Console.WriteLine(object.ReferenceEquals(new Object(), null));

    StringBuilder ss1 = new StringBuilder("hello");
    StringBuilder ss2 = new StringBuilder("hello");
    Console.WriteLine(object.ReferenceEquals(ss1, ss2));
    Console.WriteLine(object.ReferenceEquals(ss1, ss1));

    object x = ss1.ToString();
    object y = ss2.ToString();
    Console.WriteLine(object.ReferenceEquals(x, y));

    Console.WriteLine(x == y); // objecten hivodva a "mutatokat" hasonlitja

    string xs = (string)x;
    string ys = (string)y;
    Console.WriteLine(xs.Equals(ys));
    Console.WriteLine(xs == ys);

    string xx = null;
    string yy = null;
    //Console.WriteLine(xx.Equals(yy)); // exception: nincs referencia
    Console.WriteLine(xx == yy);
    Console.WriteLine(object.Equals(xx, yy));


    string one = "Caf\u00e9";        // U+00E9 LATIN SMALL LETTER E WITH ACUTE
    string two = "Cafe\u0301";       // U+0301 COMBINING ACUTE ACCENT
    Console.WriteLine(one == two);
    Console.WriteLine(one.Equals(two));

    // --------------------------------------------------------------------------

    double d = double.NaN;

    Console.WriteLine(d == d);
    Console.WriteLine(d != d);


    Console.WriteLine(1 == 1);
    Console.WriteLine(1 == 1.0);
    Console.WriteLine(1 == 1L);
    Console.WriteLine('1' == 49);

    Console.WriteLine(1.Equals(1));
    Console.WriteLine(1.Equals(1.0));
    Console.WriteLine(1.Equals(1L));
    Console.WriteLine('1'.Equals(49));


    Console.ReadLine();

}
