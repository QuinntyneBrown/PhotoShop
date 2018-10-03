using PhotoShop.Core.Interfaces;
using PhotoShop.Core.Models;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PhotoShop.API.Features.ShoppingCarts
{
    public class GetShoppingCartsQuery
    {
        public class Request : IRequest<Response> { }

        public class Response
        {
            public IEnumerable<ShoppingCartDto> ShoppingCarts { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IRepository _repository;

            public Handler(IRepository repository) => _repository = repository;

            public Task<Response> Handle(Request request, CancellationToken cancellationToken)
                => Task.FromResult(new Response()
                {
                    ShoppingCarts = _repository.Query<ShoppingCart>().Select(x => ShoppingCartDto.FromShoppingCart(x)).ToList()
                });
        }
    }
}
