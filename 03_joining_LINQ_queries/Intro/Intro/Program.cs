using System;
using System.Collections.Generic;
using System.Linq;

namespace Intro
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
                new Supplier() { Name = "Hailee", State = "AL", Age = 35 },
                new Supplier() { Name = "Taylor", State = "TX", Age = 30 }
            };

            var innerJoin = from s in suppliers
                            orderby s.State
                            join b in buyers on s.State equals b.State
                            select new
                            {
                                SupplierName = s.Name,
                                BuyerName = b.Name,
                                b.State
                            };

            foreach (var item in innerJoin)
            {
                Console.WriteLine($"State: {item.State}, Supplier: {item.SupplierName}, Buyer: {item.BuyerName}");
            }
        }
    }
}
