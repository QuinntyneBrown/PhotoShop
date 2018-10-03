using PhotoShop.Core.Interfaces;
using PhotoShop.Core.Models;
using FluentValidation;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PhotoShop.API.Features.DashboardCards
{
    public class GetDashboardCardByIdQuery
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.DashboardCardId).NotEqual(default(Guid));
            }
        }

        public class Request : IRequest<Response> {
            public Guid DashboardCardId { get; set; }
        }

        public class Response
        {
            public DashboardCardDto DashboardCard { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IRepository _repository;

            public Handler(IRepository repository) => _repository = repository;

            public Task<Response> Handle(Request request, CancellationToken cancellationToken)
                 => Task.FromResult(new Response()
                {
                    DashboardCard = DashboardCardDto.FromDashboardCard(_repository.Query<DashboardCard>().Single(x => x.DashboardCardId == request.DashboardCardId))
                });
        }
    }
}
