using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IWeatherRepository
{
    Task Upsert(Weather weather, CancellationToken cancellationToken = default);
    Task<Weather> Get(int cityId, CancellationToken cancellationToken = default);
}
