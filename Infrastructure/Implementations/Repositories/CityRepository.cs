using Domain.Entities;
using Domain.Interfaces.Repositories;

using Infrastructure.DbContexts;

namespace Infrastructure.Implementations.Repositories;

internal class CityRepository(IDbContextFactory<WeatherContext> factory)
    : ICityRepository
{
    public async Task Create(City city, CancellationToken cancellationToken = default)
    {
        using var context = await factory.CreateDbContextAsync(cancellationToken);
        context.Cities.Add(city);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<City>> Search(string name, CancellationToken cancellationToken = default)
    {
        using var context = await factory.CreateDbContextAsync(cancellationToken);
        return await context.Cities
                        .Where(x => EF.Functions.ILike(x.Name, $"%{name}%"))
                        .ToListAsync(cancellationToken);
    }
}
