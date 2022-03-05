using iDyCoin.Metamask.Ethereum;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;

namespace iDyCoin.Metamask.Metamask;

public class MetamaskHostProvider : IEthereumHostProvider
{
    public Task<Web3> GetWeb3Async()
    {
        var url = "HTTP://127.0.0.1:7545";
        var accountPrivateKey = "22927be080f9e6d8c73cab619b9de6be21b7efda9d8b35f419c53bf082c4d314";
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