using PhotoShop.Core.Identity;
using PhotoShop.Core.Interfaces;
using PhotoShop.Core.Models;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PhotoShop.API.Features.Users
{
    public class AuthenticateCommand
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Username).NotEqual(default(string));
                RuleFor(request => request.Password).NotEqual(default(string));
            }            
        }

        public class Request : IRequest<Response>
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public class Response
        {
            public string AccessToken { get; set; }
            public Guid UserId { get; set; }
            public IEnumerable<string> Roles { get; set; }
            public string Username { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IRepository _repository;
            private readonly IPasswordHasher _passwordHasher;
            private readonly ISecurityTokenFactory _securityTokenFactory;

            public Handler(
                IRepository repository,
                ISecurityTokenFactory securityTokenFactory, 
                IPasswordHasher passwordHasher)
            {
                _repository = repository;
                _securityTokenFactory = securityTokenFactory;
                _passwordHasher = passwordHasher;
            }

            public Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {                                
                var user = _repository.Query<User>().Single(x => x.Username == request.Username);

                var roles = new List<string>();

                if (user.Password != _passwordHasher.HashPassword(user.Salt, request.Password))
                    throw new System.Exception();

                foreach (var roleId in user.RoleIds)
                    roles.Add(_repository.Query<Role>(roleId).Name);

                return Task.FromResult(new Response()
                {
                    AccessToken = _securityTokenFactory.Create(user.UserId, request.Username, roles),
                    UserId = user.UserId,
                    Roles = roles,
                    Username = request.Username
                });
            }            
        }
    }
}
