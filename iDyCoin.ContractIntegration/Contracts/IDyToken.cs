using iDyCoin.ContractIntegration.Utils;

namespace iDyCoin.ContractIntegration.Contracts;

public class IDyToken : IContract
{
    public string ContractAddress { get; set; }
    
    public IDyToken()
    {
        ContractAddress = ContractTools.GetContracAddress<IDyToken>("5777");
    }
}