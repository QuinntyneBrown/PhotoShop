using PhotoShop.Core.Interfaces;
using MediatR;
using System;

namespace PhotoShop.Core.Common
{
    public class AuthenticatedRequest<TResponse> : IAuthenticatedRequest, IRequest<TResponse>
    {
        public Guid CurrentUserId { get; set; }
    }
}
