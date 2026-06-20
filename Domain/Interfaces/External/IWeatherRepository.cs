using Domain.Entities;

namespace Domain.Interfaces.External;

public interface IWeatherRepository
{
    Task<Weather> Get(int cityId, CancellationToken cancellationToken = default);
}
