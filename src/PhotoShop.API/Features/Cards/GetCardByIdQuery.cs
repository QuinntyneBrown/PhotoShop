using PhotoShop.Core.Interfaces;
using PhotoShop.Core.Models;
using FluentValidation;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PhotoShop.API.Features.Cards
{
    public class GetCardByIdQuery
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.CardId).NotEqual(default(Guid));
            }
        }

        public class Request : IRequest<Response> {
            public Guid CardId { get; set; }
        }

        public class Response
        {
            public CardDto Card { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IRepository _repository;

            public Handler(IRepository repository) => _repository = repository;

            public Task<Response> Handle(Request request, CancellationToken cancellationToken)
                 => Task.FromResult(new Response()
                {
                    Card = CardDto.FromCard(_repository.Query<Card>().Single(x=>x.CardId == request.CardId))
                });
        }
    }
}
