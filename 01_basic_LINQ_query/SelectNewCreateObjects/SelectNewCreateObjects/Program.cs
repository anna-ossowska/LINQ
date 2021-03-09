using System;
using System.Linq;
using System.Collections.Generic;

namespace SelectNewCreateObjects
{
    public enum Gender
    {
        Female,
        Male
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int Id { get; set; }
        public int Height { get; set; }
        public Gender Gender { get; set; }

        public Person(string firstName, string lastName, int age, int id, int height, Gender gender)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Id = id;
            this.Height = height;
            this.Gender = gender;
        }
    }

    public class YoungPerson
    {
        public string FullName { get; set; }
        public int Age { get; set; }
    }

    class Program
    {
        static void Main()
        {
            List<Person> people = new List<Person>()
            {
                new Person("Jane", "Doe", 27, 1, 150, Gender.Female),
                new Person("Tod", "Johnson", 31, 2, 170, Gender.Male),
                new Person("Jack", "Smith", 21, 3, 180, Gender.Male),
                new Person("Mary", "Doe", 23, 4, 160, Gender.Female),
                new Person("Alex", "Kowalski", 45, 5, 170, Gender.Male),
                new Person("Robert", "Ford", 65, 6, 165, Gender.Male)
            };

            // anonymous type does not have any name and contains public readonly properties only
            // it cannot contain other members, such as fields and methods
            // we create anonymous types using a new operator with an object initializer syntax
            // in LINQ anonymous types are created using a select clause
            // and return a subset of properties from each object in the collection
            var youngPeople = from p in people
                              where p.Age < 25
                              select new { Name = p.FirstName, p.Age }; // anonymous type

            foreach (var p in youngPeople)
            {
                Console.WriteLine($"{p.Name}'s age is {p.Age}.");
            }


            var youngPeopleObj = from p in people
                                 where p.Age < 25
                                 // assigning to the property of YoungPerson class
                                 select new YoungPerson { FullName = string.Format($"{p.FirstName} {p.LastName}"), Age = p.Age };

            foreach (var p in youngPeopleObj)
            {
                Console.WriteLine($"{p.FullName}'s age is {p.Age}.");
            }
        }
    }
}