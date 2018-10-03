using PhotoShop.Core.DomainEvents;
using PhotoShop.Core.Interfaces;
using PhotoShop.Core.Models;
using FluentValidation;
using MediatR;
using System;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace PhotoShop.API.Features.Dashboards
{
    public class RemoveDashboardCommand
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.DashboardId).NotEqual(default(Guid));
            }
        }

        public class Request : IRequest
        {
            public Guid DashboardId { get; set; }
        }

        public class Handler : IRequestHandler<Request>
        {
            private readonly IEventStore _eventStore;
            
            public Handler(IEventStore eventStore) => _eventStore = eventStore;

            public Task Handle(Request request, CancellationToken cancellationToken)
            {
                var dashboard = _eventStore.Load<Dashboard>(request.DashboardId);

                dashboard.Remove();
                
                _eventStore.Save(dashboard);

                return Task.CompletedTask;
            }
        }
    }
}
