using System.Numerics;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace iDyCoin.ContractIntegration.Core.ContractInteraction.Events;

[Event("TokensPurchased")]
public class TokenPurchasedEventDto : IEventDTO
{
    [Parameter("address", "purchaser", 1, true)]
    public string Purchaser { get; set; }

    [Parameter("address", "beneficiary", 2, true)]
    public string Beneficiary { get; set; }

    [Parameter("uint256", "value", 3, false)]
    public BigInteger Value { get; set; }

    [Parameter("uint256", "amount", 4, false)]
    public BigInteger Amount { get; set; }
    
}