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

