using iDyCoin.ContractIntegration.Core.ContractInteraction.QueryMethods;
using iDyCoin.ContractIntegration.Core.ContractInteraction.TransactionMethods;
using iDyCoin.ContractIntegration.Utils;
using iDyCoin.Metamask.Ethereum;
using iDyCoin.Metamask.Metamask;
using Nethereum.RPC.Eth;
using Nethereum.RPC.Eth.DTOs;

namespace iDyCoin.ContractIntegration.Contracts;

public class KycContract : IContract
{
    private readonly IEthereumHostProvider _ethereumHostProvider;
    
    public string ContractAddress { get; set; }

    public KycContract()
    {
        ContractAddress = ContractTools.GetContracAddress<KycContract>("5777");
        _ethereumHostProvider = new MetamaskHostProvider();
    }

    public async Task SetKycCompleted(string addr)
    {
        var web3 = await _ethereumHostProvider.GetWeb3Async();
        
        var setKycCompletedFunctionMessage = new SetKycCompletedFunction()
        {
            Addr = addr,
            FromAddress = web3.TransactionManager.Account.Address,
            Nonce = await web3.Eth.Transactions.GetTransactionCount
                .SendRequestAsync(web3.TransactionManager.Account.Address, BlockParameter.CreatePending())
        };

        var test = web3.Eth.GetBalance;

        var transactionHandler = web3.Eth.GetContractTransactionHandler<SetKycCompletedFunction>();
        var transactionHash =
            await transactionHandler.SendRequestAsync(ContractAddress, setKycCompletedFunctionMessage);
    }

    public async Task SetKycRevoked(string addr)
    {
        var web3 = await _ethereumHostProvider.GetWeb3Async();

        var setKycRevokedFunctionMessage = new SetKycRevokedFunction()
        {
            Addr = addr,
            FromAddress = web3.TransactionManager.Account.Address
        };

        var transactionHandler = web3.Eth.GetContractTransactionHandler<SetKycRevokedFunction>();
        var transactionHash = 
            await transactionHandler.SendRequestAsync(ContractAddress, setKycRevokedFunctionMessage);
    }

    public async Task<bool> KycCompleted(string addr)
    {
        var web3 = await _ethereumHostProvider.GetWeb3Async();
        
        var kycCompletedFunctionMessage = new KycCompletedFunction()
        {
            Addr = addr
        };

        var queryHandler = web3.Eth.GetContractQueryHandler<KycCompletedFunction>();
        var kycCompleted = await queryHandler.QueryAsync<bool>(ContractAddress, kycCompletedFunctionMessage);

        return kycCompleted;
    }
    
}