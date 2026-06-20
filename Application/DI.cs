namespace Application;

public static class DI
{
    extension(IServiceCollection services)
    {
        public IServiceCollection RegisterApplication()
        {
            return services
                .AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
        }
    }
}
