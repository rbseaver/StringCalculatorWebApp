using System.Reflection;
using System.Threading.Tasks;

namespace StringCalculator.Core.Services
{
    public class VersionService : IVersionService
    {
        public Task<string> GetVersion()
        {
            var version = Assembly
                .GetExecutingAssembly()
                .GetName()
                .Version.ToString();

            return Task.FromResult(version);
        }
    }
}