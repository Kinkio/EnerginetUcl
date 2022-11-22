using System.Xml.Serialization;

namespace EnerginetDemo.Domain.Input;

[XmlRoot("SampleMessage")]
public class SampleMessage
{
    [XmlElement(typeof(string), ElementName = "Text")]
    public string Text { get; set; }
}
