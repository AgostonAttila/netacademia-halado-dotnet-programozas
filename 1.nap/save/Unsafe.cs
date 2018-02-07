static int a = 10;
static int b = 20;
static int c = 30;

// unsafe method: takes pointer to int:
unsafe static void SquarePtrParam(int* p)
{
    *p *= *p;
}

unsafe static void Atnyulni()
{
    fixed (int* p = &a)
    {
        int* pi = p;
        pi++; // leptetes
        *((int*)pi) = 25;
    }
    Console.WriteLine("a=" + a);
    Console.WriteLine("b=" + b); // !!!
    Console.WriteLine("c=" + c);

    fixed (int* p = &b)
    {
        byte* pi = (byte*)p;
        pi--; // leptetes vagy +=3
        // little endian: elso byte a legkisebb
        *((byte*)pi) = 1;
    }

    Console.WriteLine("a=" + a); // !!!
    Console.WriteLine("b=" + b);
    Console.WriteLine("c=" + c);

    string s = "----------";
    Console.WriteLine(s);
    fixed (char* pString = s)
    {
        pString[5] = '*'; // 5 helyett lehet barmilyen szam
    }
    Console.WriteLine(s);

}

unsafe static void UnsafeStrings()
{

    // these strings get interned
    string s1 = "HALI";
    string s2 = "HALI";

    string ss1, ss2;

    ss1 = s1;
    ss1 += " BOHOC";

    ss2 = s1;
    ss2 += " BOHOC";

    unsafe
    {
        // very bad, this changes an interned string which affects 
        // all app domains.
        fixed (char* str = s2)
        {
            *str = 'L';
        }

        fixed (char* str = ss2)
        {
            *str = 'L';
        }

    }

    Console.WriteLine("s1 = {0} , s2 = {1}", s1, s2);
    // output: s1 = LALI , s2 = LALI  

    Console.WriteLine("ss1 = {0} , ss2 = {1}", ss1, ss2);
    // output : ss1 = HALI BOHOC , ss2 = LALI BOHOC


    // ugy nez ki a sorting nem rontja el
    string e1, e2, e3, e4, e5;
    e1 = "őooo";
    e2 = "űuuu";
    e3 = "íiii";
    e4 = "áaaa";
    e5 = "éeee";
    string[] t = new string[] { e1, e2, e3, e4, e5 };
    Array.Sort(t);
    for (int i = 0; i < t.Length; i++)
    {
        Console.WriteLine(t[i]);
    }
    e1 = "oooo";
    e2 = "uuuu";
    e3 = "iiii";
    e4 = "aaaa";
    e5 = "eeee";
    unsafe
    {                
        fixed (char* str = e1) { *str = 'ő'; }
        fixed (char* str = e2) { *str = 'ű'; }
        fixed (char* str = e3) { *str = 'í'; }
        fixed (char* str = e4) { *str = 'á'; }
        fixed (char* str = e5) { *str = 'é'; }
    }
    t = new string[] { e1, e2, e3, e4, e5 };
    Array.Sort(t);
    for (int i = 0; i < t.Length; i++)
    {
        Console.WriteLine(t[i]);
    }

}


static unsafe void FastCopy(byte[] src, int srcIndex, byte[] dst, int dstIndex, int count)
{
    if (src == null || srcIndex < 0 || dst == null || dstIndex < 0 || count < 0)
    {
        throw new ArgumentException();
    }
    int srcLen = src.Length;
    int dstLen = dst.Length;
    if (srcLen - srcIndex < count || dstLen - dstIndex < count)
    {
        throw new ArgumentException();
    }

    // pins the location of the src and dst objects in memory 
    // so that they will not be moved by garbage collection.          
    fixed (byte* pSrc = src, pDst = dst)
    {
        byte* ps = pSrc;
        byte* pd = pDst;

        // Loop over the count in blocks of 4 bytes, copying an
        // integer (4 bytes) at a time:
        for (int n = 0; n < count / 4; n++)
        {
            *((int*)pd) = *((int*)ps);
            pd += 4;
            ps += 4;
        }

        // Complete the copy by moving any bytes that weren't
        // moved in blocks of 4:
        for (int n = 0; n < count % 4; n++)
        {
            *pd = *ps;
            pd++;
            ps++;
        }
    }
}

static bool SafeEquals(byte[] a1, byte[] a2)
{
    if (a1 == null || a2 == null || a1.Length != a2.Length)
        return false;
    int length = a1.Length;
    for (int i = 0; i < length; i++)
        if (a1[i] != a2[i]) return false;
    return true;
}

static unsafe bool UnsafeEquals(byte[] a1, byte[] a2)
{
    if (a1 == null || a2 == null || a1.Length != a2.Length)
        return false;
    fixed (byte* p1 = a1, p2 = a2)
    {
        byte* x1 = p1, x2 = p2;
        int l = a1.Length;
        for (int i = 0; i < l / 8; i++, x1 += 8, x2 += 8)
            if (*((long*)x1) != *((long*)x2)) return false;
        if ((l & 4) != 0) { if (*((int*)x1) != *((int*)x2)) return false; x1 += 4; x2 += 4; }
        if ((l & 2) != 0) { if (*((short*)x1) != *((short*)x2)) return false; x1 += 2; x2 += 2; }
        if ((l & 1) != 0) if (*((byte*)x1) != *((byte*)x2)) return false;
        return true;
    }
}

// kulonbozo hivasi konvenciok vannak: ez torli a stack-et, es valtozo szamu parametert is kezel
[DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
static extern int memcmp(byte[] a1, byte[] a2, long count);
static bool PinvokeEquals(byte[] a1, byte[] a2)
{
    if (a1 == null || a2 == null || a1.Length != a2.Length)
        return false;
    // The CLR will automatically pin references to managed objects when the cross the PInvoke boundary
    return memcmp(a1, a2, a1.Length) == 0;
}

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
