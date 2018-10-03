using PhotoShop.Core.Interfaces;
using PhotoShop.Core.Models;
using FluentValidation;
using MediatR;
using System;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace PhotoShop.API.Features.Mentees
{
    public class RemoveMenteeCommand
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.MenteeId).NotEqual(default(Guid));
            }
        }

        public class Request : IRequest
        {
            public Guid MenteeId { get; set; }
        }

        public class Handler : IRequestHandler<Request>
        {
            private readonly IEventStore _eventStore;
            
            public Handler(IEventStore eventStore) => _eventStore = eventStore;

            public Task Handle(Request request, CancellationToken cancellationToken)
            {
                var mentee = _eventStore.Load<Mentee>(request.MenteeId);

                mentee.Remove();
                
                _eventStore.Save(mentee);

                return Task.CompletedTask;
            }
        }
    }
}
