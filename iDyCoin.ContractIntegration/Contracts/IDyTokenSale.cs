using iDyCoin.ContractIntegration.Utils;

namespace iDyCoin.ContractIntegration.Contracts;

public class IDyTokenSale : IContract
{
    public string ContractAddress { get; set; }

    public IDyTokenSale()
    {
        ContractAddress = ContractTools.GetContracAddress<IDyTokenSale>("5777");
    }
}