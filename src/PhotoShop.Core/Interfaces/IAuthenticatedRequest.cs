using MediatR;
using System;

namespace PhotoShop.Core.Interfaces
{
    public interface IAuthenticatedRequest
    {
        Guid CurrentUserId { get; set; }
    }
}
