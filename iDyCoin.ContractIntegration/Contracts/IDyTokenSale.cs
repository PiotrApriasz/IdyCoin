using iDyCoin.ContractIntegration.Core.ContractInteraction.TransactionMethods;
using iDyCoin.ContractIntegration.Utils;
using iDyCoin.Metamask.Ethereum;
using iDyCoin.Metamask.Metamask;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;

namespace iDyCoin.ContractIntegration.Contracts;

public class IDyTokenSale : IContract
{
    private readonly IEthereumHostProvider _ethereumHostProvider;
    
    public string ContractAddress { get; set; }

    public IDyTokenSale()
    {
        ContractAddress = ContractTools.GetContracAddress<IDyTokenSale>("5777");
        _ethereumHostProvider = new MetamaskHostProvider();
    }

    public async Task BuyToken()
    {
        var web3 = await _ethereumHostProvider.GetWeb3Async();
        var transactionMessager = web3.TransactionManager;
        var fromAddress = transactionMessager.Account.Address;

        var transactionHash = await web3.Eth.TransactionManager
            .SendTransactionAsync(new TransactionInput()
            {
                From = fromAddress,
                To = ContractAddress,
                Value = new HexBigInteger(1),
                Gas = new HexBigInteger(900000)
            });
    }
}