using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IWeatherRepository
{
    Task Create(Weather weather, CancellationToken cancellationToken = default);
    Task Update(Weather weather, CancellationToken cancellationToken = default);
    Task<Weather> Get(int cityId, CancellationToken cancellationToken = default);
}
