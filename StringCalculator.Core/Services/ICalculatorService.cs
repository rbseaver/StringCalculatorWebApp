using System.Threading.Tasks;

namespace StringCalculator.Core.Services
{
    public interface ICalculatorService
    {
        Task<int> Add(string input);
    }
}