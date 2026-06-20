namespace Application.Commands;

public record UpdateWeatherCommand(int CityId) : IRequest;
