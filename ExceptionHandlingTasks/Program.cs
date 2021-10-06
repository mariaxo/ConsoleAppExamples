using System;
using System.Threading;

namespace ExceptionHandlingTasks
{
    class Program
    {
        public static void Main()
        {
            try
            {
                new Thread(Go).Start();
            }
            catch (Exception ex)
            {
                // We'll never get here!
                Console.WriteLine($"Exception! is {ex}");
            }
        }

        static void Go() { throw new Exception(); }   // Throws a NullReferenceException
    }
}
