using StringCalculator.Core.Interfaces;

namespace StringCalculator.Core.Services
{
    public class AssemblyProvider : IAssemblyProvider
    {
        public string GetAssemblyVersion<T>()
        {
            return typeof(T).Assembly.
                GetName().
                Version.
                ToString();
        }
    }
}
