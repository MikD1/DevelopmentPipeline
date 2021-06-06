using DemoApp.WebApi.Dto;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/calculation")]
    public class CalculationController : ControllerBase
    {
        public CalculationController(Calculator calculator)
        {
            _calculator = calculator;
        }

        [HttpPost]
        public ActionResult Post(CalculationDto dto)
        {
            int result = _calculator.Sum(dto.A, dto.B);
            return Ok(result);
        }

        private readonly Calculator _calculator;
    }
}
