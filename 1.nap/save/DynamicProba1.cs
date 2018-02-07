class Calculator
{
    public int Calc(int a, int b)
    {
        return a + b;
    }
}

class Negyszog { }
class Kor { public void Negyszogesit() { } }
class Ellipszis { public void Negyszogesit() { } }

class Program
{
    static Calculator GetPluginInstance()
    {
        return new Calculator();
    }

    static void Main(string[] args)
    {

        dynamic plugin = GetPluginInstance();

        try
        {
            dynamic res = plugin.Szamol(1, 2);
            Console.WriteLine("Szamol=" + res);
        }
        catch (Exception)
        {
            Console.WriteLine("nincs Szamol metodusa");
        }

        try
        {
            dynamic res = plugin.Calc(1, 2);
            Console.WriteLine("Calc=" + res);
        }
        catch (Exception)
        {
            Console.WriteLine("nincs Calc metodusa");
        }

        // az is praktikus pelda, hogy:
        dynamic grafikus_objektumok = new List<dynamic>();
        grafikus_objektumok.Add(new Kor());
        grafikus_objektumok.Add(new Ellipszis());
        grafikus_objektumok.Add(new Negyszog());
        foreach (var item in grafikus_objektumok)
        {
            try
            {
                item.Negyszogesit();
                Console.WriteLine("OK");
            }
            catch (Exception)
            {
                Console.WriteLine("Hiba");
            }
        }

        Console.ReadLine();
    }
}
