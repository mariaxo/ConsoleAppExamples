using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace ThreadingDemo
{
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        //Thread thread1 = new Thread((x) => Console.WriteLine($" {x} Hello from Maria's thread."));
    //        Thread thread1 = new Thread(mythread);
    //        thread1.Name = "Maria Thread";
    //        thread1.IsBackground = true;

    //        //thread1.Start("Hey - "); //the real thread is being created here, so it's a heavy process
    //        thread1.Start(); //the real thread is being created here, so it's a heavy process
    //        Console.WriteLine("Hey!");
    //    }

    //    static void mythread()
    //    {
    //        for (int c = 0; c <= 3; c++)
    //        {

    //            Console.WriteLine("mythread is in progress!!");
    //            Thread.Sleep(1000);
    //        }
    //        Console.WriteLine("mythread ends!!");
    //    }
    //}



    //class Program
    //{
    //    static int x = 0;
    //    static void Main(string[] args)
    //    {
    //        for (int i = 0; i < 5; i++)
    //        {
    //            Thread myThread = new Thread(Count);
    //            myThread.Name = "Thread " + i.ToString();
    //            myThread.Start();
    //        }

    //        Console.ReadLine();
    //    }
    //    public static void Count()
    //    {
    //        x = 1;
    //        for (int i = 1; i < 9; i++)
    //        {
    //            Console.WriteLine("{0}: {1}", Thread.CurrentThread.Name, x);
    //            x++;
    //            Thread.Sleep(100);
    //        }
    //    }
    //}
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine("Main thread: starting a dedicated thread " +
            "to do an asynchronous operation");
            
            
            Thread dedicatedThread = new Thread(ComputeBoundOp);
            Console.WriteLine("Is a foreground thread so they always complete then the process dies. Regardless of the main thread.");
            
            dedicatedThread.Start(5); //thread created here
            Console.WriteLine("Main thread: Doing other work here...");
            Thread.Sleep(10000); // Simulating other work (10 seconds)
            
            
            dedicatedThread.Join(); // Wait for thread to terminate
            Console.WriteLine();
            Console.WriteLine("Hit <Enter> to end this program...");
            Console.ReadLine();
        }
        // This method's signature must match the ParameterizedThreadStart delegate
        private static void ComputeBoundOp(Object state)
        {
            // This method is executed by a dedicated thread
            Console.WriteLine("In ComputeBoundOp: state={0}", state);
            Thread.Sleep(1000); // Simulates other work (1 second)
                                // When this method returns, the dedicated thread dies
        }
    }
}
