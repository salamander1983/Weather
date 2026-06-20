using Domain.Entities;
using Domain.Interfaces.External;

namespace Infrastructure.Implementations.External;

internal class WeatherRepository(IHttpClientFactory factory)
    : IWeatherRepository
{
    private static string GetUrl(int id) => string.Format("https://services.gismeteo.ru/inform-service/inf_chrome/forecast/?city={0}&lang=ru", id);

    public async Task<Weather> Get(int cityId, CancellationToken cancellationToken = default)
    {
        var url = GetUrl(cityId);
        using var client = factory.CreateClient();
        var response = await client.GetAsync(url, cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            var serializer = new XmlSerializer(typeof(WeatherResponse));
            var weatherResponse = (WeatherResponse)serializer.Deserialize(response.Content.ReadAsStream(cancellationToken));
            var fact = weatherResponse?.Location?.Fact;
            var values = fact?.Values;
            if (values is null)
                return null;
            var timestamp = fact.Timestamp;
            return new Weather { CityId = cityId, Timestamp = timestamp, 
                                 Temperature = values.Temperature, Icon = values.Icon, Description = values.Description,
                                 Wind = values.Wind, Water = values.Water, Humidity = values.Humidity, Pressure = values.Pressure };
        }
        throw new HttpRequestException("Ошибка получения погоды", null, response.StatusCode);
    }
}

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