using System.Threading.Tasks;

namespace StringCalculator.Core.Interfaces
{
    public interface IVersionService
    {
        Task<string> GetVersionAsync<T>();
    }
}