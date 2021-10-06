using System;
using OOP_Programming; 

namespace OOP_Principles
{
    class Program
    {
        static void Main(string[] args)
        {
            Lion obj = new Lion();
            P1.M2();
            P1 objj = new P1();          
        }
    }

    class NC : Program
    {
        int a;
        public int MyProperty 
        {
            get
            {
                return 1;
            }
            set
            {
                a = value;
            }
        }
        
    }

    class Animal
    {
        protected string name = "Hey";

        public Animal()
        {
           
        }
    }

    class Lion : Animal
    {
        
        public Lion() : base()
        {
            name = "Elen";
            Console.WriteLine(this.name + base.name);
        }
    }

    public class Singleton

    {
        // The single instance
        private static Singleton instance;

        // Initialize the single instance

        static Singleton()
        { 
            instance = new Singleton();
        }

        // The property for retrieving the single instance

        public static Singleton Instance
        {
            get { return instance; }
        }

        // Private constructor: protects against direct instantiation
        private Singleton() { }
    }
}
