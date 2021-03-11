using System;
using System.Linq;
using System.Collections.Generic;

namespace GroupingByCustomKeys
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

    class Program
    {
        static void Main()
        {
            List<Person> people = new List<Person>()
            {
                new Person("Jane", "Doe", 12, 1, 150, Gender.Female),
                new Person("Tod", "Johnson", 56, 2, 170, Gender.Male),
                new Person("Jack", "Smith", 21, 3, 180, Gender.Male),
                new Person("Mary", "Doe", 18, 4, 160, Gender.Female),
                new Person("Alex", "Kowalski", 16, 5, 170, Gender.Male),
                new Person("Robert", "Ford", 21, 6, 165, Gender.Male)
            };

            int[] arrayOfNumbers = { 4, 5, 9, 2, 11, 78, 12, 34, 55, 67, 32, 90, 231 };

            // grouping into two categories
            var evenOrOdd = arrayOfNumbers.OrderBy(n => n)
                                          .GroupBy(n => (n % 2 == 0) ? "even" : "odd");

            foreach (var item in evenOrOdd)
            {
                Console.WriteLine(item.Key);

                foreach (var n in item)
                {
                    Console.WriteLine($"\t{n}");
                }
            }

            // Grouping people into three categories: young, adult and senior.
            var ageGroups = people.GroupBy(p => (p.Age < 18) ? "young" :
                                                (p.Age >= 18 && p.Age <= 55) ? "adult" : "senior");

            foreach (var item in ageGroups)
            {
                Console.WriteLine(item.Key);
                foreach (var p in item)
                {
                    Console.WriteLine($"\t{p.FirstName}");
                }
            }

            // Same result using variables inside the body of lambda
            var ageGroups2 = people.GroupBy(p =>
            {
                var young = p.Age < 18;
                var adult = p.Age >= 18 && p.Age <= 55;

                var age = young ? "young" :
                          adult ? "adult" : "senior";

                return age;
            });

            foreach (var item in ageGroups2)
            {
                Console.WriteLine(item.Key);
                foreach (var p in item)
                {
                    Console.WriteLine($"\t{p.FirstName}");
                }
            }
        }
    }
}