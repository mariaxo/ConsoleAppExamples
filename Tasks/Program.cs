using System;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks
{
    //class Program1
    //{
    //    static void Main(string[] args)
    //    {
    //        Console.WriteLine($"Main thread id is: {Thread.CurrentThread.ManagedThreadId}");
    //        M2();

    //        Task a = M1();
    //    }

    //    public static async void M2()
    //    {
    //        Console.WriteLine($"M2 thread id is: {Thread.CurrentThread.ManagedThreadId}");
    //        await M1();
    //        for (int i = 0; i < 100; i++)
    //        {
    //            string s = "a";
    //        }
    //        Console.WriteLine($"M2  second thread id is: {Thread.CurrentThread.ManagedThreadId}");

    //    }

    //    public static async Task M1()
    //    {
    //        Console.WriteLine($"M1 thread id is: {Thread.CurrentThread.ManagedThreadId}");

    //        await Task.Run(() =>
    //        {
    //            // Just loop.
    //            int ctr = 0;
    //            for (ctr = 0; ctr <= 1000000; ctr++)
    //            {
    //                Console.WriteLine("Finished {0} loop iterations",
    //                               ctr);
    //            }

    //        });
    //    }
    //}



    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine($"Main thread id is: {Thread.CurrentThread.ManagedThreadId}");
            await M2();

            Console.WriteLine("Printing from the Main method.");
            Console.WriteLine($"Main thread id is: {Thread.CurrentThread.ManagedThreadId}");



            Console.ReadLine();
            //Task a = M1();
        }

        public static async Task M2()
        {
            Console.WriteLine("Printing from the M2 method.");
            Console.WriteLine($"M2 thread id is: {Thread.CurrentThread.ManagedThreadId}");

            await Task.Delay(5000);
            Console.WriteLine($"M2 thread id is: {Thread.CurrentThread.ManagedThreadId}");

            Console.WriteLine("Printing from the M2 method after awaiting.");


        }

    }
}

