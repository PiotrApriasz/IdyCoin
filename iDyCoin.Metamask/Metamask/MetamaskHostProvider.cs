using iDyCoin.Metamask.Ethereum;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;

namespace iDyCoin.Metamask.Metamask;

public class MetamaskHostProvider : IEthereumHostProvider
{
    public Task<Web3> GetWeb3Async()
    {
        var url = "HTTP://127.0.0.1:7545";
        var accountPrivateKey = "f7dd2050d4a4def134dbba75f5255f4f7fb2eb45c3e02f477a7ff949b767ed2c";
        var account = new Account(accountPrivateKey, 5777);

        var web3 = new Web3(account, url)
        {
            TransactionManager =
            {
                UseLegacyAsDefault = true
            }
        };

        return Task.FromResult(web3);
    }
}