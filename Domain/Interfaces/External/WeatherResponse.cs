namespace Domain.Interfaces.External;

[XmlRoot("weather")]
public class WeatherResponse
{
    [XmlElement("location")]
    public Location Location { get; set; }
}

public class Location
{
    [XmlAttribute("id")]
    public int Id { get; set; }

    [XmlAttribute("name")]
    public string Name { get; set; }

    [XmlElement("fact")]
    public Fact Fact { get; set; }
}

public class Fact
{
    [XmlAttribute("valid")]
    public DateTime Timestamp { get; set; }

    [XmlElement("values")]
    public Values Values { get; set; }
}

public class Values
{
    [XmlAttribute("t")]
    public double Temperature { get; set; }

    [XmlAttribute("icon")]
    public string Icon { get; set; }

    [XmlAttribute("descr")]
    public string Description { get; set; }

    [XmlAttribute("ws")]
    public double Wind { get; set; }

    [XmlAttribute("water_t")]
    public double Water { get; set; }

    [XmlAttribute("hum")]
    public double Humidity { get; set; }

    [XmlAttribute("p")]
    public double Pressure { get; set; }
}