using Application.Dtos;

using Domain.Interfaces.Repositories;

namespace Application.Queries;

internal class GetCitiesQueryHandler(ICityRepository cityRepository)
    : IRequestHandler<GetCitiesQuery, IEnumerable<CityDto>>
{
    public async Task<IEnumerable<CityDto>> Handle(GetCitiesQuery request, CancellationToken cancellationToken)
    {
        var cities = await cityRepository.Search(request.Name, cancellationToken);
        return cities.Select(x => new CityDto 
        { 
            Id = x.Id, 
            Name = x.Name 
        });
    }
}
