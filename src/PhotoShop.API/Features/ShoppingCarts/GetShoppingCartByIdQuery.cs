using PhotoShop.Core.Interfaces;
using PhotoShop.Core.Models;
using FluentValidation;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PhotoShop.API.Features.ShoppingCarts
{
    public class GetShoppingCartByIdQuery
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.ShoppingCartId).NotEqual(default(Guid));
            }
        }

        public class Request : IRequest<Response> {
            public Guid ShoppingCartId { get; set; }
        }

        public class Response
        {
            public ShoppingCartDto ShoppingCart { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IRepository _repository;

            public Handler(IRepository repository) => _repository = repository;

            public Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {                
                return Task.FromResult(new Response()
                {
                    ShoppingCart = ShoppingCartDto.FromShoppingCart(_repository.Query<ShoppingCart>(request.ShoppingCartId))
                });
            }
        }
    }
}
