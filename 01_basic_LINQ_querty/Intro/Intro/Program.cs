using System;
using System.Linq;
using System.Collections.Generic;

namespace Intro
{
    class Program
    {
        static void Main()
        {
            int[] numbers = new int[] { 5, 4, 6, 7, 8, 1 };

            // Querying
            // BUT: The query is not executed until we make joining operation on getTheNumber in line 31
            var getTheNumber = from number in numbers
                               where number < 5
                               select number;

            // The same results with more code
            // Immediately executed
            List<int> newNumbers = new List<int>();

            foreach (var number in numbers)
            {
                if (number < 5)
                {
                    newNumbers.Add(number);
                }
            }

            Console.WriteLine(string.Join(", ", getTheNumber));
            Console.WriteLine(string.Join(", ", newNumbers));
        }
    }
}
