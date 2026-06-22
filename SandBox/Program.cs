using ApiClient;

var builder = Host.CreateApplicationBuilder();

builder.Services.AddHttpClient<ApiV1>();

var host = builder.Build();

var weather = host.Services.GetService<ApiV1>();
weather.BaseUrl = builder.Configuration["Api"];

var cities = await weather.CityAllAsync(string.Empty);
foreach (var city in cities)
{
    Console.WriteLine($"{city.Id} {city.Name}");
    var current = await weather.WeatherAsync(city.Id);
    Console.WriteLine($"{current.Timestamp} {current.Temperature}");
    var histories = await weather.HistoryAsync(city.Id);
    foreach (var history in histories.History)
        Console.WriteLine($"{history.Timestamp} {history.Temperature}");
}

host.Run();
