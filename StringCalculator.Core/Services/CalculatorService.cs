using System.Threading.Tasks;

namespace StringCalculator.Core.Services
{
    public class CalculatorService : ICalculatorService
    {
        public async Task<int> Add(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }

            return await Task.FromResult(int.Parse(input));
        }
    }
}