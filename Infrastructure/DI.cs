using Domain.Interfaces.External;

using Infrastructure.Implementations.External;

namespace Infrastructure;

public static class DI
{
    extension(IServiceCollection services)
    {
        public IServiceCollection RegisterInfrastructure()
        {
            return services
                .AddHttpClient()
                .AddSingleton<ICityRepository, CityRepository>()
                .AddSingleton<IWeatherRepository, WeatherRepository>();
        }
    }
}
