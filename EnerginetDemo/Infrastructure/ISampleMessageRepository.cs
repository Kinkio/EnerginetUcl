using System.Threading.Tasks;
using EnerginetDemo.Domain.Database;

namespace EnerginetDemo.Infrastructure
{
    public interface ISampleMessageRepository
    {
        Task<SampleMessageDb> AddAsync(SampleMessageDb entity);
    }
}
