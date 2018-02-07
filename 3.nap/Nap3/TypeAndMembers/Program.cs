using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TypeAndMembers
{
    // implicite
    class InternalClass { }

    //static class NemJo : InternalClass { }
    // implicite: sealed, abstract

    // csak public, internal
    public class PublicClass
    {
        // nested class
        // private, public, protected, protected internal, interal
        public class NestedClassPublic
        {
            public class NestedNestedClassPublic { }
            protected class NestedNestedClassProtected { }
            private class NestedNestedClassPrivate { }
        }
        protected class NestedClassProtected
        {

        }
        private class NestedClassPrivate
        {
            public void ProbaMethod()
            {
                PublicClass pc = new PublicClass();
                Console.WriteLine(pc.FieldPrivate);
                Console.WriteLine(pc.FieldProtected);
                NestedClassPrivate ncp = new NestedClassPrivate();
                NestedClassPublic.NestedNestedClassPublic x = new NestedClassPublic.NestedNestedClassPublic();
                // protected es private nem lathato
            }
        }
        class ValamiOsztaly { }


        // mezok
        // private, protected, public
        public string FieldPublic = "valami";
        protected string FieldProtected = "valami";
        private string FieldPrivate = "valami";

        // static mezok
        public const string PublicConst = "valami";
        // ....

        public static string StaticFieldPublic = "valami";
        protected static string StaticFieldProtected = "valami";
        private static string StaticFieldPrivate = "valami";

        public void MPublicClass()
        {
            Console.WriteLine(this.FieldPrivate);
            Console.WriteLine(this.FieldProtected);
            Console.WriteLine(StaticFieldPrivate);
            Console.WriteLine(StaticFieldProtected);
        }

        // ctor
        static PublicClass() { }


        public void InstancePublicMethod() { }
        internal void InstanceInternalMethod() { }

        protected void InstanceProtectedMethod() { }
        protected internal void InstanceProtectedInternalMethod() { }

        private void InstancePrivateMethod() { }

        // private, protected, public 
        public int InstancePropPublic
        {
            get { return 0; }
            set { }
        }

        public int InstancePropMixed1
        {
            protected get { return 0; }
            set { }
        }
        public int InstancePropMixed2
        {
            get { return 0; }
            private set { }
        }
        /*public int InstancePropMixed3
        {
            protected get { return 0; }
            private set { }
        }*/

        // static property-k: private, protected, public 

        // parameteres property: indexelok

        // event
        // enum
        public enum PublicEnum { Black, White }
        internal enum InternalEnum { Black, White }
        protected enum ProtectedEnum { Black, White }
        protected internal enum ProtectedInternalEnum { Black, White }
        private enum PrivateEnum { Black, White }
    }

    public sealed class PublicClass2 : PublicClass
    {

    }
    // public sealed class PublicClass3 : PublicClass2 { }

    public sealed class Alaposztaly
    {

    }

    // reszleges osztaly
    public partial class Dolgozo
    {
        partial void Dolgozz()
        {
            Console.WriteLine("dolgozok ...");
        }

        public void SzeretnekEbedelni()
        {
            this.Dolgozz();
            this.MenjHaza(); // ez nem fordul be
        }

    }

    public partial class Dolgozo
    {

    }

    public abstract class AbstractClass
    {
        public string Nev = "Valami";
        public void M() { }
        public abstract void AM();
        public AbstractClass()
        {
            this.Nev = "Gipsz Jakab";
        }

    }

    public abstract class AbstractClass2 : AbstractClass
    {

    }

    public class KonkretClass : AbstractClass
    {
        public override void AM()
        {
            Console.WriteLine(this.Nev);
        }
    }

    public class KonkretClass2 : KonkretClass
    {
        public new virtual void AM() // lehet siman override
        {
            Console.WriteLine("ujkiiras: " + this.Nev);
        }
    }

    public class DerivedClass : PublicClass
    {

        public void MDerivedClass()
        {
            // Console.WriteLine(this.FieldPrivate); // CTE
            Console.WriteLine(this.FieldProtected);
            // Console.WriteLine(StaticFieldPrivate);
            Console.WriteLine(StaticFieldProtected);

        }
    }

    class Furcsasag : PublicClass.NestedClassPublic
    {


    }

    class Program
    {
        static void Main(string[] args)
        {
            //InternalClass ic = new InternalClass();
            PublicClass pc = new PublicClass();

            pc.InstancePropPublic = 1;
            Console.WriteLine(pc.InstancePropPublic);
            pc.InstancePropMixed1 = 1;
            // Console.WriteLine(pc.InstancePropMixed1);
            // belul vagy leszarmazott

            // pc.InstancePropMixed2 = 1;
            Console.WriteLine(pc.InstancePropMixed2);

            Dolgozo d = new Dolgozo();
            d.SzeretnekEbedelni();

            // AbstractClass ab = new AbstractClass();
            KonkretClass kc = new KonkretClass();
            kc.AM();

            AbstractClass ab = kc;
            ab.AM();

            // HF: dll keszites


            Console.ReadLine();
        }
    }
}
