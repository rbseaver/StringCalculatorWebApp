using System.Threading.Tasks;

namespace StringCalculator.Core.Services
{
    public interface IVersionService
    {
        Task<string> GetVersionAsync<T>();
    }
}