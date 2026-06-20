using Scheduler;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<CityWeatherWorker>();

var host = builder.Build();
host.Run();
