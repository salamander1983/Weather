using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface ICitiesRepository
{
    Task Create(City city, CancellationToken cancellationToken = default);
    Task<IEnumerable<City>> Search(string name, CancellationToken cancellationToken = default);
}
