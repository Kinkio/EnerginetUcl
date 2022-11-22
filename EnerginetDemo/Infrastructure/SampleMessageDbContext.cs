using EnerginetDemo.Common;
using EnerginetDemo.Domain.Database;
using Microsoft.EntityFrameworkCore;

namespace EnerginetDemo.Infrastructure;

public class SampleMessageDbContext : DbContext
{
    public SampleMessageDbContext (DbContextOptions<SampleMessageDbContext> options): base(options)
    {

    }
    public DbSet<SampleMessageDb> SampleMessages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(EnvironmentSettingNames.SqlConnectionString);
        }
    }
}
