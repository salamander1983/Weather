using Application.Exceptions;

using Domain.Interfaces.External;
using Domain.Interfaces.Repositories;

namespace Application.Events;

internal class CityCreatedEventHandler(IWeatherRepository weatherRepository,
                                       IForecastRepository forecastRepository)
    : INotificationHandler<CityCreatedEvent>
{
    public async Task Handle(CityCreatedEvent notification, CancellationToken cancellationToken)
    {
        var weather = await forecastRepository.Get(notification.CityId, cancellationToken)
            ?? throw new NotFoundException($"Для города с идентификатором {notification.CityId} информация о погоде не найдена");

        await weatherRepository.Create(weather, cancellationToken);
    }
}
