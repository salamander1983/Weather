using Domain.Entities;

using Infrastructure.DbContexts.Configurations;

namespace Infrastructure.DbContexts;

internal class WeatherContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<City> Cities { get; set; }
    public DbSet<Weather> Weathers { get; set; }
    public DbSet<WeatherHistory> WeatherHistories { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AssignOptions();

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CityConfiguration());
        modelBuilder.ApplyConfiguration(new WeatherConfiguration());
        modelBuilder.ApplyConfiguration(new WeatherHistoryConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
