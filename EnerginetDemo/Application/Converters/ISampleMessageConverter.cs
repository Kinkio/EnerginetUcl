namespace EnerginetDemo.Application.Converters
{
    public interface ISampleMessageConverter
    {
        SampleMessageDb Convert(SampleMessage sampleMessage);
    }
}
