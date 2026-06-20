namespace Domain.Entities;

public class WeatherHistory
{
    public int Id { get; set; }

    public DateTime Timestamp { get; set; }

    public string Data { get; set; }

    public int CityId { get; set; }
    public City City { get; set; }
}
