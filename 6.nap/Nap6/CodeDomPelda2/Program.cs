using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using System.CodeDom;
using System.IO;

namespace CodeDomPelda2
{
    public class KodGenerator
    {
        CodeNamespace mynamespace;
        CodeTypeDeclaration myclass;
        CodeCompileUnit myassembly;
        public KodGenerator()
        {
            mynamespace = new CodeNamespace("mynamespace");
            mynamespace.Imports.Add(new CodeNamespaceImport("System"));
        }
        public void CreateClass()
        {
            myclass = new CodeTypeDeclaration();
            myclass.Name = "Myclass";
            myclass.IsClass = true;
            myclass.Attributes = MemberAttributes.Public;
            mynamespace.Types.Add(myclass);
        }
        public void CreateEntryPoint()
        {
            CodeEntryPointMethod mymain = new CodeEntryPointMethod();
            mymain.Name = "Main";
            mymain.Attributes = MemberAttributes.Public | MemberAttributes.Static;
            CodeSnippetExpression exp1 = new CodeSnippetExpression("Myclass x = new Myclass()");
            CodeSnippetExpression exp2 = new CodeSnippetExpression("Console.WriteLine(\"Hello world\")");
            CodeSnippetExpression exp3 = new CodeSnippetExpression("Console.ReadLine()");
            CodeExpressionStatement ces1 = new CodeExpressionStatement(exp1);
            CodeExpressionStatement ces2 = new CodeExpressionStatement(exp2);
            CodeExpressionStatement ces3 = new CodeExpressionStatement(exp3);
            mymain.Statements.Add(ces1);
            mymain.Statements.Add(ces2);
            mymain.Statements.Add(ces3);
            myclass.Members.Add(mymain);
        }
        public void SaveAssembly()
        {
            myassembly = new CodeCompileUnit();
            myassembly.Namespaces.Add(mynamespace);
            CompilerParameters comparam = new CompilerParameters(new string[] { "mscorlib.dll" });
            comparam.ReferencedAssemblies.Add("System.dll");
            comparam.GenerateInMemory = false;
            comparam.GenerateExecutable = true;
            comparam.MainClass = "mynamespace.Myclass";
            comparam.OutputAssembly = @"c:\temp\HelloWorld.exe";
            Microsoft.CSharp.CSharpCodeProvider ccp = new Microsoft.CSharp.CSharpCodeProvider();
            StreamWriter sw = new StreamWriter(@"c:\temp\HelloWorld.cs");
            // ez is jo:
            // IndentedTextWriter
            // ???
            IndentedTextWriter idt = new IndentedTextWriter(sw, " ");
            idt.Indent = 1;
            ICodeGenerator cscg = ccp.CreateGenerator(idt);
            ICodeCompiler icc = ccp.CreateCompiler();
            CompilerResults compres = icc.CompileAssemblyFromDom(comparam, myassembly);
            cscg.GenerateCodeFromNamespace(mynamespace, idt, new CodeGeneratorOptions());
            idt.Close();
            if (compres == null || compres.Errors.Count > 0)
            {
                for (int i = 0; i < compres.Errors.Count; i++)
                {
                    Console.WriteLine(compres.Errors[i]);
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            KodGenerator cg = new KodGenerator();
            cg.CreateClass();
            cg.CreateEntryPoint();
            cg.SaveAssembly();
            Console.ReadLine();
        }
    }
}
