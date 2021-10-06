using System;
using System.Threading;
using System.Threading.Tasks;

namespace TasksExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Main method being executed by {Thread.CurrentThread.ManagedThreadId}");

            Task newTask = M1();
            newTask.ContinueWith(x => 
                            Console.WriteLine($"Contineue with method being executed by {Thread.CurrentThread.ManagedThreadId}"));

            Console.WriteLine($"Main method being executed by {Thread.CurrentThread.ManagedThreadId} after continue with.");
        }

        static async Task M1()
        {
            Console.WriteLine($"M1 method being executed by {Thread.CurrentThread.ManagedThreadId}");
            await Task.Delay(1000);

            Console.WriteLine($"M1 method being executed by {Thread.CurrentThread.ManagedThreadId}");

        }
    }
}
