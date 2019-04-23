using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StringCalculator.Core.Services;

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
        public async Task<int> Post(string value)
        {
            return await calculatorService.Add(value);
        }
    }
}