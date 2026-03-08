using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

using var context = new UniqueCrmDbContext();

// Read all clients
var clients = context.Clients.ToList();

foreach (var c in clients)
    Console.WriteLine($"ClientId: {c.ClientId}, Name: {c.Name}, Email: {c.Email}");
    

class UniqueCrmDbContext : DbContext
{
    public DbSet<Client> Clients => Set<Client>();
    public DbSet<SalesOrder> SalesOrders => Set<SalesOrder>();
    public DbSet<ClientCategory> ClientCategories => Set<ClientCategory>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // ✅ New unique database name (no clash with old CrmDb)
        optionsBuilder.UseSqlServer(
            "Server=localhost\\SQLEXPRESS;Database=CrmDb_UniqueV1;Trusted_Connection=True;TrustServerCertificate=True"
        );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // ✅ Explicit table names (optional but helps avoid confusion)
        modelBuilder.Entity<Client>().ToTable("Clients");
        modelBuilder.Entity<SalesOrder>().ToTable("SalesOrders");
        modelBuilder.Entity<ClientCategory>().ToTable("ClientCategories");

        // Seed data
        modelBuilder.Entity<ClientCategory>().HasData(
            new ClientCategory { Id = 1, CategoryName = "Regular" },
            new ClientCategory { Id = 2, CategoryName = "Premium" }
        );

        modelBuilder.Entity<SalesOrder>()
            .HasKey(o => o.SalesOrderId);

        modelBuilder.Entity<SalesOrder>()
            .HasOne(o => o.Client)
            .WithMany(c => c.SalesOrders)
            .HasForeignKey(o => o.ClientId);
    }
}

public class Client
{
    public int ClientId { get; set; }
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";

    public List<SalesOrder> SalesOrders { get; set; } = new();
}

public class ClientCategory
{
    public int Id { get; set; }
    public string CategoryName { get; set; } = "";
}

public class SalesOrder
{
    public int SalesOrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }

    [ForeignKey(nameof(Client))]
    public int ClientId { get; set; }
    public Client Client { get; set; } = null!;
}
