// const: gyorsabb , readonly: rugalmasabb
public class SomeType
{
    // barmilyen primitiv tipus lehet
    public const int Size = 100;
    public const string Name = "Jakab";
    // nem primitiv tipus eseten csak null ertek lehet
    public const Random r1 = null;
    // public const DateTime d = default(DateTime); // CTE

    // The system always reads the current value of a volatile object at the point it is requested, even 
    // if the previous instruction asked for a value from the same object. Also, the value of the object is written immediately on assignment.
    // The volatile modifier is usually used for a field that is accessed by multiple threads without using the lock statement to serialize access. 
    // Using the volatile modifier ensures that one thread retrieves the most up-to-date value written by another thread.
    public volatile int Egyenleg;

    // nincs verzio problema, es futasidoben inicializalodnak
    public static readonly int MaxSize = 100;
    public static readonly Random r2 = new Random(0);
    public static readonly List<string> Nevek = new List<string>() { "Aladar", "Bela" };
    public static readonly ReadOnlyCollection<string> lista = new ReadOnlyCollection<string>(Nevek); // pl az ev honapjai

    public readonly string FileName = "untitled";
    public SomeType(string fileName)
    {
        // ctor-ban meg lehet modositani vagy beallitani a readonly field-et
        this.FileName = fileName;
    }
}

static void Main(string[] args)
{
    Console.WriteLine(SomeType.Size);
    //SomeType.r2 = new Random(); // cte
    SomeType st = new SomeType("valami.txt");
    Console.WriteLine(st.FileName);
    //st.FileName = ""; // cte
    //SomeType.Nevek = new List<string>(); // cte
    SomeType.Nevek.Add("Cecilia"); // megy !!!
    SomeType.Nevek[1] = "Bence";   // megy !!!

    // SomeType.lista[0] = "a";  // cte, es Add metodus sincsen

    Console.ReadLine();
}
