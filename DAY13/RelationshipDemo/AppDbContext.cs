using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Account> Accounts => Set<Account>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<Product> Products => Set<Product>();

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(
            "Server=localhost\\SQLEXPRESS;Database=AccountCustomerOrderProductDB;Trusted_Connection=True;TrustServerCertificate=True"
        );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // 1️⃣ Account <-> Customer (ONE TO ONE)
        modelBuilder.Entity<Account>()
            .HasOne(a => a.Customer)
            .WithOne(c => c.Account)
            .HasForeignKey<Customer>(c => c.AccountId);

        // 2️⃣ Customer -> Orders (ONE TO MANY)
        modelBuilder.Entity<Order>()
            .HasOne(o => o.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CustomerId);

        // 3️⃣ Orders <-> Products (MANY TO MANY) with custom join table name
        modelBuilder.Entity<Order>()
            .HasMany(o => o.Products)
            .WithMany(p => p.Orders)
            .UsingEntity(j => j.ToTable("OrderProducts")); // join table

        // Decimal precision
        modelBuilder.Entity<Order>().Property(o => o.TotalAmount).HasPrecision(18, 2);
        modelBuilder.Entity<Product>().Property(p => p.Price).HasPrecision(18, 2);
    }
}
