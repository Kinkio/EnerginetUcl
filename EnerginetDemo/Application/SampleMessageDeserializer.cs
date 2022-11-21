using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace EnerginetDemo.Application
{
    public class SampleMessageDeserializer : ISampleMessageDeserializer
    {
        public async Task<SampleMessage> DeserializeMessageAsync(Stream body)
        {
            string requestBody = await new StreamReader(body).ReadToEndAsync();

            XmlSerializer serializer = new XmlSerializer(typeof(SampleMessage));

            var stringReader = new StringReader(requestBody);
            using (var reader = XmlReader.Create(stringReader))
            {
                return (SampleMessage)serializer.Deserialize(reader);
            }
        }
    }
}
