using System.Xml.Serialization;

namespace EnerginetDemo
{
    [XmlRoot("SampleMessage")]
    public class SampleMessage
    {
        [XmlElement(typeof(int), ElementName = "ID")]
        public int ID { get; set; }

        [XmlElement(typeof(string), ElementName = "Text")]
        public string? Text { get; set; }
    }
}
