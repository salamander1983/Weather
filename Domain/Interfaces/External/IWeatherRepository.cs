namespace Domain.Interfaces.External;

public interface IWeatherRepository
{
    Task<WeatherResponse> Get(WeatherRequest request, CancellationToken cancellationToken = default);
}
