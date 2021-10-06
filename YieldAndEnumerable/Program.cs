using System;
using System.Collections.Generic;
using System.Linq;

namespace YieldAndEnumerable
{
    class T
    {
        //returns a list of type IEnumerable<>

        //iterator
        public IEnumerable<int> GetT(List<int> list)
        {
            foreach (var item in list)
            {
                if (item > 5)
                    yield return item;
            }
        }

        //a standard method
        public IEnumerable<int> GetT1(List<int> list)
        {
            List<int> ttt = new List<int>();
            foreach (var item in list)
            {
                if (item > 5)
                    ttt.Add(item);
            }
            return ttt;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var t = new T();
            var list = new List<int> { 2, 5, 6, 1, 11 };

            //evaluates just the first element, just iterates once
            var result = t.GetT(list).FirstOrDefault();
            var result0 = t.GetT(list);
            Console.WriteLine(string.Join(" ",result));

            //evaluates the whole list, then returns (iterates over the full list)
            var result1 = t.GetT1(list).FirstOrDefault();
        }
    }
}
