using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppExamples
{
    public class Records
    {
        public record Person(string LastName, string FirstName, DateTime DateOfBirth);
        public record Car(string Model, int Year);
    }
}
