using Microsoft.EntityFrameworkCore;
using Tenant.Domain.Entities;

namespace Tenant.Infrastructure.Context;

public partial class TenantDbContext : DbContext
{
    public TenantDbContext(DbContextOptions<TenantDbContext> options) : base(options)
    {

    }

    public DbSet<Domain.Entities.Tenant> Tenants { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
}