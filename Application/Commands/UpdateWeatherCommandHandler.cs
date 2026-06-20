using Application.Exceptions;

using Domain.Interfaces.External;
using Domain.Interfaces.Repositories;

namespace Application.Commands;

internal class UpdateWeatherCommandHandler(IWeatherRepository weatherRepository,
                                           IForecastRepository forecastRepository)
    : IRequestHandler<UpdateWeatherCommand>
{
    public async Task Handle(UpdateWeatherCommand request, CancellationToken cancellationToken)
    {
        var weather = await forecastRepository.Get(request.CityId, cancellationToken)
            ?? throw new NotFoundException($"Для города с идентификатором {request.CityId} информация о погоде не найдена");
        await weatherRepository.Upsert(weather, cancellationToken);
    }
}
