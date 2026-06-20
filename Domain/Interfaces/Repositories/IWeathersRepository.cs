using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IWeathersRepository
{
    Task Upsert(Weather weather, CancellationToken cancellationToken = default);
}
