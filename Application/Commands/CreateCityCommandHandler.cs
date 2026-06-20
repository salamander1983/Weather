using Application.Exceptions;

using Domain.Interfaces.External;
using Domain.Interfaces.Repositories;

namespace Application.Commands;

internal class CreateCityCommandHandler(ICitiesRepository externalCitiesRepository, 
                                        ICityRepository internalCityRepository)
    : IRequestHandler<CreateCityCommand>
{
    public async Task Handle(CreateCityCommand request, CancellationToken cancellationToken)
    {
        var externalCity = await externalCitiesRepository.Get(request.Name, cancellationToken)
            ?? throw new NotFoundException($"Город {request.Name} не найден внешней системой");

        var internalCities = await internalCityRepository.Search(request.Name, cancellationToken);
        if (internalCities.Any())
        {
            var city = internalCities.FirstOrDefault(x => x.Name.ToLower().Trim() == request.Name.ToLower().Trim());
            if (city is not null)
                throw new NotFoundException($"Город {city.Name} уже существует с идентификатором {city.Id}");
        }

        await internalCityRepository.Create(externalCity, cancellationToken);
    }
}
