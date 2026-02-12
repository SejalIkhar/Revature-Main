// See https://aka.ms/new-console-template for more information
//using System;
using System.Collections.Generic;
using System.Linq;

public class Customer
{
    public int CustomerId { get; set; }
    public string CustomerName { get; set; } = "";
}

public class Order
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public decimal OrderAmount { get; set; }
}

public class Program
{
    public static void Main()
    {
        // ----------------------------
        // 1) Create list of Customers
        // ----------------------------
        var customers = new List<Customer>
        {
            new Customer { CustomerId = 1, CustomerName = "Asha" },
            new Customer { CustomerId = 2, CustomerName = "Ravi" },
            new Customer { CustomerId = 3, CustomerName = "Neha" }
        };

        // ----------------------------
        // 2) Create list of Orders
        // ----------------------------
        var orders = new List<Order>
        {
            new Order { OrderId = 101, CustomerId = 1, OrderAmount = 2500m },
            new Order { OrderId = 102, CustomerId = 1, OrderAmount = 1200m },
            new Order { OrderId = 103, CustomerId = 2, OrderAmount = 999m },
            new Order { OrderId = 104, CustomerId = 2, OrderAmount = 5000m },
            new Order { OrderId = 105, CustomerId = 2, OrderAmount = 150m }
            // CustomerId = 3 has no orders (testing)
        };

        // ---------------------------------------------------------
        // JOIN: Which customer placed which orders (order list)
        // ---------------------------------------------------------
        var customerOrders = customers.Join(
            orders,
            c => c.CustomerId,
            o => o.CustomerId,
            (c, o) => new
            {
                c.CustomerId,
                c.CustomerName,
                o.OrderId,
                o.OrderAmount
            }
        );

        Console.WriteLine("=== Which customer placed which orders ===");
        foreach (var item in customerOrders)
        {
            Console.WriteLine($"{item.CustomerName} (ID {item.CustomerId}) -> Order {item.OrderId}, Amount {item.OrderAmount}");
        }

        // -------------------------------------------------------------------
        //   GROUP RESULT: How many orders + total order value per customer
        //    (includes customers with 0 orders using GroupJoin)
        // -------------------------------------------------------------------
        var summary = customers
            .GroupJoin(
                orders,
                c => c.CustomerId,
                o => o.CustomerId,
                (c, custOrders) => new
                {
                    c.CustomerId,
                    c.CustomerName,
                    Orders = custOrders.ToList(),
                    OrderCount = custOrders.Count(),
                    TotalValue = custOrders.Sum(x => x.OrderAmount) // 0 if none
                }
            );

        Console.WriteLine("\n=== Summary per customer (count + total) ===");
        foreach (var s in summary)
        {
            Console.WriteLine($"{s.CustomerName} (ID {s.CustomerId}) -> Orders: {s.OrderCount}, Total Value: {s.TotalValue}");

            // Optional: show orders under each customer
            foreach (var o in s.Orders)
                Console.WriteLine($"   - Order {o.OrderId}, Amount {o.OrderAmount}");

            if (s.OrderCount == 0)
                Console.WriteLine("   - No orders");
        }
    }
}

