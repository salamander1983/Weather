using ApiClient;

var builder = Host.CreateApplicationBuilder();

builder.Services.AddHttpClient<Weather>();

var host = builder.Build();

var weather = host.Services.GetService<Weather>();
weather.BaseUrl = builder.Configuration["Api"];

var cities = await weather.CityAllAsync(string.Empty);
foreach (var city in cities)
{
    Console.WriteLine($"{city.Id} {city.Name}");
    var histories = await weather.HistoryAsync(city.Id);
    foreach (var history in histories.History)
        Console.WriteLine($"{history.Timestamp} {history.Temperature}");
}

host.Run();
