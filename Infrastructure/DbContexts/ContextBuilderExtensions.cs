namespace Infrastructure.DbContexts;

internal static class ContextBuilderExtensions
{
    extension(DbContextOptionsBuilder builder)
    {
        public DbContextOptionsBuilder AssignOptions()
        {
            return builder
                .UseNpgsql()
                .UseSnakeCaseNamingConvention()
                .ConfigureWarnings(x => x.Ignore(RelationalEventId.PendingModelChangesWarning));
        }
    }
}
