using Application.Dtos;

using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Queries;

internal class GetHistoryQueryHandler(ICityRepository cityRepository,
                                      IWeatherRepository weatherRepository)
    : IRequestHandler<GetHistoryQuery, HistoryDto>
{
    public async Task<HistoryDto> Handle(GetHistoryQuery request, CancellationToken cancellationToken)
    {
        var city = await cityRepository.Get(request.CityId, cancellationToken);
        var history = await weatherRepository.GetHistory(request.CityId, cancellationToken);

        return new HistoryDto 
        { 
            Name = city.Name,
            History = history.Select(x =>
            {
                var weather = JsonSerializer.Deserialize<Weather>(x.Data);
                return new WeatherDto
                {
                    Timestamp = x.Timestamp,
                    Temperature = weather.Temperature,
                    Icon = weather.Icon,
                    Description = weather.Description,
                };
            })
        };
    }
}
