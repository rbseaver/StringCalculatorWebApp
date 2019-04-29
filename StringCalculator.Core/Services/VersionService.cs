using System.Threading.Tasks;

namespace StringCalculator.Core.Services
{
    public class VersionService : IVersionService
    {
        private readonly IAssemblyProvider assemblyProvider;

        public VersionService(IAssemblyProvider assemblyProvider)
        {
            this.assemblyProvider = assemblyProvider;
        }
        public Task<string> GetVersionAsync<T>()
        {
            var version = assemblyProvider.GetAssemblyVersion<T>();

            return Task.FromResult(version);
        }
    }
}