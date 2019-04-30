using System.Threading.Tasks;

namespace StringCalculator.Core.Interfaces
{
    public interface ICalculatorService
    {
        Task<int> Add(string input);
    }
}