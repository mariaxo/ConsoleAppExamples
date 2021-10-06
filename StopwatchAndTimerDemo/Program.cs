using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace StopwatchAndTimerDemo
{
    class Program
    {
		static void Main(string[] args)
		{
			var sw = new Stopwatch();

			//PrintExpression(k => k < 2);

			//Compiling for the first time
			sw.Reset();
			sw.Start();
			var Mmethod = IsLengthGreaterThanFourExpression();
			sw.Stop();
			Console.WriteLine($"Elapsed on compiling for the first time: {sw.Elapsed} sec.");

			//Compiling second time
			sw.Reset();
			sw.Start();
			var method1 = IsLengthGreaterThanFourExpression();
			sw.Stop();
			Console.WriteLine($"Elapsed on compiling for the first time: {sw.Elapsed} sec.");


			Console.WriteLine("\n---------------------------------------------");
			Console.WriteLine("---------------------------------------------\n\n");

			for (int i = 0; i < 3; i++)
			{
				sw.Start();
				var result1 = IsLengthGreaterThanFour("Rafo");
				sw.Stop();
				Console.WriteLine("Calling the ordinary method");
				Console.WriteLine($"Elapsed time in milliseconds: {sw.Elapsed}");
				Console.WriteLine("---------------------------------------------");

				sw.Reset();
				sw.Start();
                var result2 = Mmethod("Rafo");
				sw.Stop();
				Console.WriteLine($"Elapsed time in milliseconds: {sw.Elapsed}");
				var task = Task.Delay(1);
				Console.WriteLine("\n\n\n");
			}
		}

        private static bool IsLengthGreaterThanFour(string v)
        {
            throw new NotImplementedException();
        }

        private static bool IsLengthGreaterThanFourExpression()
        {
            throw new NotImplementedException();
        }
    }
}
