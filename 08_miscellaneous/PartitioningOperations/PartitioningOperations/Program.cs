using System;
using System.Collections.Generic;
using System.Linq;

namespace PartitioningOperations
{
    class Program
    {
        static void Main()
        {
            int[] ints1 = new int[] { 67, 20, 2, 5, 9, 3, 7, 11, 67, 23, 3, 1, 20, 2, 1, 68, 3 };

            int[] ints2 = ints1.Skip(10).ToArray();

            int[] ints3 = ints1.Take(5).ToArray();

            int[] ints4 = ints1.Take(5).Skip(2).ToArray();

            int[] topThreeInts = ints1.Distinct().OrderByDescending(n => n).Take(3).ToArray();

            int[] skipWhile = ints1.SkipWhile(n => n >= 20).ToArray();

            int[] takeWhile = ints1.TakeWhile(n => n >= 20).ToArray();

            foreach (var i in takeWhile)
                Console.WriteLine(i);
        }
    }
}
