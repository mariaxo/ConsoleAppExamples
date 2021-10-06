using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LINQ
{
    interface IMyInterace
    {
        //cannot contain instance fields
        //can contain static fields - CLR allows but CLS says u better not do it for intercompatibility between .NET languages
        void Alo1();
        const int A = 3;
        static int B;
        
        static void Alo() { Console.WriteLine("Hello"); }
    }
    class Program
    {
        //[RegularExpression("")]
        public string MyProperty { get; set; }
        static void Main(string[] args)
        {
            decimal a = 1.2m;
            
            //var numbers = new List<int> { 1, 2 };

            //IEnumerable<int> query = numbers.Select(n => n * 10); //build (constructing) query
            //							  // but NOT executing
            //numbers.Add(2); //sneak in an extra element

            //foreach (int n in numbers) //executing here (only when enumerated)
            //    Console.WriteLine(n + "|");

            //int matches = numbers.Where(n => n >= 2).Count();
            ////___________________________________________________________________



            ////to execute immediately and kinda cache the results of the query in an array
            ////call ToList() or similar one immediately
            ////because it will reevaluate every time you use the query

            //    //before
            //IEnumerable<int> query0 = numbers.Select(n => n * 10);
            //foreach (int n in query0) Console.WriteLine(n + "|"); //reevaluates

            //numbers.Clear();
            //foreach (int n in query0) Console.WriteLine(n + "|"); //reevaluates

            //    //now
            //List<int> numbers1 = new List<int> { 1, 2 };
            //List<int> timesTen = numbers.Select(n => n * 10).ToList();

            //numbers.Clear();
            //Console.WriteLine(timesTen.Count); //still 2


            #region capturing a variable for the lambda expression
            ////capturing variables in lambdas
            ////int[] numberss = { 1, 2 };

            ////int factor = 10;
            ////IEnumerable<int> queryy = numbers.Select(n => n * factor); //query is built here

            ////factor = 20;

            ////foreach (int n in queryy) Console.Write(n + "|"); //query runs here
            ////// 20 | 40 , not 10 | 20
            //#endregion

            //#region chaining of queries
            ////IEnumerable<int> a = new int[3] { 1, 3, 4 };
            ////IEnumerable<char> a1 = "Hello";
            ////IEnumerable<char> a3 = new string("Hello");

            ////let's remove all vowels from the string
            //IEnumerable<char> queryyy = "Now what you might expect";

            //queryyy = queryyy.Where(c => c != 'a');
            //queryyy = queryyy.Where(c => c != 'e');
            //queryyy = queryyy.Where(c => c != 'i');
            //queryyy = queryyy.Where(c => c != 'o');
            //queryyy = queryyy.Where(c => c != 'u');

            //foreach (var item in queryyy)
            //{
            //    Console.WriteLine(item);
            //}

            ////the query looks like this now
            ////queryyy = queryyy.Where(c => c != 'a')
            ////                 .Where(c => c != 'e')
            ////                 .Where(c => c != 'i')
            ////                 .Where(c => c != 'o')
            ////                 .Where(c => c != 'u');

            #endregion


            #region using query operators (Essential LINQ) - Where, Select, Aggregate
            #region Restriction Operators [or Filtering Operators] (Where , OfType )
            //public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource,      bool> predicate);
            //public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate);

            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };
            IEnumerable<string> query1 = names.Where(name => name=="Jay").Select(name => name.ToUpper());

            foreach (var item in query1)
            { 
               Console.WriteLine(item);
            }

            //data source
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //query expression definition
            IEnumerable<int> query2 = from number in numbers
                                      where number > 5
                                      select number;
            
            Console.WriteLine("Numbers < 5: ");
            //execute the query
            foreach (int item in query2)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine();
            string[] fruits = new string[]
            {
            "Apple","Mango","Strawberry","Date",
            "Banana","Avocado","Cherry","Grape",
            "Guava","Melon","Orange","Tomato"
            };
            var query = (fruits.Where(fruit => fruit.StartsWith('A'))).Count();
            int count = (from fruit in fruits
                        where fruit.StartsWith('A')
                        select fruit).Count();
            //foreach (var item in query)
            //{
            //    Console.WriteLine(item);
            //}
            Console.WriteLine(count);



            #endregion
            #region Projection Operator (Select,SelectMany)
            List<Person> people = new List<Person>()
            {
                new Person() { ID=1,Name="Ali Asad",Address="Pakistan",Salary=10000},
                new Person() { ID=5,Name="Hamza Ali",Address="Pakistan",Salary=20000},
                new Person() { ID=3,Name="John Snow",Address="Canada",Salary=15000},
                new Person() { ID=2,Name="Lakhtey",Address="Pakistan",Salary=5000},
                new Person() { ID=4,Name="Umar",Address="UK",Salary=25000},
                new Person() { ID=6,Name="Mubashar",Address="Pakistan",Salary=8000},
            };

            var result = from person in people
                         where person.Name.Length > 4
                         select new
                         {
                             PersonId = person.ID,
                             Age = 13
                         };
            foreach (var item in result)
            {
                Console.WriteLine(item.Age + "" + item.PersonId);
            }

            #endregion
            #region Joining Operator
            List<Class> classes = new List<Class>();
            classes.Add(new Class { ClassID = 1, ClassName = "BSCS" });
            classes.Add(new Class { ClassID = 2, ClassName = "BSSE" });
            classes.Add(new Class { ClassID = 3, ClassName = "BSIT" });


            List<Student> students = new List<Student>();
            students.Add(new Student { ClassID = 1, StudentID = 1, StudentName = "Hamza" });
            students.Add(new Student { ClassID = 2, StudentID = 2, StudentName = "Zunaira" });
            students.Add(new Student { ClassID = 1, StudentID = 3, StudentName = "Zeeshan" });


            var queryyy = from student in students
                          join clas in classes
                            on student.ClassID equals clas.ClassID
                          select new
                          {
                              _Student = student.StudentName,
                              _Class = clas.ClassName
                          };

            //var methodQuery = 
            foreach (var item in queryyy)
            {
                Console.WriteLine(item._Student + "\t" + item._Class);
            }
            #endregion
            #region Grouping Operators
            //used to organize a sequence of items into groups of IGroup<key,element>

            //let's organize students by address
            IEnumerable<IGrouping<int, Student>> queryyyy = from student in students
                                                            group student by student.ClassID;

            foreach (var group in queryyyy)
            {
                Console.WriteLine("The group key is: " + group.Key);
                foreach (var student in group)
                {
                    Console.WriteLine("The group items are : " + student.StudentName);
                }
                Console.WriteLine();
            }
            #endregion
            #region Partition Operator (Take, Skip)
            Console.WriteLine();
            //full list
            IEnumerable<Person> result0 = from p in people
                                         where p.Address.StartsWith("P")
                                         select p;
            Console.WriteLine("Full List");
            foreach (var person in result0)
            {
                Console.WriteLine(person.ID + " " + person.Name + " " + person.Address);
            }

            Console.WriteLine();
            //take
            IEnumerable < Person > result1 = (from person in people
                                              where person.Address.StartsWith("P")
                                              select person)
                                        .Take(3);
            Console.WriteLine("Taken 3");
            foreach (var person in result1)
            {
                Console.WriteLine(person.ID + " " + person.Name + " " + person.Address);
            }


            Console.WriteLine();
            //skip
            IEnumerable<Person> result2 = (from p in people
                                           where p.Address.StartsWith("P")
                                           select p).Skip(2);
            Console.WriteLine("Skipped 2 :");
            foreach (var person in result2)
            {
                Console.WriteLine(person.ID + " " + person.Name + " " + person.Address);

            }
            #endregion
            #region Aggregation (return a single value) - Average,Count,Max,Min
            var minSalaryQuery = (from p in people
                                  select p.Salary).Min();
            Console.WriteLine("Min salary is: " + minSalaryQuery);
            #endregion
            #region Order Operator
            Console.WriteLine();
            var orderedPeopleQuery = from person in people
                                     orderby person.ID
                                     select person;
            foreach (var person in orderedPeopleQuery)
            {
                Console.WriteLine(person.ID + " " + person.Name );
            }
            #endregion
            #endregion

            #region Practice exercises
            //exercise 1 : get all marks greater than 60 (Answer B D)
            int[] marks = new int[] { 59, 24, 40, 100, 35, 75, 90 };
            IEnumerable<int> queryy1 = from mark in marks
                                       where mark > 60
                                       select mark;
            //or
            var methodQueryy1 = marks.Where(mark => mark > 60);

            //exercise 2 - the class needs to implement IEnumerable or IQueryable (answer C)


            #endregion

            //var names = new[] { "Tom", "Dick", "Harry", "Mary", "Jay" }.AsQueryable();

            var queryyyyy = from n in names
                            let vowelless = n.Replace("a", "").Replace("e", "").Replace("i", "").Replace("o", "").Replace("u", "")
                            where vowelless.Length > 2
                            orderby vowelless
                            select n;             // Thanks to let, n is still in scope.


            IEnumerable<char> queryyyyyyyyy = (from ch in "HelloWorld"
                                              select ch).Distinct();



          
//            ///
//            PetOwner[] petOwners = {
//    new PetOwner { Name="Higa",
//        Pets = new List<string>{ "Scruffy", "Sam" } },
//    new PetOwner { Name="Hines",
//        Pets = new List<string>{ "Dusty" } }
//};

//            // Project the pet owner's name and the pet's name. 
//            var query = petOwners.SelectMany(petOwner => petOwner.Pets,
//                (petOwner, petName) => new { petOwner, petName })
//                .Select(ownerAndPet =>
//                    new
//                    {
//                        Owner = ownerAndPet.petOwner.Name,
//                        Pet = ownerAndPet.petName
//                    }
//            );
        }
        
        //exercise 3 - 
        public static IEnumerable<int> Page(IEnumerable<int> source, int page, int pageSize)
        {
            return source.Skip(pageSize * (page - 1)).Take(pageSize);
            //Answer A
        }
        class Person
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public decimal Salary { get; set; }
        }

        class Class
        {
            public int ClassID { get; set; }
            public string ClassName { get; set; }
        }
        class Student
        {
            public int StudentID { get; set; }
            public string StudentName { get; set; }
            public int ClassID { get; set; }
        }
    }
}
