using Application.Commands;
using Application.Dtos;
using Application.Queries;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherController(IMediator mediator)
    : ControllerBase
{
    [HttpGet]
    public async Task<WeatherDto> Get([FromQuery] GetWeatherQuery query, CancellationToken cancellationToken) =>
        await mediator.Send(query, cancellationToken);

    [HttpGet("{cityId:int}/history")]
    public async Task<HistoryDto> Get([FromRoute] int cityId, CancellationToken cancellationToken) =>
        await mediator.Send(new GetHistoryQuery(cityId), cancellationToken);

    [HttpPut("{cityId:int}/update")]
    public async Task Upsert([FromRoute] int cityId, CancellationToken cancellationToken) =>
        await mediator.Send(new UpdateWeatherCommand(cityId), cancellationToken);
}
