namespace Domain.Entities;

public class City
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public Weather Weather { get; set; }

    public List<WeatherHistory> History { get; set; } = [];
}
