namespace StringCalculator.Core.Services
{
    public interface IAssemblyProvider
    {
        string GetAssemblyVersion<T>();
    }
}