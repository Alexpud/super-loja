using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace SuperLoja.Api.Infrastructure;

public class SuperLojaDbContext : DbContext
{
    public SuperLojaDbContext(DbContextOptions<SuperLojaDbContext> dbContextOptions) : base(dbContextOptions)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
