using System.Numerics;
using iDyCoin.ContractIntegration.Core.ContractInteraction.QueryMethods;
using iDyCoin.ContractIntegration.Utils;
using iDyCoin.Metamask.Ethereum;
using iDyCoin.Metamask.Metamask;

namespace iDyCoin.ContractIntegration.Contracts;

public class IDyToken : IContract
{
    private readonly IEthereumHostProvider _ethereumHostProvider;
    
    public string ContractAddress { get; set; }

    public IDyToken()
    {
        ContractAddress = ContractTools.GetContracAddress<IDyToken>("5777");
        _ethereumHostProvider = new MetamaskHostProvider(null);
    }
    
    public async Task<BigInteger> BalanceOf(string addr)
    {
        var web3 = await _ethereumHostProvider.GetWeb3Async();

        var balanceOfFunctionMessage = new BalanceOfFunction()
        {
            Owner = addr
        };

        var queryHandler = web3.Eth.GetContractQueryHandler<BalanceOfFunction>();
        var balance = await queryHandler.QueryAsync<BigInteger>(ContractAddress, balanceOfFunctionMessage);

        return balance;
    }
}