using Application;
using Infrastructure;
using Scheduler;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.RegisterInfrastructure();
builder.Services.RegisterApplication();
builder.Services.AddHostedService<CityWeatherWorker>();

var host = builder.Build();
host.Run();
