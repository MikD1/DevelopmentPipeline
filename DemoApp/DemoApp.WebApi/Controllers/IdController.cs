using System;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/id")]
    public class IdController : Controller
    {
        private static readonly Guid Id = Guid.NewGuid();

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(Id);
        }
    }
}
