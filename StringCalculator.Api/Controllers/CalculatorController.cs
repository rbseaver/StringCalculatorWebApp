using Microsoft.AspNetCore.Mvc;
using StringCalculator.Core.Interfaces;
using StringCalculator.Core.Models;
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
        public async Task<int> Post([FromBody] SumRequest numberList)
        {
            return await calculatorService.Add(numberList.Numbers);
        }
    }
}