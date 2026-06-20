using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface ICityRepository
{
    Task Create(City city, CancellationToken cancellationToken = default);
    Task<City> Get(int cityId, CancellationToken cancellationToken = default);
    Task<IEnumerable<City>> Search(string name, CancellationToken cancellationToken = default);
}
