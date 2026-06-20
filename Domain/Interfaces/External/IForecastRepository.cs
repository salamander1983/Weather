using Domain.Entities;

namespace Domain.Interfaces.External;

public interface IForecastRepository
{
    Task<Weather> Get(int cityId, CancellationToken cancellationToken = default);
}
