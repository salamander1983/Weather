using Domain.Events;

namespace Domain.Interfaces.Dispatchers;

public interface IEventDispatcher
{
    Task Dispatch(IDomainEvent @event, CancellationToken cancellationToken = default);
}
