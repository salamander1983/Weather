using Domain.Events;

namespace Application.Events;

public record CityCreatedEvent(int CityId, string Name) : IDomainEvent;
