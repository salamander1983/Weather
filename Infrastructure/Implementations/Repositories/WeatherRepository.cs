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
        return await context.Weathers
                        .Include(x => x.City)
                        .FirstOrDefaultAsync(x => x.CityId == cityId, cancellationToken);
    }

    public async Task Create(Weather weather, CancellationToken cancellationToken = default)
    {
        using var context = await factory.CreateDbContextAsync(cancellationToken);
        context.Weathers.Add(weather);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(Weather weather, CancellationToken cancellationToken = default)
    {
        using var context = await factory.CreateDbContextAsync(cancellationToken);
        context.Weathers.Update(weather);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task CreateHistory(WeatherHistory weatherHistory, CancellationToken cancellationToken = default)
    {
        using var context = await factory.CreateDbContextAsync(cancellationToken);
        context.WeatherHistories.Add(weatherHistory);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<WeatherHistory>> GetHistory(int cityId, CancellationToken cancellationToken = default)
    {
        using var context = await factory.CreateDbContextAsync(cancellationToken);
        return await context.WeatherHistories
                        .Where(x => x.CityId == cityId)
                        .ToListAsync(cancellationToken);
    }
}
