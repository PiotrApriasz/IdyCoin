using iDyCoin.ContractIntegration.Contracts;
using Xunit;

namespace iDyCoin.Tests.ContractIntegrationTests;

public class KycContractTest
{
    [Fact]
    public async void SetKyc_ValidAddress_VerifyAddressCorrectly()
    {
        var kycContract = new KycContract();
        await kycContract.SetKycCompleted("0x496C22EAAD3AC714a047EA5F981aF7Bb1D7dFf15");
        var kycCompleted = await kycContract.KycCompleted("0x496C22EAAD3AC714a047EA5F981aF7Bb1D7dFf15");
        Assert.True(kycCompleted);
    }

    [Fact]
    public async void RevokeKyc_ValidAddress_RevokedAddressCorrectly()
    {
        var kycContract = new KycContract();
        await kycContract.SetKycRevoked("0x496C22EAAD3AC714a047EA5F981aF7Bb1D7dFf15");
        var kycCompleted = await kycContract.KycCompleted("0x496C22EAAD3AC714a047EA5F981aF7Bb1D7dFf15");
        Assert.False(kycCompleted);
    }
    
}