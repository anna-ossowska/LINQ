using System;
using System.Linq;
using System.Collections.Generic;

namespace IntroToGrouping
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
        public static void EmptyLine()
        {
            Console.WriteLine("\n");
        }

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

            // Group by gender
            var groupByGender = from p in people
                              group p by p.Gender;

            foreach (var person in groupByGender)
            {
                Console.WriteLine(person.Key);

                foreach (var p in person)
                {
                    Console.WriteLine($"\t{p.FirstName} {p.LastName}, {p.Gender}");
                }
            }

            EmptyLine();

            // Group by age condition
            var groupWithConditions = from p in people
                                      where p.Age > 25
                                      group p by p.Age;

            foreach (var key in groupWithConditions)
            {
                Console.WriteLine($"{key.Key}");
                foreach (var item in key)
                {
                    Console.WriteLine($"\t{item.FirstName}, {item.Age}");
                }
            }

            EmptyLine();

            // Group alphabetically by the first character of a person's name
            // Order people by their name
            var groupAlphabetically = from p in people
                                      orderby p.FirstName
                                      let firstChar = p.FirstName[0]
                                      group p by firstChar;

            foreach (var key in groupAlphabetically)
            {
                Console.WriteLine(key.Key);
                foreach (var item in key)
                {
                    Console.WriteLine($"\t{item.FirstName}");
                }
            }
        }
    }
}
