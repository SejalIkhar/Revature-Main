// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;

namespace GroupingAggregationDemo
{
    // MODEL CLASS
    // Represents one Order record
    class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // -------------------------------
            // STEP 1: Create sample data
            // -------------------------------
            List<Order> orders = new List<Order>()
            {
                new Order { OrderId = 1, CustomerId = 101, Amount = 500 },
                new Order { OrderId = 2, CustomerId = 101, Amount = 300 },
                new Order { OrderId = 3, CustomerId = 102, Amount = 700 },
                new Order { OrderId = 4, CustomerId = 102, Amount = 200 },
                new Order { OrderId = 5, CustomerId = 103, Amount = 1000 }
            };

            // -------------------------------
            // STEP 2: GROUPING + AGGREGATION
            // -------------------------------

            var result = orders
                .GroupBy(o => o.CustomerId)     // GROUP BY CustomerId
                .Select(g => new               // Create anonymous object
                {
                    CustomerId = g.Key,        // Group key
                    TotalAmount = g.Sum(o => o.Amount),   // SUM
                    OrderCount = g.Count()     // COUNT
                })
                .ToList();

            // -------------------------------
            // STEP 3: Display result
            // -------------------------------

            Console.WriteLine("Customer-wise Order Summary\n");

            foreach (var item in result)
            {
                Console.WriteLine(
                    $"Customer ID: {item.CustomerId}, " +
                    $"Total Amount: {item.TotalAmount}, " +
                    $"Orders: {item.OrderCount}"
                );
            }

            Console.ReadLine(); // Pause screen
        }
    }
}

