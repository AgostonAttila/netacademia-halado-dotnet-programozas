unsafe public static void Main()
{
    int szam = 5;
    // unsafe method: uses address-of operator (&)
    SquarePtrParam(&szam);
    Console.WriteLine(szam);

    int size = 100000000;
    byte[] source = new byte[size];
    byte[] dest = new byte[size];
    for (int i = 0; i < size; i++)
        source[i] = (byte)(i % 255);

    Stopwatch sw = new Stopwatch();

    sw.Restart();
    Array.Copy(source, dest, size);
    sw.Stop();
    Console.WriteLine("Elapsed: " + sw.ElapsedMilliseconds + " ms");

    sw.Restart();
    Array.Copy(source, dest, size);
    sw.Stop();
    Console.WriteLine("Elapsed: " + sw.ElapsedMilliseconds + " ms");

    sw.Restart();
    FastCopy(source, 0, dest, 0, size);
    sw.Stop();
    Console.WriteLine("Elapsed: " + sw.ElapsedMilliseconds + " ms");

    sw.Restart();
    Console.WriteLine(SafeEquals(source, dest));
    sw.Stop();
    Console.WriteLine("Elapsed: " + sw.ElapsedMilliseconds + " ms");

    sw.Restart();
    Console.WriteLine(UnsafeEquals(source, dest));
    sw.Stop();
    Console.WriteLine("Elapsed: " + sw.ElapsedMilliseconds + " ms");

    sw.Restart();
    Console.WriteLine(source.SequenceEqual(dest)); // gyenge
    sw.Stop();
    Console.WriteLine("Elapsed: " + sw.ElapsedMilliseconds + " ms");

    sw.Restart();
    IStructuralEquatable eqa1 = source;
    //Console.WriteLine(eqa1.Equals(dest, StructuralComparisons.StructuralEqualityComparer)); // pokoli lassu
    sw.Stop();
    Console.WriteLine("Elapsed: " + sw.ElapsedMilliseconds + " ms");

    sw.Restart();
    Console.WriteLine(PinvokeEquals(source, dest));
    sw.Stop();
    Console.WriteLine("Elapsed: " + sw.ElapsedMilliseconds + " ms");

    Atnyulni();

    UnsafeStrings();
    
    Console.ReadLine();
}
