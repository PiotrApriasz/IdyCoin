using iDyCoin.ContractIntegration.Core.ContractInteraction.TransactionMethods;
using iDyCoin.ContractIntegration.Utils;
using iDyCoin.Metamask.Ethereum;
using iDyCoin.Metamask.Metamask;

namespace iDyCoin.ContractIntegration.Contracts;

public class KycContract : IContract
{
    private IEthereumHostProvider _ethereumHostProvider;
    
    public string ContractAddress { get; set; }

    public KycContract()
    {
        ContractAddress = ContractTools.GetContracAddress<KycContract>("5777");
        _ethereumHostProvider = new MetamaskHostProvider();
    }

    public async Task SetKycCompleted(string addr)
    {
        var setKycCompletedFunctionMessage = new SetKycCompletedFunction()
        {
            Addr = addr
        };

        var web3 = await _ethereumHostProvider.GetWeb3Async();
    }
}