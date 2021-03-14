using System;
using System.Collections.Generic;
using System.Linq;

namespace Converting
{
    class Program
    {
        public class Person
        {
            public int Age { get; set; }
            public int ID { get; set; }
            public int Height { get; set; }
            public int Weight { get; set; }
        }

        public class Buyer : Person
        {
        }

        public class Supplier : Person
        {
        }

        static void Main()
        {
            List<Person> people = new List<Person>()
            {
                new Buyer() { Age = 20 , ID = 1, Height = 125, Weight = 77},
                new Buyer() { Age = 25 , ID = 2, Height = 150, Weight = 88},
                new Buyer() { Age = 20 , ID = 5, Height = 100, Weight = 58},
                new Supplier() { Age = 22 },
                new Supplier() { Age = 20 },
                new Supplier() { Age = 32 }
            };

            var toCollection = from p in people
                               where p.Age >= 20
                               select p;

            // Converting IEnumerable to Array
            Person[] personArray = toCollection.ToArray();

            // Converting IEnumerable to List
            List <Person> personList = toCollection.ToList();

            // Converting one object to another using method syntax
            var buyersToSuppliers = people.OfType<Buyer>().ToList().ConvertAll(b => new Supplier { Age = b.Age });

            // Converting one object to another using query syntax
            var buyersToSuppliers2 = (from p in people
                                     where p is Buyer
                                     let b = p as Buyer
                                     select new Supplier
                                     {
                                         Age = b.Age
                                     }).ToList();

            // Converting List of ints to List of strings using the method syntax
            List<int> numbers = new List<int>() { 1, 3, 5, 6, 6 };
            var stringNumbers = numbers.ConvertAll(n => n.ToString());

            // Converting List of ints to List of strings using the query syntax
            var stringNumbers2 = from n in numbers
                                 select n.ToString();
        }
    }
}