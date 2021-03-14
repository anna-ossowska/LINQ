using System;
using System.Collections.Generic;
using System.Linq;

namespace SetOperations
{
    class Program
    {
        static void Main()
        {
            List<int> ints1 = new List<int>() { 2, 5, 9, 3, 7, 11, 67, 23, 3, 1, 22, 2, 1, 3 };
            List<int> ints2 = new List<int>() { 1, 11, 19, 23, 17, 77, 6, 20, 3, 2, 1 };

            // Finding the unique integers
            var distinctInts = ints1.Distinct();

            // Sets:
            var intersect = ints1.Intersect(ints2);

            var union = ints1.Union(ints2);

            var except = ints2.Except(ints1); // it matters which collection is applied as first
            foreach (var n in except)
                Console.WriteLine(n);
        }
    }
}
