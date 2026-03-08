// See https://aka.ms/new-console-template for more information

using CRMProject.Data;
using CRMProject.Models;

using var context = new CrmContext();

context.Customers.Add(new Customer
{
    Name = "Sejal",
    Age = 22
});

context.SaveChanges();

Console.WriteLine("Customer Inserted Successfully!");
