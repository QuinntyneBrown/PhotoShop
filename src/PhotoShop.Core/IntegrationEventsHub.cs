using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace PhotoShop.Core
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class IntegrationEventsHub: Hub { }
}
