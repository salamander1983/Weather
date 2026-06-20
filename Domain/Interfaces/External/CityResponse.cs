namespace Domain.Interfaces.External;

[XmlRoot("document")]
public class CityResponse
{
    [XmlElement("item")]
    public Item[] Items { get; set; }
}

public class Item
{
    [XmlAttribute("id")]
    public int Id { get; set; }

    [XmlAttribute("n")]
    public string Name { get; set; }

    [XmlAttribute("lat")]
    public double Latitude { get; set; }

    [XmlAttribute("lng")]
    public double Longitude { get; set; }
}
