using System;
using System.Threading.Tasks;
using EnerginetDemo.Domain.Database;

namespace EnerginetDemo.Infrastructure;

public class SampleMessageRepository : ISampleMessageRepository
{
    public SampleMessageRepository (SampleMessageDbContext dbDbContext)
    {
        DbDbContext = dbDbContext ?? throw new ArgumentNullException(nameof(dbDbContext));
    }

    private SampleMessageDbContext DbDbContext { get; }

    public async Task<SampleMessageDb> AddAsync(SampleMessageDb entity)
    {
        DbDbContext.SampleMessages.Add(entity);
        await DbDbContext.SaveChangesAsync();
        return entity;
    }
}
