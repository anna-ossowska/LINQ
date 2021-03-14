using System;
using System.Collections.Generic;
using System.Linq;

namespace AggregationOperations
{
    class Program
    {
        public class Person
        {
            public string FirstName { get; set; }
            public int Age { get; set; }
        }

        static void Main()
        {
            List<Person> people = new List<Person>()
            {
                new Person {FirstName = "Jane", Age = 19 },
                new Person {FirstName = "Tod", Age = 23},
                new Person{FirstName = "Jack", Age = 40 }
            };

            int[] ints = new int[] { 1, 2, 3, 4 };

            // Aggregate
            // applying an an accumulator function over a sequence
            // p is an accumulator, i is a current integer
            int aggregate = ints.Aggregate((p, i) => p + i);
            Console.WriteLine(aggregate);

            // The same results using the standard for loop
            int p = 0;

            for (int i = 0; i < ints.Length; i++)
            {
                p = p + ints[i];
            }

            Console.WriteLine(p);

            // Aggregate with the seed value
            int aggregateWithSeed = ints.Aggregate(2, (p, i) => p * i);
            Console.WriteLine(aggregateWithSeed);

            // Sum
            int sum = ints.Sum();
            Console.WriteLine(sum);

            // Average
            double average = ints.Average();
            Console.WriteLine(average);

            // Summing ages of people
            int sumOfAges = people.Sum(p => p.Age);
            Console.WriteLine(sumOfAges);

            // Getting the average age
            double averageAge = people.Average(p => p.Age);
            Console.WriteLine(averageAge);

            // Min age
            Console.WriteLine(people.Min(p => p.Age));

            // Max age
            Console.WriteLine(people.Max(p => p.Age));
        }
    }
}
