using Domain.Entities;

namespace Domain.Interfaces.External;

public interface ICityRepository
{
    Task<City> Get(string name, CancellationToken cancellationToken = default);
}
