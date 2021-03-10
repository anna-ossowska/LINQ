using System;
using System.Collections.Generic;
using System.Linq;

namespace LeftOuterJoin
{
    public class Supplier
    {
        public string Name { get; set; }
        public string State { get; set; }
        public int Age { get; set; }
    }

    internal class Buyer
    {
        public string Name { get; set; }
        public string State { get; set; }
        public int Age { get; set; }
    }


    class Program
    {
        static void Main()
        {
            List<Buyer> buyers = new List<Buyer>()
            {
                new Buyer() { Name = "Johny", State= "NY", Age = 22},
                new Buyer() { Name = "Peter", State= "AL", Age = 40},
                new Buyer() { Name = "Paul", State = "OH", Age = 30 },
                new Buyer() { Name = "Maria", State= "UT", Age = 35 },
                new Buyer() { Name = "Joshua",State = "TX", Age = 40 },
                new Buyer() { Name = "Sylvia",State = "MI", Age = 22 },
                new Buyer() { Name = "Rebecca", State = "AL", Age = 30 },
                new Buyer() { Name = "Jaime", State= "OR", Age = 35 },
                new Buyer() { Name = "Pierce", State = "OH", Age = 40 }
            };

            List<Supplier> suppliers = new List<Supplier>()
            {
                new Supplier() { Name = "Harrison", State = "NY", Age = 22 },
                new Supplier() { Name = "Charles", State = "NY", Age = 40 },
                new Supplier() { Name = "Hailee", State = "AL", Age = 40 },
                new Supplier() { Name = "Taylor", State = "MD", Age = 30 }
            };

            // A left outer join is a join in which each element of the first collection is returned,
            // regardless of whether it has any correlated elements in the second collection.
            // We use LINQ to perform a left outer join by calling the DefaultIfEmpty method
            // on the results of a group join.
            var leftOuterJoin = from s in suppliers
                                join b in buyers on s.State equals b.State into buyersGroup
                                select new
                                {
                                    s.Name,
                                    s.State,
                                    Buyers = buyersGroup.DefaultIfEmpty(new Buyer() { Name = "No buyers" })
                                };


            foreach (var item in leftOuterJoin)
            {
                Console.WriteLine($"{item.Name} | {item.State}");
                foreach (var buyer in item.Buyers)
                {
                    Console.WriteLine($"\t{buyer.Name}");
                }
            }

        }
    }
}

