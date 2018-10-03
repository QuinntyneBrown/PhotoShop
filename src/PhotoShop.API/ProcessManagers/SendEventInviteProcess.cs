using System.Threading;
using System.Threading.Tasks;
using PhotoShop.Core.DomainEvents;
using PhotoShop.Core.Interfaces;
using MediatR;

namespace PhotoShop.API.ProcessManagers
{
    public class SendEventInviteProcess
        : INotificationHandler<EventInviteRequested>
    {
        private readonly IEventStore _eventStore;
        private readonly IMediator _mediator;
        public SendEventInviteProcess(IEventStore eventStore, IMediator mediator)
        {
            _eventStore = eventStore;
            _mediator = mediator;
        }

        public async Task Handle(EventInviteRequested notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
