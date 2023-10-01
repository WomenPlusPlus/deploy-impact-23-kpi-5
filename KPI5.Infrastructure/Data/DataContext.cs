using KPI5.Domain.Entities.KPI5;
using KPI5.Infrastructure.Data.Mappings.KPI5;
using Microsoft.EntityFrameworkCore;
namespace KPI5.Infrastructure.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> opts) : base(opts) {}
    public DbSet<Kpi5Entity> Kpi5s { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new Kpi5Map());
    }
}