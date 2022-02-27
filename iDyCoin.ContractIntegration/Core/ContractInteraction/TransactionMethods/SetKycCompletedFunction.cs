using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;

namespace iDyCoin.ContractIntegration.Core.ContractInteraction.TransactionMethods;

[Function("setKycCompleted")]
public class SetKycCompletedFunction : FunctionMessage
{
    [Parameter("address", "_addr", 1)]
    public string Addr { get; set; }
}