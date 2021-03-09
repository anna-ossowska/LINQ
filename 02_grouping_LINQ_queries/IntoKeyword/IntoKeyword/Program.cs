using System;
using System.Linq;
using System.Collections.Generic;

namespace IntoKeyword
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
                new Person("Tod", "Johnson", 21, 2, 170, Gender.Male),
                new Person("Jack", "Smith", 21, 3, 180, Gender.Male),
                new Person("Mary", "Doe", 27, 4, 160, Gender.Female),
                new Person("Alex", "Kowalski", 34, 5, 170, Gender.Male),
                new Person("Robert", "Ford", 21, 6, 165, Gender.Male)
            };

            // 'into' keyword allows us to continue the query after 'group by' clause
            var peopleByAge = from p in people
                              group p by p.Age into ageGroup
                              orderby ageGroup.Key
                              select ageGroup;

            foreach (var key in peopleByAge)
            {
                Console.WriteLine(key.Key);
                foreach (var item in key)
                {
                    Console.WriteLine(item.FirstName);
                }
            }

            EmptyLine();
            EmptyLine();

            // Group by age and gender
            var groupByAgeGender = from p in people
                                   group p by new { p.Age, p.Gender } into groupedByAgeGender
                                   orderby groupedByAgeGender.Count() descending
                                   select groupedByAgeGender;

            foreach (var key in groupByAgeGender)
            {
                Console.WriteLine(key.Key);

                foreach (var item in key)
                {
                    Console.WriteLine(item.FirstName);
                }
            }


            EmptyLine();
            EmptyLine();

            // check which numbers are even or odd
            // group them by this criteria
            int[] arrayOfNumbers = { 75, 6, 7, 3, 2, 11, 9, 54, 12, 1, 82, 221 };

            var evenOrOddNumbers = from n in arrayOfNumbers
                                   orderby n
                                   let evenOrOdd = (n % 2 == 0)
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
        }
    }
}
