namespace EnerginetDemo.Application.Converters
{
    public class SampleMessageConverter : ISampleMessageConverter
    {
        public SampleMessageDb Convert(SampleMessage sampleMessage)
        {
            return new SampleMessageDb()
            {
                Id = sampleMessage.ID,
                Text = sampleMessage.Text
            };
        }
    }
}
