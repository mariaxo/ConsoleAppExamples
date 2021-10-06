using System;
using System.IO;

namespace ExceptionHandling
{
    class ProblematicClass
    {
        public void M1() 
        {
            try
            {
                M2();
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.StackTrace);
            }
        }
        public void M2()
        {
            try
            {
                M3();
            }
            catch (Exception ex)
            {
                //deletes the whole stack trace before, then adds itself to the stack trace, then throws up
                //pretending that he is the source of the exception thown
                throw ex;

                //throw;
            }
        }
        public void M3()
        { 
            try
            {
                M4();
            }
            catch (Exception ex)
            {
                // adds itself to the stack trace, then throws the same exception it caught up in the call stack
                throw;
            }
        }

        public void M4()
        {
            throw new InvalidCastException();
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            //example 1 - trying different throws

            //ProblematicClass obj = new ProblematicClass();
            //obj.M1();
            //Console.ReadLine();

            //example 2 with the method ReadFile

            //try
            //{
            //    string fileName = "WrongFileName.txt";
            //    ReadFile(fileName);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.StackTrace);
            //    Console.WriteLine();
            //    Console.WriteLine(e.InnerException);
            //    throw new ApplicationException("Smth bad happened", e);

            //try
            //{
            //  M1();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.StackTrace);
            //    Console.WriteLine();
            //    throw;
            //}


            try
            {
                Method();
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine();
                Console.WriteLine(e.InnerException);
                Console.WriteLine();
                throw;
            }
        }

        //
        static void M1() { M2(); }
        static void M2()
        {
            throw new ApplicationException("Smth bad happened"); 
        }
        //
        
        static void Method()
        {
            try
            {
                string fileName = "WrongFileName.txt";
                ReadFile(fileName);
            }
            catch (Exception e)
            {
                //Console.Beep();
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine();
                Console.WriteLine(e.InnerException);
                //throw new ApplicationException("Smth bad happened", e);
                throw e;
                //throw;
            }
        }

        static void ReadFile(string fileName)
        {
            TextReader reader = new StreamReader(fileName);
            string line = reader.ReadLine();
            Console.WriteLine(line);
            reader.Close();
        }
    }

}
