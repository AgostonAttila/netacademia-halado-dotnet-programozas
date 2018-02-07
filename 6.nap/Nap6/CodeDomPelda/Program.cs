using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;

namespace CodeDomPelda
{
    class Program
    {
        static void Main(string[] args)
        {
            CompilerParameters par = new CompilerParameters();
            par.GenerateExecutable = true;
            par.ReferencedAssemblies.Add("System.dll");
            par.OutputAssembly = @"c:\temp\output.exe";
            string keplet = "a*b+a+b+a*a";
            string source = "using System; class Program {" +
                "static void Main(string[] args) {" +
                "Console.WriteLine(\"Hello world \");" +
                "int a=5; int b=3;" +
                "int c=" + keplet + ";"+
                "Console.WriteLine(c);" +
                "}}";

            CompilerResults cr = new CSharpCodeProvider().CompileAssemblyFromSource(par, source);
            if (cr.Errors.Count > 0)
            {
                foreach (var item in cr.Errors)
                {
                    Console.WriteLine(item);
                }
            }

            par.GenerateInMemory = true;
            new CSharpCodeProvider().CompileAssemblyFromSource(par, source)
                .CompiledAssembly.EntryPoint.Invoke(null, new object[] {null});

            Console.ReadLine();
        }
    }
}
