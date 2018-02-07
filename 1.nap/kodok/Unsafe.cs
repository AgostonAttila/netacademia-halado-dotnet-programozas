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