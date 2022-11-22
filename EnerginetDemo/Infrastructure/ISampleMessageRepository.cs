using EnerginetDemo.Domain.Database;

namespace EnerginetDemo.Infrastructure
{
    public interface ISampleMessageRepository
    {
        SampleMessageDb Add(SampleMessageDb entity);
    }
}
