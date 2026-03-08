using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LoadingDemo
{
    // ---------------------------
    // ENTITY CLASSES
    // ---------------------------

    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; } = "";

        // Virtual for Lazy Loading
        public virtual List<Order> Orders { get; set; } = new();
    }

    public class Order
    {
        public int OrderId { get; set; }
        public string Product { get; set; } = "";
        public decimal Price { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
    }

    // ---------------------------
    // DB CONTEXT
    // ---------------------------
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Order> Orders => Set<Order>();

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }

    internal class Program
    {
        static void Main()
        {
            string connStr = "Data Source=loading_demo.db";

            // ---------------------------
            // NORMAL OPTIONS (NO LOGGING)
            // ---------------------------
            var normalOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite(connStr)
                .Options;

            // ---------------------------
            // LAZY LOADING OPTIONS
            // ---------------------------
            var lazyOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseLazyLoadingProxies()
                .UseSqlite(connStr)
                .Options;

            // ---------------------------
            // CREATE & SEED DATABASE
            // ---------------------------
            using (var ctx = new AppDbContext(normalOptions))
            {
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();

                var c1 = new Customer { Name = "Amit" };
                var c2 = new Customer { Name = "Neha" };

                c1.Orders.Add(new Order { Product = "Laptop", Price = 55000 });
                c1.Orders.Add(new Order { Product = "Mouse", Price = 800 });

                c2.Orders.Add(new Order { Product = "Phone", Price = 25000 });

                ctx.Customers.AddRange(c1, c2);
                ctx.SaveChanges();
            }

            // ---------------------------
            // EAGER LOADING
            // ---------------------------
            Console.WriteLine("\n=== EAGER LOADING ===");

            using (var ctx = new AppDbContext(normalOptions))
            {
                var customers = ctx.Customers
                    .Include(c => c.Orders)
                    .ToList();

                foreach (var c in customers)
                {
                    Console.WriteLine($"Customer: {c.Name}");
                    foreach (var o in c.Orders)
                        Console.WriteLine($"   Order: {o.Product} - {o.Price}");
                }
            }

            // ---------------------------
            // LAZY LOADING
            // ---------------------------
            Console.WriteLine("\n=== LAZY LOADING ===");

            using (var ctx = new AppDbContext(lazyOptions))
            {
                var customers = ctx.Customers.ToList();

                foreach (var c in customers)
                {
                    Console.WriteLine($"Customer: {c.Name}");

                    // Orders loaded only when accessed
                    foreach (var o in c.Orders)
                        Console.WriteLine($"   Order: {o.Product} - {o.Price}");
                }
            }

            // ---------------------------
            // EXPLICIT LOADING
            // ---------------------------
            Console.WriteLine("\n=== EXPLICIT LOADING ===");

            using (var ctx = new AppDbContext(normalOptions))
            {
                var customers = ctx.Customers.ToList();

                foreach (var c in customers)
                {
                    // Manually load Orders
                    ctx.Entry(c).Collection(x => x.Orders).Load();

                    Console.WriteLine($"Customer: {c.Name}");
                    foreach (var o in c.Orders)
                        Console.WriteLine($"   Order: {o.Product} - {o.Price}");
                }
            }

            Console.ReadLine();
        }
    }
}
