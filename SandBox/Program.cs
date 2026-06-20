using Domain.Interfaces.External;

using Infrastructure;

var builder = Host.CreateApplicationBuilder();

builder.Services.RegisterInfrastructure();

var host = builder.Build();

var externalCity = host.Services.GetRequiredService<ICityRepository>();
var city = await externalCity.Get("Москва");
Console.WriteLine($"{city.Id} {city.Name}");

var externalWeather = host.Services.GetRequiredService<IWeatherRepository>();
var weather = await externalWeather.Get(city.Id);
Console.WriteLine($"{weather.Temperature} {weather.Description}");

host.Run();
