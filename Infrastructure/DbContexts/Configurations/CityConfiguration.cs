using Domain.Entities;

namespace Infrastructure.DbContexts.Configurations;

internal class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder
            .ToTable("cities")
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .ValueGeneratedNever();

        builder
            .Property(x => x.Name)
            .HasColumnType("citext")
            .IsRequired();

        builder
            .HasIndex(x => x.Name, "idx_name")
            .IsUnique();

        builder
            .HasOne(x => x.Weather)
            .WithOne(x => x.City)
            .HasForeignKey<City>(x => x.Id)
            .IsRequired(false);
    }
}
