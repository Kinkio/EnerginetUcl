using System.IO;
using System.Threading.Tasks;

namespace EnerginetDemo.Application
{
    public interface ISampleMessageDeserializer
    {
        Task<SampleMessage> DeserializeMessageAsync(Stream body);
    }
}
