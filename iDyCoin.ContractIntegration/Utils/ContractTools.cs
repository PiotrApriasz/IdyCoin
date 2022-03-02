using iDyCoin.ContractIntegration.Contracts;
using Nethereum.Web3;
using Newtonsoft.Json;

namespace iDyCoin.ContractIntegration.Utils;

public static class ContractTools
{
    public static string GetContracAddress<T>(string chainId) where T : IContract
    {
        var contractName = typeof(T).Name;
        var contractBuildPath = $"../../../../iDyCoin.Ethereum/build/contracts/{contractName}.json";

        var contractJson = File.ReadAllText(contractBuildPath);

        dynamic contractInfo = JsonConvert.DeserializeObject(contractJson);
        var networks = contractInfo.networks.ToString();

        var networksDic = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(networks);

        var contractAddress = (string)networksDic[chainId].address;

        return contractAddress;
    }
}