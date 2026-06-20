namespace Domain.Entities;

public class Weather
{
    public DateTimeOffset Timestamp { get; set; }

    public double Temperature { get; set; }
    public string Icon { get; set; }
    public string Description { get; set; }
    public double Wind { get; set; }
    public double Water { get; set; }
    public double Humidity { get; set; }
    public double Pressure { get; set; }

    public int CityId { get; set; }
    public City City { get; set; }
}
