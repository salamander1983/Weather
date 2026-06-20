using Domain.Interfaces.External;
using Domain.Interfaces.Repositories;

using Infrastructure.DbContexts;
using Infrastructure.Implementations.External.Gismeteo;
using Infrastructure.Implementations.Repositories;

namespace Infrastructure;

public static class DI
{
    extension(IServiceCollection services)
    {
        public IServiceCollection RegisterInfrastructure(string connectionDB)
        {
            return services
                .RegisterExternal()
                .RegisterRepositories(connectionDB);
        }

        public IServiceCollection RegisterExternal()
        {
            return services
                .AddHttpClient()
                .AddSingleton<ICitiesRepository, CitiesRepository>()
                .AddSingleton<IForecastRepository, ForecastRepository>();
        }

        public IServiceCollection RegisterRepositories(string connectionDB)
        {
            return services
                .AddDbContextFactory<WeatherContext>(builder => builder.UseNpgsql(connectionDB))
                .AddSingleton<ICityRepository, CityRepository>()
                .AddSingleton<IWeatherRepository, WeatherRepository>();
        }
    }
}
