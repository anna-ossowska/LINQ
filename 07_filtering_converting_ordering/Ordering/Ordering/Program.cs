using System;
using System.Linq;
using System.Collections.Generic;

namespace Ordering
{
    public class Person
    {
        public int Age { get; set; }
        public int ID { get; set; }
        public int Height { get; set; }
    }

    class Program
    {
        static void Main()
        {
            List<Person> people = new List<Person>()
            {
                new Person() {Age = 20, ID = 1, Height = 155},
                new Person() {Age = 18, ID = 2, Height = 168 },
                new Person() {Age = 45, ID = 3, Height = 166 },
                new Person() {Age = 35, ID = 6, Height = 155 },
                new Person() {Age = 67, ID = 7, Height = 145 },
                new Person() {Age = 34, ID = 8, Height = 174 },
                new Person() {Age = 18, ID = 2, Height = 167 }
            };

            // ThenBy is extending IOrderedEnumerable
            // Use it if you need to order your collection by more than one condition
            var orderedPeople2 = people.OrderBy(p => p.ID).ThenBy(p => p.Age).ThenByDescending(p => p.Height);

            foreach (var p in orderedPeople2)
            {
                Console.WriteLine($"{p.ID}, {p.Age}, {p.Height}");
            }

        }
    }
}