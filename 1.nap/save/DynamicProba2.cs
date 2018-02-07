// PHP, JavaScript
// No compile time error, no intellisense
// COM interop visszater dynamic objektumokkal... (azokat elvileg eddig System.Object-kent kezelt a .NET)
private static dynamic Dupla(dynamic arg) { return arg + arg; }

private static void M(Int32 n) { Console.WriteLine("M(Int32): " + n); }
private static void M(String s) { Console.WriteLine("M(String): " + s); }

static void Main(string[] args)
{
    for (Int32 demo = 0; demo < 2; demo++)
    {
        dynamic arg = (demo == 0) ? (dynamic)5 : (dynamic)"A";
        dynamic result = Dupla(arg);
        M(result);
    }

    Object o = 123;      // OK: Implicit cast from Int32 to Object
    //Int32 n1 = o;      // Error: No implicit cast from Object to Int32
    Int32 n2 = (Int32)o; // OK: Explicit cast from Object to Int32

    dynamic d = 123;    // OK: Implicit cast from Int32 to dynamic
    Int32 n3 = d;       // OK: Implicit cast from dynamic to Int32

    //dynamic m = M(d);     // Note: 'var m' is the same as 'dynamic m'
    // void lenne a visszatereesi ertek, RuntimeBinder Exception
    var x = (Int32)d;       // 'var x' is the same as 'Int32 x'
    var dt = new DateTime(d);  // 'vat dt' is the same as 'DateTime dt'


    // ilyet is lehet
    dynamic din = new List<dynamic>();
    din.Add(1);
    din.Add("A");
    din.Add(Math.PI);
    foreach (var item in din)
    {
        Console.WriteLine(item);
    }
    // ilyet is
    dynamic sql = new SqlConnection("");
    using (sql)
    {
        // sql.Open();
    }
    // sql.XXX(); // runtimebinder exception


    // igy sokkal nehezebb:
    object target = "IT Factory";
    object ar = "IT";
    Type[] argTypes = new Type[] { ar.GetType() };
    MethodInfo method = target.GetType().GetMethod("Contains", argTypes);
    object[] arguments = new object[] { ar };
    bool res = Convert.ToBoolean(method.Invoke(target, arguments));
    Console.WriteLine(res);

    dynamic trg = "IT Factory";
    dynamic a = "IT";
    Console.WriteLine(trg.Contains(a));

    Console.ReadLine();
}
