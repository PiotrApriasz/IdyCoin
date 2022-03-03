using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;

namespace iDyCoin.ContractIntegration.Core.ContractInteraction.TransactionMethods;

[Function("buyTokens")]
public class BuyTokensFunction : FunctionMessage
{
    [Parameter("address", "beneficiary", 1)]
    public string Beneficiary { get; set; }
}