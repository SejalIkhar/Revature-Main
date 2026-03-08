using Microsoft.EntityFrameworkCore;
using CRMProject.Models;

namespace CRMProject.Data
{
    public class CrmContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(
                "Server=localhost\\SQLEXPRESS;Database=CRMDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
