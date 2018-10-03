using PhotoShop.Core.Models;
using System;

namespace PhotoShop.API.Features.ServiceProviders
{
    public class ServiceProviderDto
    {        
        public Guid ServiceProviderId { get; set; }
        public string FirstName { get; set; }

        public static ServiceProviderDto FromServiceProvider(ServiceProvider serviceProvider)
            => new ServiceProviderDto
            {
                ServiceProviderId = serviceProvider.ServiceProviderId,
                FirstName =serviceProvider.FirstName
            };
    }
}
