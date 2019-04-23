using System.Threading.Tasks;

namespace StringCalculator.Core.Services
{
    public class CalculatorService : ICalculatorService
    {
        public async Task<int> Add(string input)
        {
            return await Task.FromResult(0);
        }
    }
}