using System.Xml.Serialization;

namespace EnerginetDemo;

[XmlRoot("SampleMessage")]
public class SampleMessage
{
    [XmlElement(typeof(int), ElementName = "Id")]
    public int Id { get; set; }

    [XmlElement(typeof(string), ElementName = "Text")]
    public string Text { get; set; }
}
