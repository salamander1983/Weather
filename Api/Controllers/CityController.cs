using Application.Commands;
using Application.Dtos;
using Application.Queries;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CityController(IMediator mediator)
    : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<CityDto>> Get([FromQuery] GetCitiesQuery query, CancellationToken cancellationToken) =>
        await mediator.Send(query, cancellationToken);

    [HttpPost]
    public async Task Create([FromBody] CreateCityCommand command, CancellationToken cancellationToken) =>
        await mediator.Send(command, cancellationToken);
}
