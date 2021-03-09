using System;
using System.Linq;
using System.Collections.Generic;

namespace GroupingWithCustomKeys
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
                new Person("Jane", "Doe", 12, 1, 150, Gender.Female),
                new Person("Tod", "Johnson", 70, 2, 170, Gender.Male),
                new Person("Jack", "Smith", 18, 3, 180, Gender.Male),
                new Person("Mary", "Doe", 16, 4, 160, Gender.Female),
                new Person("Alex", "Kowalski", 34, 5, 170, Gender.Male),
                new Person("Robert", "Ford", 21, 6, 165, Gender.Male)
            };

            // check which numbers are even and which are odd
            // group them by this criteria
            int[] arrayOfNumbers = { 75, 6, 7, 3, 2, 11, 9, 54, 12, 1, 82, 221 };

            var evenOrOddNumbers = from n in arrayOfNumbers
                                   orderby n
                                   let evenOrOdd = (n % 2 == 0) ? "even" : "odd"
                                   group n by evenOrOdd into nums
                                   orderby nums.Count()
                                   select nums;

            foreach (var key in evenOrOddNumbers)
            {
                Console.WriteLine(key.Key);
                foreach (var n in key)
                {
                    Console.WriteLine($"\t {n}");
                }
            }

            EmptyLine();
            EmptyLine();

            // Group people into three categories: young, adult and senior
            // Order by number of people in each group
            // 0-18 -> Young
            // 18-50 -> Adult
            // 50+ -> Senior
            var ageGroup = from p in people
                           let YoungAdultOrSenior = (p.Age < 18) ? "Young" :
                                                        (p.Age >= 18 && p.Age <= 50) ? "Adult" : "Senior"
                           group p by YoungAdultOrSenior into YoungAdultOrSeniorGroups
                           orderby YoungAdultOrSeniorGroups.Count()
                           select YoungAdultOrSeniorGroups;

            foreach (var key in ageGroup)
            {
                Console.WriteLine(key.Key);
                foreach (var item in key)
                {
                    Console.WriteLine($"\t{item.FirstName} : {item.Age}");
                }
            }
        }
    }
}