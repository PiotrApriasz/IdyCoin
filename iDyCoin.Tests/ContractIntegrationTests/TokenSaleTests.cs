using iDyCoin.ContractIntegration.Contracts;
using Xunit;

namespace iDyCoin.Tests.ContractIntegrationTests;

public class TokenSaleTests
{
    [Fact]
     public async void BuyToken_ValidPUrchase_NewTokenAddedToBeneficiaryAccount()
    {
        var tokenSaleContract = new IDyTokenSale();
        await tokenSaleContract.BuyToken();
    }
}