using System;
using System.Collections.Generic;
using System.Linq;

namespace SelectvsWhere
{
    public class Person
    {
        public int Height { get; set; }
    }

    class Program
    {
        public static int[] StringToIntArray(string numbers)
        {
            var arrayFromString = numbers.Split(' ')
                                         .Select(n => int.Parse(numbers))
                                         .ToArray();
            return arrayFromString;
        }

        static void Main()
        {
            List<Person> people = new List<Person>()
            {
                new Person() { Height = 152 },
                new Person() { Height = 180 },
                new Person() { Height = 190 },
                new Person() { Height = 175 },
                new Person() { Height = 153 },
            };

            // Select returns a new collection from another collection
            var shortPeople = people.Where(p => p.Height < 155)
                                    .Select(p => p.Height);

            foreach (var p in shortPeople)
                Console.WriteLine(p);
        }
    }
}