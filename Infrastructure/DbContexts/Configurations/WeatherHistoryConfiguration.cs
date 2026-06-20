using Domain.Entities;

namespace Infrastructure.DbContexts.Configurations;

internal class WeatherHistoryConfiguration : IEntityTypeConfiguration<WeatherHistory>
{
    public void Configure(EntityTypeBuilder<WeatherHistory> builder)
    {
        builder
            .ToTable("weather_histories")
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder
            .Property(x => x.Data)
            .HasColumnType("jsonb");

        builder
            .Property(x => x.Timestamp)
            .HasColumnType("timestamp without time zone");

        builder
            .HasOne(x => x.City)
            .WithMany(x => x.History)
            .HasForeignKey(x => x.CityId)
            .IsRequired(false);
    }
}
