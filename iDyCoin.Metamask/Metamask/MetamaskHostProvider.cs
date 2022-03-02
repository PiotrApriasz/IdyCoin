using iDyCoin.Metamask.Ethereum;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;

namespace iDyCoin.Metamask.Metamask;

public class MetamaskHostProvider : IEthereumHostProvider
{
    public Task<Web3> GetWeb3Async()
    {
        var url = "HTTP://127.0.0.1:7545";
        var accountPrivateKey = "2ca07427047e7bb91c9892eab0040482d29878f6c6e61d75bfbbb3c0865c81dc";
        var account = new Account(accountPrivateKey, 577);

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