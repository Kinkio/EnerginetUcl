using EnerginetDemo.Domain.Database;
using EnerginetDemo.Domain.Input;

namespace EnerginetDemo.Application.Converters;

public interface ISampleMessageConverter
{
    SampleMessageDb Convert(SampleMessage sampleMessage);
}
