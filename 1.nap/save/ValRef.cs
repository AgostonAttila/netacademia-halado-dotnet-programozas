// Reference type (because of 'class')
private class SomeRef { public Int32 x; }

// Value type (because of 'struct')
private struct SomeVal { public Int32 x; }

public static void Go()
{
    SomeRef r1 = new SomeRef();   // Allocated in heap
    SomeVal v1 = new SomeVal();   // Allocated on stack
    r1.x = 5;                     // Pointer dereference
    v1.x = 5;                     // Changed on stack
    Console.WriteLine(r1.x);      // Displays "5"
    Console.WriteLine(v1.x);      // Also displays "5"
    // The left side of Figure 5-2 reflects the situation
    // after the lines above have executed.

    SomeRef r2 = r1;              // Copies reference (pointer) only
    SomeVal v2 = v1;              // Allocate on stack & copies members
    r1.x = 8;                     // Changes r1.x and r2.x
    v1.x = 9;                     // Changes v1.x, not v2.x
    Console.WriteLine(r1.x);      // Displays "8"
    Console.WriteLine(r2.x);      // Displays "8"
    Console.WriteLine(v1.x);      // Displays "9"
    Console.WriteLine(v2.x);      // Displays "5"
    // The right side of Figure 5-2 reflects the situation 
    // after ALL the lines above have executed.
}

private struct Point { public Int32 x, y;  }

static void Main(string[] args)
{
    Go();

    // boxing unboxing
    ArrayList a = new ArrayList();
    a.Add(1);
    a.Add(true);

    Int32 x = 5;
    Object o = x;                 // Box x; o refers to the boxed object
    Int16 y = (Int16)(Int32)o;    // Unbox to the correct type and cast

    Point p;
    p.x = p.y = 1;
    o = p;   // Boxes p; o refers to the boxed instance
    // Change Point’s x field to 2
    p = (Point)o;  // Unboxes o AND copies fields from boxed 
    // instance to stack variable
    p.x = 2;        // Changes the state of the stack variable
    o = p;          // Boxes p; o refers to a new boxed instance

    // nem hatekony:
    Int32 v = 5;            // Create an unboxed value type variable.
    o = v;            // o refers to a boxed Int32 containing 5.
    v = 123;                 // Changes the unboxed value to 123
    // reflectorral megnezni
    Console.WriteLine(v + ", " + (Int32)o);	// Displays "123, 5"

    // nem hatekony
    Console.WriteLine("{0}, {1}, {2}", v, v, v);
    o = v;  // Manually box v (just once).
    // No boxing occurs to compile the following line.
    Console.WriteLine("{0}, {1}, {2}", o, o, o);

    Console.ReadLine();
}
