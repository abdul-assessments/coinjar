namespace Coinage.Core.Interfaces
{
    public interface ICoinFactory
    {
        ICoin GetCoin<T>(decimal amount) where T : ICoin;
    }
}
