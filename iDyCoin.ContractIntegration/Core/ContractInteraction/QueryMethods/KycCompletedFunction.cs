using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;

namespace iDyCoin.ContractIntegration.Core.ContractInteraction.QueryMethods;

[Function("kycCompleted", "bool")]
public class KycCompletedFunction : FunctionMessage
{
    [Parameter("address", "_addr", 1)]
    public string Addr { get; set; }
}