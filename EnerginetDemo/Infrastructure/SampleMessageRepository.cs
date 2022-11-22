using System;
using EnerginetDemo.Domain.Database;

namespace EnerginetDemo.Infrastructure;

public class SampleMessageRepository : ISampleMessageRepository
{
    public SampleMessageRepository (SampleMessageDbContext dbDbContext)
    {
        DbDbContext = dbDbContext ?? throw new ArgumentNullException(nameof(dbDbContext));
    }

    private SampleMessageDbContext DbDbContext { get; }

    public SampleMessageDb Add(SampleMessageDb entity)
    {
        DbDbContext.SampleMessages.Add(entity);
        DbDbContext.SaveChanges();
        return entity;
    }
}
