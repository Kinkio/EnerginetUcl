using System.Collections.Generic;
using EnerginetDemo.Domain.Database;
using EnerginetDemo.Infrastructure;

namespace EnerginetDemo.Tests.Doubles;

public class FakeSampleMessageRepository : ISampleMessageRepository
{
    private Dictionary<long, SampleMessageDb> Data { get; } = new();

    public SampleMessageDb Add(SampleMessageDb entity)
    {
        Data.Add(NextIdentity(), entity);

        return entity;
    }

    public int Count()
    {
        return Data.Count;
    }

    private int NextIdentity()
    {
        return Data.Count + 1;
    }
}
