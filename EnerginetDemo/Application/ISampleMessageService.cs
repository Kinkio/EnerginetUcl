using System.IO;
using System.Threading.Tasks;
using EnerginetDemo.Domain.Database;

namespace EnerginetDemo.Application
{
    public interface ISampleMessageService
    {
        Task<SampleMessageDb> HandleIncomingSampleMessage(Stream body);
    }
}
