using Nethereum.Web3;

namespace iDyCoin.Metamask.Ethereum;

public interface IEthereumHostProvider
{
    Task<Web3> GetWeb3Async();
}