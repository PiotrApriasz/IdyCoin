using iDyCoin.ContractIntegration.Utils;

namespace iDyCoin.ContractIntegration.Contracts;

public class KycContract : IContract
{
    public string ContractAddress { get; set; }

    public KycContract()
    {
        ContractAddress = ContractTools.GetContracAddress<KycContract>("5777");
    }
}