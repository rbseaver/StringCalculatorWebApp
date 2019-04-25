using Microsoft.AspNetCore.Mvc;
using StringCalculator.Core.Services;
using System.Threading.Tasks;

namespace StringCalculator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorService calculatorService;

        public CalculatorController(ICalculatorService calculatorService)
        {
            this.calculatorService = calculatorService;
        }

        [HttpPost]
        public async Task<int> Post([FromBody] string value)
        {
            return await calculatorService.Add(value);
        }
    }
}