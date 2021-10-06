using System;

namespace Statics
{
    class StaticClass
    {
        static int a = 6;
        int b;
        public StaticClass()
        {
            //this is not logical, the static field kinda is now a part of the instance fields as it gets modified with every
            //instance creation ---> better use a static constructor if you dk the values beforehand to intialize 
            a = 7;
        }

        //no access modifiers for static ctors, as they are executed once per type and automatically
        //must be parameterless
        static StaticClass()
        {
            a = 7;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Max entries supported in list: "
            + SomeLibraryType.MaxEntriesInList);
        }
    }
    class A
    {
        protected int a;
    }
    class B : A
    {
        //protected int c;
        void M1()
        {
            a = 3;
        }
    }
    class C : B
    {
        void M2()
        {
            a = 7;
           // c = 8;
        }
    }
    struct ValType
    {
        //const int a = 6;
        readonly int b;
        public ValType(int arjeq)
        {
            b = arjeq;
        }
        //static readonly int c = 6;
        //static int d = 7;
        //int c = 7;
    }
    public sealed class SomeLibraryType
    {
        // NOTE: C# doesn't allow you to specify static for constants
        // because constants are always implicitly static.

        public const Int32 MaxEntriesInList = 50;
        public static readonly Int32 MaxEntriesInList2 = 50;
        public static Int32 MaxEntriesInList1 = 50;

        public readonly Int32 MaxEntriesInList3 = 50;

        public Int32 MaxEntriesInList4 = 50;
    }
}
