static void Main(string[] args)
{

    List<int> realList = new List<int>();

    dynamic exposedList = ExposedObject.From(realList);

    // Read a private field - prints 0
    Console.WriteLine(exposedList._size);
    // Modify a private field
    exposedList._items = new int[] { 5, 4, 3, 2, 1 };
    // Modify another private field
    exposedList._size = 5;
    // Call a private method
    exposedList.EnsureCapacity(20);
    // Add a value to the list
    //exposedList.Add(0);

    // Enumerate the list. Prints "5 4 3 2 1 0"
    foreach (var x in exposedList) Console.WriteLine(x);

    // osztaly lekerdezese
    dynamic matek = ExposedClass.From(typeof(System.Math));
    Console.WriteLine(matek.Max(123,321));

    // dinamukus propery
    dynamic din = new ExpandoObject();
    din.X = 1;
    din.Y = 12;
    din.ShowMe = new Action(() => Console.WriteLine("{0},{1}", din.X, din.Y));
    Console.WriteLine(din.X);
    // Console.WriteLine(din.Z); // runtimebinder exception
    din.ShowMe();


    Console.ReadLine();
}
