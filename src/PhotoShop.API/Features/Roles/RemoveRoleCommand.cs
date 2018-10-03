using PhotoShop.Core.Interfaces;
using PhotoShop.Core.Models;
using FluentValidation;
using MediatR;
using System;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace PhotoShop.API.Features.Roles
{
    public class RemoveRoleCommand
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.RoleId).NotEqual(default(Guid));
            }
        }

        public class Request : IRequest
        {
            public Guid RoleId { get; set; }
        }

        public class Handler : IRequestHandler<Request>
        {
            private readonly IEventStore _eventStore;
            
            public Handler(IEventStore eventStore) => _eventStore = eventStore;

            public Task Handle(Request request, CancellationToken cancellationToken)
            {
                var role = _eventStore.Load<Role>(request.RoleId);

                role.Remove();
                
                _eventStore.Save(role);

                return Task.CompletedTask;
            }
        }
    }
}
