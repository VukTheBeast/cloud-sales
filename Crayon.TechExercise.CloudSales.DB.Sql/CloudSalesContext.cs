using Crayon.TechExercise.CloudSales.DB.Sql.Entities;
using Microsoft.EntityFrameworkCore;

namespace Crayon.TechExercise.CloudSales.DB.Sql;

public sealed class CloudSalesContext : DbContext
{
    public CloudSalesContext(DbContextOptions<CloudSalesContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<PurchasedSoftware> PurchasedSoftwares { get; set; }

}
