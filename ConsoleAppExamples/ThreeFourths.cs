using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppExamples
{
    //by the means of these classes, we compile the expression once
    public static class ThreeFourths
    {
        private static class Impl<T>
        {
            public static Func<T, T> Of { get; }
            static Impl()
            {
                var param = Expression.Parameter(typeof(T));
                var three = Expression.Convert(Expression.Constant(3), typeof(T));
                var four = Expression.Convert(Expression.Constant(4), typeof(T));

                var operation = Expression.Divide(Expression.Multiply(param, three), four);

                var lambda = Expression.Lambda<Func<T, T>>(operation, param);
                Of = lambda.Compile();
            }
        }
        public static T Calculate<T>(T x) => Impl<T>.Of(x);
    }
}
