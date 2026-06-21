using Application.Exceptions;

using Domain.Entities;
using Domain.Interfaces.External;
using Domain.Interfaces.Repositories;

namespace Application.Commands;

internal class UpdateWeatherCommandHandler(IWeatherRepository weatherRepository,
                                           IForecastRepository forecastRepository)
    : IRequestHandler<UpdateWeatherCommand>
{
    private readonly JsonSerializerOptions _jsonOptions = new() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };

    public async Task Handle(UpdateWeatherCommand request, CancellationToken cancellationToken)
    {
        var weather = await forecastRepository.Get(request.CityId, cancellationToken)
            ?? throw new NotFoundException($"Для города с идентификатором {request.CityId} информация о погоде не найдена");
        
        var existed = await weatherRepository.Get(request.CityId, cancellationToken);
        if (existed is null)
        {
            await weatherRepository.Create(weather, cancellationToken);
        }
        else if (existed.Timestamp != weather.Timestamp)
        {
            existed.City = null;
            var history = new WeatherHistory
            {
                Timestamp = existed.Timestamp,
                CityId = existed.CityId,
                Data = JsonSerializer.Serialize(existed, _jsonOptions),
            };
            await weatherRepository.CreateHistory(history, cancellationToken);
            await weatherRepository.Update(weather, cancellationToken);
        }
    }
}
