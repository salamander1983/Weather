namespace Infrastructure.DbContexts;

internal class DesignWeatherContextFactory : IDesignTimeDbContextFactory<WeatherContext>
{
    public WeatherContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<WeatherContext>();
        builder.AssignOptions();
        var options = builder.Options;
        return new WeatherContext(options);
    }
}
