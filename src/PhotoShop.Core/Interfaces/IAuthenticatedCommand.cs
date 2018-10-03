using MediatR;

namespace PhotoShop.Core.Interfaces
{
    public interface IAuthenticatedCommand<TResponse>: IAuthenticatedRequest, IRequest<TResponse>, ICommand<TResponse>
    {
    }
}
