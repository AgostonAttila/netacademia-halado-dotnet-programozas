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

