using Application.Dtos;
using Application.Exceptions;

using Domain.Interfaces.Repositories;

namespace Application.Queries;

internal class GetWeatherQueryHandler(IWeatherRepository weatherRepository)
    : IRequestHandler<GetWeatherQuery, WeatherDto>
{
    public async Task<WeatherDto> Handle(GetWeatherQuery request, CancellationToken cancellationToken)
    {
        var weather = await weatherRepository.Get(request.CityId, cancellationToken)
            ?? throw new NotFoundException($"Для города с идентификатором {request.CityId} прогноз погоды не найден");

        return new WeatherDto
        {
            Name = weather.City?.Name,
            Timestamp = weather.Timestamp.ToLocalTime().DateTime,
            Temperature = weather.Temperature,
            Icon = weather.Icon,
            Description = weather.Description,
        };
    }
}
