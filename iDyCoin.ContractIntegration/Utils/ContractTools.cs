using System.Numerics;
using iDyCoin.ContractIntegration.Contracts;
using iDyCoin.ContractIntegration.Core.ContractInteraction.QueryMethods;
using iDyCoin.Metamask.Metamask;
using Nethereum.Web3;
using Newtonsoft.Json;

namespace iDyCoin.ContractIntegration.Utils;

public static class ContractTools
{
    public static string GetContracAddress<T>(string chainId) where T : IContract
    {
        var contractName = typeof(T).Name;
        var contractBuildPath = $"../../../../iDyCoin.Ethereum/build/contracts/{contractName}.json";
        //var contractBuildPath = $"E:/Projekty Blockchain/iDyCoin/iDyCoin.Ethereum/build/contracts/{contractName}.json"; 

        var contractJson = File.ReadAllText(contractBuildPath);

        dynamic contractInfo = JsonConvert.DeserializeObject(contractJson);
        var networks = contractInfo.networks.ToString();

        var networksDic = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(networks);

        var contractAddress = (string)networksDic[chainId].address;

        return contractAddress;
    }

    public static async Task<BigInteger> GetBalance(string addr)
    {
        var ethereumHostProvider = new MetamaskHostProvider(null);
        var web3 = await ethereumHostProvider.GetWeb3Async();

        var balance = await web3.Eth.GetBalance.SendRequestAsync(addr);

        return balance;
    }
}