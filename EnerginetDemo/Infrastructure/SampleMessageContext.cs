using System.Data.Entity;

namespace EnerginetDemo.Infrastructure
{
    public class SampleMessageContext : DbContext
    {
        public DbSet<SampleMessageDb> SampleMessages { get; set; }
    }
}
