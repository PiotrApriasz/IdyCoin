using System.Numerics;

namespace iDyCoin.ContractIntegration.Contracts;

public interface IContract
{
    public string ContractAddress { get; set; }
    public Task<BigInteger> BalanceOf(string addr);
}