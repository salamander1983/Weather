using Domain.Entities;

namespace Infrastructure.DbContexts.Configurations;

internal class WeatherConfiguration : IEntityTypeConfiguration<Weather>
{
    public void Configure(EntityTypeBuilder<Weather> builder)
    {
        builder
            .ToTable("weathers")
            .HasKey(x => x.CityId);

        builder
            .Property(x => x.CityId)
            .ValueGeneratedNever();

        builder
            .Property(x => x.Icon)
            .IsRequired();

        builder
            .Property(x => x.Description)
            .IsRequired();

        builder
            .HasOne(x => x.City)
            .WithOne(x => x.Weather)
            .HasForeignKey<Weather>(x => x.CityId)
            .IsRequired(false);
    }
}
