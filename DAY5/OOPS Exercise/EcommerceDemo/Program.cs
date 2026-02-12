// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;

class Program
{
    static void Main()
    {
        Customer customer = new Customer();
        customer.PlaceOrder();

        SystemProcessor processor = new SystemProcessor();
        processor.ProcessPayment();

        Admin admin = new Admin();
        admin.UpdateProductDetails();
    }
}

// -------- Sentence 1 --------
class Customer
{
    public Order Order { get; set; } = new Order();

    public void PlaceOrder()
    {
        Console.WriteLine("Customer places an order");
    }
}

class Order
{
    public int OrderId { get; set; }
}

// -------- Sentence 2 --------
class SystemProcessor
{
    public Payment Payment { get; set; } = new Payment();

    public void ProcessPayment()
    {
        Console.WriteLine("Payment is being processed");
    }
}

class Payment
{
    public double Amount { get; set; }
}

// -------- Sentence 3 --------
class Admin
{
    public Product Product { get; set; } = new Product();

    public void UpdateProductDetails()
    {
        Console.WriteLine("Admin updates product details");
    }
}

class Product
{
    public string Name { get; set; }
    public double Price { get; set; }
}
