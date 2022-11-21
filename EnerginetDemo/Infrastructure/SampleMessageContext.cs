
using EnerginetDemo.Common;
using Microsoft.EntityFrameworkCore;

namespace EnerginetDemo.Infrastructure;

public class SampleMessageContext : DbContext
{
    public DbSet<SampleMessageDb> SampleMessages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(EnvironmentSettingNames.SqlConnectionString);
        }
    }
}
