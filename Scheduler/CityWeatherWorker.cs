using Application.Commands;
using Application.Queries;

namespace Scheduler;

public class CityWeatherWorker(ILogger<CityWeatherWorker> logger,
                               IMediator mediator) 
    : BackgroundService
{
    private readonly int _delay = 10_000;

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            if (logger.IsEnabled(LogLevel.Information))
                logger.LogInformation("Worker running at: {time}", DateTime.Now);

            await UpdateWeatherByCities(cancellationToken);

            await Task.Delay(_delay, cancellationToken);
        }
    }

    private async Task UpdateWeatherByCities(CancellationToken cancellationToken)
    {
        var cities = await mediator.Send(new GetCitiesQuery(default), cancellationToken);
        foreach (var city in cities)
        {
            if (logger.IsEnabled(LogLevel.Information))
                logger.LogInformation("Обновление погоды для города {name}", city.Name);

            await mediator.Send(new UpdateWeatherCommand(city.Id), cancellationToken);
        }
    }
}
