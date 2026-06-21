using Domain.Events;
using Domain.Interfaces.Dispatchers;

namespace Infrastructure.Implementations.Dispatchers;

internal class EventDispatcher(IMediator mediator)
    : IEventDispatcher
{
    public async Task Dispatch(IDomainEvent @event, CancellationToken cancellationToken)
    {
        await mediator.Publish(@event, cancellationToken);
    }
}
