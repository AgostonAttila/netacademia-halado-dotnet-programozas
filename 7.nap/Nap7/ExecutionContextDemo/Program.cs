using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Messaging;
using System.Threading;

namespace ExecutionContextDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            CallContext.LogicalSetData("euro", "307");
            ThreadPool.QueueUserWorkItem(
                o => { Console.WriteLine("elso: " + CallContext.LogicalGetData("euro")); }
                );

            ExecutionContext.SuppressFlow();

            ThreadPool.QueueUserWorkItem(
                o => { Console.WriteLine("masodik: " + CallContext.LogicalGetData("euro")); }
                );

            ExecutionContext.RestoreFlow();

            ThreadPool.QueueUserWorkItem(
                o => { Console.WriteLine("harmadik: " + CallContext.LogicalGetData("euro")); }
                );

            // Interlocked.
            Console.ReadLine();
        }
    }
}
