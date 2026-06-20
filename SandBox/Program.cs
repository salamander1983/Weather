using Domain.Interfaces.External;

using Infrastructure;

var builder = Host.CreateApplicationBuilder();

builder.Services.RegisterInfrastructure();

var host = builder.Build();

var externalCity = host.Services.GetRequiredService<ICitiesRepository>();
var city = await externalCity.Get("Москва");
Console.WriteLine($"{city.Id} {city.Name}");

var externalWeather = host.Services.GetRequiredService<IForecastRepository>();
var forecast = await externalWeather.Get(city.Id);
Console.WriteLine($"{forecast.Temperature} {forecast.Description}");

host.Run();
