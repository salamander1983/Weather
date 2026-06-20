using Domain.Interfaces.External;

using Infrastructure.Implementations.External.Gismeteo;

namespace Infrastructure;

public static class DI
{
    extension(IServiceCollection services)
    {
        public IServiceCollection RegisterInfrastructure()
        {
            return services
                .AddHttpClient()
                .AddSingleton<ICitiesRepository, CitiesRepository>()
                .AddSingleton<IForecastRepository, ForecastRepository>();
        }
    }
}
