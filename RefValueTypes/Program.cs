using System;
using System.Collections;
using System.Text;

namespace RefValueTypes
{

    interface IGrowable
    {
        int Age { get; set; }
    }
    //structs are always instance 
    struct A
    {
        B b;
        public int a;
        public A(int aa, B bb)
        {
            Console.WriteLine("HEllo");
            b = bb;
            a = aa;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
    class B
    {
        public static int alo = 5;
        public int a;
        public B()
        {

        }
    }


    class Employee
    {
        public static int A = 6;
        public static void Lookup() { }
        public virtual void GenProgressReport() {
            Console.WriteLine("hI FROM eMPLOYEE");
        }
    }
    struct A1 { }
    class Manager : Employee
    {
        public override void GenProgressReport()
        {
            Console.WriteLine("hI FROM manager (overriden)");
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    struct valType
    {
        public int field1;
        public int field2;
        public void Greet()
        {
            this.field1 = 3;
        }
    }

    internal static class extendValType
    {
        public static void Bark(this valType a, string word)
        {
            Console.WriteLine("we extended a value type");
        }
    }
    class Program
    {
        public void Methodd()
        {
            
            StringBuilder sb1 = new StringBuilder("abcd");
            sb1 = new StringBuilder("dcba");

            string st = "abcd";
            st = st + "dcba";


            DateTime dt;

            char[] charArray = new char[6];
            charArray[0] = 'a';

            valType a;
            a.field1 = 1;
            a.field2 = 2;

            valType b = a;
            Console.WriteLine(b.field1);
            Console.WriteLine(b.field1);
        }
        //allocated in the instance object as a field of that instance
        valType fieldOfProgram;


        // C# primitive types (aka built in types) -
        //              any data type the compiler directly supports, they map directly to FCL existing types
        // primitive type C# <-> corresponding FCL type in .Net
        Int32 d = new Int32();
        Int32 d1 = new Int16();
        Int32 d2 = new Byte();
        
        //this fancy new int() will still allocate the variable on the stack, as it's a value type
        //new int() -(for value types) just shows that it's fields are "initialized" to 0
        int a = new int();
        int b = 0;
        //allocated on stack
        int c;

        A objj;

        static void Main(string[] args)
        {

            valType objecttt = new valType();
            objecttt.Bark("Hey");

            //allocated on stack + zeroed the fields, but can't access yet until properly initialized
            valType localVariable;
            
            localVariable.field1 = 6;
            Console.WriteLine(localVariable.field1);



       




            Employee.Lookup();
            Manager.Lookup();
            Employee emp = new Manager();
            emp.GenProgressReport();

            Manager man = emp as Manager;
            man.GenProgressReport();

            Employee employee = new Employee();
            Manager manager = new Manager();
            //Employee.A
            //Manager.A

            A obj;
            A obj2 = new A();
            Console.WriteLine(obj2.a);
            B objjj = new B();
            obj2.a = 2;
            Console.WriteLine(obj2.a);


            T t = new T();
            MethodForT(ref t);
        }
        public static void MethodForT(ref T obj)
        {
            obj = new T() { MyProperty = 28 };
        }
    }

    class T
    {
        public int MyProperty { get; set; }

    }
}

