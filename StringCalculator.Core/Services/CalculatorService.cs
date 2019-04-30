using StringCalculator.Core.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace StringCalculator.Core.Services
{
    public class CalculatorService : ICalculatorService
    {
        public async Task<int> Add(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return await Task.FromResult(0);
            }

            if (input.Length == 1)
            {
                return await Task.FromResult(int.Parse(input));
            }

            var nums = input.Split(',', '\n');

            var sum = nums.Sum(x => int.Parse(x));

            return await Task.FromResult(sum);
        }
    }
}