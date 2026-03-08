using System.Collections.Generic;

// -------- ACCOUNT (1-1 with Customer) --------
public class Account
{
    public int AccountId { get; set; }
    public string Name { get; set; } = "";
    public Customer? Customer { get; set; }
}

// -------- CUSTOMER (1-1 with Account, 1-M with Orders) --------
public class Customer
{
    public int CustomerId { get; set; }
    public string Name { get; set; } = "";

    public int AccountId { get; set; }   // FK (1-1)
    public Account Account { get; set; } = null!;

    public List<Order> Orders { get; set; } = new();
}

// -------- ORDER (1-M with Customer, M-M with Product) --------
public class Order
{
    public int OrderId { get; set; }
    public decimal TotalAmount { get; set; }

    public int CustomerId { get; set; }   // FK (1-M)
    public Customer Customer { get; set; } = null!;

    public List<Product> Products { get; set; } = new(); // ✅ M-M
}

// -------- PRODUCT (M-M with Order) --------
public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; } = "";
    public decimal Price { get; set; }

    public List<Order> Orders { get; set; } = new(); // ✅ M-M
}
