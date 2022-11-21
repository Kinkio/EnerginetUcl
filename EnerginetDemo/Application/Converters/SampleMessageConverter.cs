namespace EnerginetDemo.Application.Converters
{
    public class SampleMessageConverter : ISampleMessageConverter
    {
        public SampleMessageDb Convert(SampleMessage sampleMessage)
        {
            return new SampleMessageDb()
            {
                Id = sampleMessage.Id,
                Text = sampleMessage.Text
            };
        }
    }
}
