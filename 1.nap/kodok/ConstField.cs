public class SomeType
{
    public const int Size = 100;
    public const string Name = "Jakab";
    public const Random r1 = null;
    // public const DateTime d = default(DateTime); // CTE

    public volatile int Egyenleg;

    public static readonly int MaxSize = 100;
    public static readonly Random r2 = new Random(0);
    public static readonly List<string> Nevek = new List<string>() { "Aladar", "Bela" };

    public readonly string FileName = "untitled";
    public SomeType(string fileName)
    {
        this.FileName = fileName;
    }
}
