namespace Application.Dtos;

public class HistoryDto
{
    public string Name { get; set; }
    public IEnumerable<WeatherDto> History { get; set; }
}
