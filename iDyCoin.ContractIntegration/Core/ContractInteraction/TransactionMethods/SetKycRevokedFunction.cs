using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;

namespace iDyCoin.ContractIntegration.Core.ContractInteraction.TransactionMethods;

[Function("setKycRevoked")]
public class SetKycRevokedFunction : FunctionMessage
{
    [Parameter("address", "_addr", 1)]
    public string Addr { get; set; }
}