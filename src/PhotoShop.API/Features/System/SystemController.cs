using PhotoShop.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PhotoShop.API.Features
{
    [ApiController]
    [Route("api/system")]
    public class SystemController
    {
        private readonly IDateTime _dateTime;

        public SystemController(IDateTime dateTime) => _dateTime = dateTime;

        [HttpGet]
        [Route("")]
        public ActionResult<string> Get() => $"{_dateTime.UtcNow}";
    }
}
