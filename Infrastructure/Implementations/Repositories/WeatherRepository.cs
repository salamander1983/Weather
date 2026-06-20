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

    public async Task Upsert(Weather weather, CancellationToken cancellationToken = default)
    {
        using var context = await factory.CreateDbContextAsync(cancellationToken);
        var existed = await context.Wheaters.FirstOrDefaultAsync(x => x.CityId == weather.CityId, cancellationToken);
        if (existed is null)
            context.Wheaters.Add(weather);
        else
            context.Wheaters.Entry(existed).CurrentValues.SetValues(weather);
        await context.SaveChangesAsync(cancellationToken);
    }
}
