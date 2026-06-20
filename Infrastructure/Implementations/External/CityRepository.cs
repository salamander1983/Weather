using Domain.Entities;
using Domain.Interfaces.External;

namespace Infrastructure.Implementations.External;

internal class CityRepository(IHttpClientFactory factory)
    : ICityRepository
{
    private static string GetUrl(string name) => string.Format("https://services.gismeteo.ru/inform-service/inf_chrome/cities/?startsWith={0}&lang=ru", name);

    public async Task<City> Get(string cityName, CancellationToken cancellationToken = default)
    {
        var url = GetUrl(cityName);
        using var client = factory.CreateClient();
        var response = await client.GetAsync(url, cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            var serializer = new XmlSerializer(typeof(CityResponse));
            var cityResponse = (CityResponse)serializer.Deserialize(response.Content.ReadAsStream(cancellationToken));
            var item = cityResponse.Items.FirstOrDefault();
            if (item is null)
                return null;
            return new City { Id = item.Id, Name = item.Name, Latitude = item.Latitude, Longitude = item.Longitude };
        }
        throw new HttpRequestException("Ошибка получения города", null, response.StatusCode);
    }
}

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
