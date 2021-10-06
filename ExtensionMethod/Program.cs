using System;

namespace ExtensionMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = (TheBest)null;
            a.M2(); //works fine even tho it's null (cz extension method)
            a.M();

        }

        
        

    }

    public class TheBest
    {
        public void M() { }
    }


    static class Ext
    {
        public static void M2(this TheBest t)
        {

        }
    }
}
