namespace Domain.Interfaces.External;

public interface ICityRepository
{
    Task<CityResponse> Get(CityRequest request, CancellationToken cancellationToken = default);
}
