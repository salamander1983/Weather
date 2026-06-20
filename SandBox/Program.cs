using Application;
using Application.Commands;
using Application.Queries;

using Infrastructure;

var builder = Host.CreateApplicationBuilder();

builder.Services.RegisterInfrastructure(builder.Configuration.GetConnectionString("DB"));
builder.Services.RegisterApplication();

var host = builder.Build();

var cityName = "Москва";
var mediator = host.Services.GetRequiredService<IMediator>();
var cityExisted = await mediator.Send(new GetCitiesQuery(cityName));
foreach (var cityExist in cityExisted)
    Console.WriteLine($"{cityExist.Id} {cityExist.Name}");
await mediator.Send(new CreateCityCommand(cityName));

host.Run();
