using System.IO;
using System.Threading.Tasks;
using EnerginetDemo.Domain.Input;

namespace EnerginetDemo.Application;

public interface ISampleMessageDeserializer
{
    Task<SampleMessage> DeserializeMessageAsync(Stream body);
}
