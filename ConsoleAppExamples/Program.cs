using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace ConsoleAppExamples
{
    class Program
    {
        static void Main(string[] args)
        {



            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("aaa","bbb");
            dict.Add("sss","jjj");
            dict.Add("rrr","uuu");
            dict.Add("ccc","dd");
            dict.Add("asdf","dd");
            dict.Add("safsa","dd");
            dict.Add("sadfsa","dd");
            dict.Add("sacdfsa","dd");

            #region example 1

            //example 1
            //string personName = "";
            //                                //the expression we tried to created an expression tree from
            //var greetingExpression_Result = !string.IsNullOrWhiteSpace(personName) ? "Greetings, " + personName : null;
            //// string? GetGreeting(string personName) { /* ... */ }



            //var methodDel = Construct_GreetingFunction();
            //Console.WriteLine(methodDel("Maria"));
            ////expressions compile once, so after this, it will start working really fast, won't compile anymore
            //Console.WriteLine(methodDel(""));
            #endregion

            #region example 2
            // expression is: num => num < 5

            //casting to a Expression<TDelegate> or LambdaExpression classes
            var expression = Construct_Expression1();

            //casting to Expression<TDelegate> to be able to Compile
            // Expression<TDelegate> : LambdaExpression : Expression
            var lambdaExpression = (Expression<Func<int, bool>>)expression;

            var delegateToUse = lambdaExpression.Compile();
            Console.WriteLine("{0},{1}", delegateToUse(5), delegateToUse(2));

            //no need to cast here
            Expression<Func<int,bool>> lambdaExpressionn = Construct_Expression2();
            Func<int,bool> delegateToUse2 = lambdaExpressionn.Compile();
            Console.WriteLine(delegateToUse2.Invoke(5));


            //parsing the Expression trees

            //these classes override their ToString() method so we can print

            ParameterExpression param = (ParameterExpression)lambdaExpression.Parameters[0];
            BinaryExpression operation = (BinaryExpression)lambdaExpression.Body;
            ParameterExpression leftOperand = (ParameterExpression)operation.Left;
            ConstantExpression rightOperand = (ConstantExpression)operation.Right;

            Console.WriteLine("Decomposed expression is {0} => {1} {2} {3}", param,leftOperand, operation.NodeType, rightOperand );



            #endregion

            //generic operator creation

            //not a good way as we recompile for no reason and generate the delegate all the time
            ThreeFourthsOf<int>(4);
            //best way, using the class I made
            ThreeFourths.Calculate<int>(4);

            #region Dynamic Querying, changing queries dynamically with Expression trees

            #region example 1 - query changes when the local parameter changes ??
         
                //usign an in-memory array as the data source
                //but the IQueryable could have come from anywhere - web request, an ORM backed database, or any other LINQ provider
            var companyNames = new[] {
                                "Consolidated Messenger", "Alpine Ski House", "Southridge Video",
                                "City Power & Light", "Coho Winery", "Wide World Importers",
                                "Graphic Design Institute", "Adventure Works", "Humongous Insurance",
                                "Woodgrove Bank", "Margie's Travel", "Northwind Traders",
                                "Blue Yonder Airlines", "Trey Research", "The Phone Company",
                                "Wingtip Toys", "Lucerne Publishing", "Fourth Coffee"
            };

                //making the IEnumerable to IQueryable, to use its methods with expression tree parameters
            IQueryable<string> companyNamesSource = companyNames.AsQueryable();


            var length = 1;
            var qry = companyNamesSource
                .Select(x => x.Substring(0, length))
                .Distinct();

            Console.WriteLine(string.Join(",", qry));
                // prints: C, A, S, W, G, H, M, N, B, T, L, F

            length = 2;
            Console.WriteLine(string.Join(",", qry));
                // prints: Co, Al, So, Ci, Wi, Gr, Ad, Hu, Wo, Ma, No, Bl, Tr, Th, Lu, Fo

            #endregion
            
            //#region example 2 - vary the expression tree passed into the LINQ methods
            
            ////uses switch expressions

            //string? startsWith = "aaa";
            //string? endsWith = "bbb";

            //Expression<Func<string, bool>> expr = (startsWith, endsWith) switch
            //{
            //    ("" or null, "" or null) => x => true,
            //    (_, "" or null) => x => x.StartsWith(startsWith),
            //    ("" or null, _) => x => x.EndsWith(endsWith),
            //    (_, _) => x => x.StartsWith(startsWith) || x.EndsWith(endsWith)
            //};

            //var query = companyNamesSource.Where(expr);
            //#endregion

            //#region example 3 - construct expression trees and queries (with Expression's factory methods)
            //in all the examples above, at compile time we knew the element type -  string
            //means the query type was IQueryable<string>

            //what if depending on the element type we want to add components to the query?
            // solution - build the expression tree from scratch depening on the type


            //problem - - -
                //filter the entries and return only those who have the given text inside (term)
            
            // for Car search the Model proerty
            string term = "BMW";
            var carsQuery = new List<Records.Car>().AsQueryable().Where(x => x.Model.Contains(term));

            // for Person - search the FirstName and LastName properties
            var personsQuery = new List<Records.Person>().AsQueryable().Where(x => x.FirstName.Contains(term) || x.LastName.Contains(term));

            #endregion

            
        }



        //manually building the expression tree of an expression
        public static Func<string, string?> Construct_GreetingFunction()
        {
            ParameterExpression personNameParameter = Expression.Parameter(typeof(string), "personName");

            //reflection needed to obtain a reference to the desired method
                var method_IsNullOrWhitespace = Expression.Call(typeof(string).GetMethod(nameof(string.IsNullOrWhiteSpace)), personNameParameter);
                var negation = Expression.Not(method_IsNullOrWhitespace);
            var condition = negation;

            //
            var constant = Expression.Constant("Greetings, ");
            //concat creates an ambigous match, so we need to provide (3rd overload)
            var concatMethod = typeof(string).GetMethod(nameof(string.Concat), new[] { typeof(string), typeof(string) });
            var methodCall  = Expression.Call(concatMethod, constant, personNameParameter);
            var trueClause = methodCall;

            //
            var FalseClause = Expression.Constant(null, typeof(string));


            var finalExpression = Expression.Condition(condition, trueClause, FalseClause);


            //to be able to evaluate this expression, we need to create an entry point
            //for that we need to wrap this in a lambda expression
            var lambdaExpression = Expression.Lambda<Func<string, string?>>(finalExpression, personNameParameter);
            return lambdaExpression.Compile();

        }
        public static Expression Construct_Expression1()
        {
            var constant = Expression.Constant(5, typeof(int));
            var parameter = Expression.Parameter(typeof(int), "num");
            var binaryOperation = Expression.LessThan(parameter, constant);


            var lambdaExpression = Expression.Lambda(binaryOperation, parameter);
            return lambdaExpression;
        }
        public static Expression<Func<int,bool>> Construct_Expression2()
        {
            var constant = Expression.Constant(5, typeof(int));
            var parameter = Expression.Parameter(typeof(int), "num");
            var binaryOperation = Expression.LessThan(parameter, constant);

            //adding the type of the delegate
            var lambdaExpression = Expression.Lambda<Func<int,bool>>(binaryOperation, parameter);
            return lambdaExpression;
        }


        //implementing generic operators

        //we know that expression gets compiled, so we need to use this advantage to compile it once, and then use it as much as desired
        
        //this is bad, as we don't use our advantage of expressions being compiled
        public static T ThreeFourthsOf<T>(T x)
        {
            //let's generate the delegate which wil handle the solution
            var param = Expression.Parameter(typeof(T));

            //cast the numbers 3 and 4 to our T type
            var three = Expression.Convert(Expression.Constant(3), typeof(T));
            var four = Expression.Convert(Expression.Constant(4), typeof(T));

            var operation = Expression.Divide(Expression.Multiply(param, three), four);

            //creating the lambda expression
            // (T num) => 3 * num / 4
            var lambda = Expression.Lambda<Func<T, T>>(operation, param);
            var deleg = lambda.Compile();

            return deleg(x);
        }

        //now, modifying and creating a class for that...

    }

  
}
