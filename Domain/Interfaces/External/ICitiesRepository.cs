using Domain.Entities;

namespace Domain.Interfaces.External;

public interface ICitiesRepository
{
    Task<City> Get(string name, CancellationToken cancellationToken = default);
}
