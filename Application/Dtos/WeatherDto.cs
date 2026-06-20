namespace Application.Dtos;

public class WeatherDto
{
    public string Name { get; set; }
    public DateTime Timestamp { get; set; }
    public double Temperature { get; set; }
    public string Icon { get; set; }
    public string Description { get; set; }
}
