using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IWeatherRepository
{
    Task Upsert(Weather weather, CancellationToken cancellationToken = default);
}
