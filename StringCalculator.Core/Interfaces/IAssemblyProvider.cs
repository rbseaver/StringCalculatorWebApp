namespace StringCalculator.Core.Interfaces
{
    public interface IAssemblyProvider
    {
        string GetAssemblyVersion<T>();
    }
}