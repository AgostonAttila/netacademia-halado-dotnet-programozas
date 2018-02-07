static void Main(string[] args)
{
    Console.WriteLine("string=" + typeof(string).IsPrimitive); // False
    Console.WriteLine("int=" + typeof(int).IsPrimitive);    // True


    // minden ami a System nevterben van: int,char,bool,dooble,object,string,dynamic (decimal nem !!!)
    //int szam = 3000000000; // cte
    uint szam = 3000000000;
    long szam2 = 999999999999;
    long szam3 = 999999999999L;
    Console.WriteLine(szam2);

    int szam4 = (int)szam2;
    Console.WriteLine(szam4);
    // int szam5 = (int)999999999999L; // cte
    unchecked // igy megy
    {
        int szam5 = (int)999999999999L;
        Console.WriteLine(szam5);
    }
    int szam6 = unchecked((int)999999999999L);
    Console.WriteLine(szam6);

    int szam7 = (int)6.8; // ez megy
    Console.WriteLine(szam7); // truncate

    byte b = 100;
    // b = checked((byte)(b + 300)); // overflowexception
    b = (byte)(b + 300);
    Console.WriteLine(b);

    checked
    {
        byte bb = 100;
        Add(ref bb, 200); // metodushivasra nem hat a a checked!!!!
        Console.WriteLine(bb);
    }

    Console.WriteLine(true | false); // logical and bitwise
    Console.WriteLine(true & false); // logical and bitwise
    Console.WriteLine(4 | 8 | 16); // logical and bitwise
    Console.WriteLine(true || false); // conditional
    Console.WriteLine(true && false); // conditional

    Console.ReadLine();
}

public static void Add(ref byte b, byte mennyit)
{
    b += mennyit;
}

