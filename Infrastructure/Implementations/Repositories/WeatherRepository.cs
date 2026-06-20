using Domain.Entities;
using Domain.Interfaces.Repositories;

using Infrastructure.DbContexts;

namespace Infrastructure.Implementations.Repositories;

internal class WeatherRepository(IDbContextFactory<WeatherContext> factory)
    : IWeatherRepository
{
    public async Task<Weather> Get(int cityId, CancellationToken cancellationToken = default)
    {
        using var context = await factory.CreateDbContextAsync(cancellationToken);
        return await context.Wheaters
                        .Include(x => x.City)
                        .FirstOrDefaultAsync(x => x.CityId == cityId, cancellationToken);
    }

    public async Task Create(Weather weather, CancellationToken cancellationToken = default)
    {
        using var context = await factory.CreateDbContextAsync(cancellationToken);
        context.Wheaters.Add(weather);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(Weather weather, CancellationToken cancellationToken = default)
    {
        using var context = await factory.CreateDbContextAsync(cancellationToken);
        context.Update(weather);
        await context.SaveChangesAsync(cancellationToken);
    }
}
