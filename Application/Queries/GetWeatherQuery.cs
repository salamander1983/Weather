using Application.Dtos;

namespace Application.Queries;

public record GetWeatherQuery(int CityId) : IRequest<WeatherDto>;
