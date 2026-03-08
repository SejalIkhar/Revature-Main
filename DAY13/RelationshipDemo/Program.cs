using System;
using Microsoft.EntityFrameworkCore;

using var db = new AppDbContext();

Console.WriteLine("\nChoose Option:");
Console.WriteLine("1. Add Account & Customer (1-1)");
Console.WriteLine("2. Add Order for Customer (1-M)");
Console.WriteLine("3. Add Product and attach to an Order (M-M)");

int choice = int.Parse(Console.ReadLine()!);

if (choice == 1)
{
    Console.Write("Enter Account Name: ");
    string aname = Console.ReadLine()!;

    Console.Write("Enter Customer Name: ");
    string cname = Console.ReadLine()!;

    var account = new Account { Name = aname };
    var customer = new Customer { Name = cname, Account = account };

    db.Accounts.Add(account);
    db.Customers.Add(customer);
    db.SaveChanges();

    Console.WriteLine($"Saved! AccountId={account.AccountId}, CustomerId={customer.CustomerId}");
}
else if (choice == 2)
{
    Console.Write("Enter Customer Id: ");
    int cid = int.Parse(Console.ReadLine()!);

    Console.Write("Enter Order Amount: ");
    decimal amt = decimal.Parse(Console.ReadLine()!);

    var order = new Order { TotalAmount = amt, CustomerId = cid };

    db.Orders.Add(order);
    db.SaveChanges();

    Console.WriteLine($"Order Saved! OrderId={order.OrderId}");
}
else if (choice == 3)
{
    Console.Write("Enter Order Id (existing): ");
    int oid = int.Parse(Console.ReadLine()!);

    Console.Write("Enter Product Name: ");
    string pname = Console.ReadLine()!;

    Console.Write("Enter Product Price: ");
    decimal price = decimal.Parse(Console.ReadLine()!);

    var order = db.Orders.Include(o => o.Products).FirstOrDefault(o => o.OrderId == oid);
    if (order == null)
    {
        Console.WriteLine("Order not found.");
        return;
    }

    var product = new Product { Name = pname, Price = price };

    order.Products.Add(product); // ✅ M-M link created here
    db.SaveChanges();

    Console.WriteLine("Product added to Order (Many-to-Many)!");
}
else
{
    Console.WriteLine("Invalid choice");
}
