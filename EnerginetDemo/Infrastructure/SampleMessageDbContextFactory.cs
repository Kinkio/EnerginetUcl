using EnerginetDemo.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EnerginetDemo.Infrastructure
{
    public class SampleMessageDbContextFactory : IDesignTimeDbContextFactory<SampleMessageDbContext>
    {
        public static void ConfigureDbContext(DbContextOptionsBuilder optionsBuilder, string sqlConnectionString = null)
        {
            sqlConnectionString = EnvironmentSettingNames.SqlConnectionString;
            optionsBuilder.UseSqlServer(
                sqlConnectionString,
                sqlOptions => sqlOptions.EnableRetryOnFailure());
        }

        public SampleMessageDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SampleMessageDbContext>();
            ConfigureDbContext(optionsBuilder);
            return new SampleMessageDbContext(optionsBuilder.Options);
        }
    }
}
