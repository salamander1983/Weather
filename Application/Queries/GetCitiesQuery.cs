using Application.Dtos;

namespace Application.Queries;

public record GetCitiesQuery(string Name) : IRequest<IEnumerable<CityDto>>;
