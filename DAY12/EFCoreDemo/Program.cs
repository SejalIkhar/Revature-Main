using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.SqlServer;


using var _context = new CrmContext();//crmcontext is dbcontext class&var is implicit which identifies the datatype by its own
//_context is a variable name which stores the object of crmcontext

//Inserting new memeber
_context.Customers.Add(new Customer
{
    Name = "Antara",
    Age = 28
});
// -------- UPDATE ----------
var cust = _context.Customers.FirstOrDefault(c => c.Id == 1);
if (cust != null)
{
    cust.Name = "Sejal Updated";
    cust.Age = 23;
    _context.SaveChanges();
}
 
//Converting linq into sql syntax
var customers = _context.Customers //this line means asking for acces to the customer table
    .Where(c => c.Age > 20)
    .ToList();



_context.SaveChanges();

foreach (var customer in customers)//foeach is used to iterate the collection,customer is a collection(list<Customer>)
{
    Console.WriteLine($"Id: {customer.Id} Customer: {customer.Name}, Age: {customer.Age}");
}

class CrmContext : DbContext//crmcontext is dbcontext class which inheriting from the dbcontext

{
    public DbSet<Customer> Customers { get; set; } = null!;//Dbset is query provider

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost\\SQLEXPRESS;Database=Customer;Trusted_Connection=True;TrustServerCertificate=True;"
        );
    }
}

[Table("Customer")] // remove this line if your table name is Customers
class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int Age { get; set; }
}