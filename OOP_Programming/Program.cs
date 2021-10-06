using System;

namespace OOP_Programming
{
    public class BaseClass
    {
        public int a;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        //protected field can be used in a derived class implementation only
        private void B_PrivateMethod()
        {
            Console.WriteLine("Accessible only by the defining class. Not usable from the outside.");
        }
        private protected void B_PrivateProtected()
        {
            Console.WriteLine("Protected but only for this assembly. Meaning accessible onl");
        }
        protected void B_Protected()
        {
            Console.WriteLine("Is Protected in this and other assemblies.");
        }
        internal void B_Internal()
        {
            Console.WriteLine("Is fully accessible in this assembly!");
        }
        protected internal void B_ProtectedInternal()
        {
            Console.WriteLine("Is fully accessible in this assembly, but is Protected only for other assemblies ");
        }
        public void B_PublicMethod()
        {
            Console.WriteLine("Accessible in any code pretty much, just give a reference to the project and import the namespace.");
        }
    }

    public class DerivedClass : BaseClass
    {
        void Method(string[] args)
        {
            //protected method
            
           
        }
    }

    class Other
    {
        static void Method(Program obj, P1 obj2)
        {
            obj.M2();
            
            obj2.M1();
            Console.WriteLine("Hello World!");
        }
    }
}
