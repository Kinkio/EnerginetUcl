using System;
using System.Threading.Tasks;
using EnerginetDemo.Domain.Database;

namespace EnerginetDemo.Infrastructure;

public class SampleMessageRepository : ISampleMessageRepository
{
    public SampleMessageRepository (SampleMessageDbContext dbContext)
    {
        DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    private SampleMessageDbContext DbContext { get; }

    public async Task<SampleMessageDb> AddAsync(SampleMessageDb entity)
    {
        DbContext.SampleMessages.Add(entity);
        await DbContext.SaveChangesAsync();
        return entity;
    }
}
