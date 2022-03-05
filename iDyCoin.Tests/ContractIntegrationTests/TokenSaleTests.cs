using System;
using iDyCoin.ContractIntegration.Contracts;
using iDyCoin.ContractIntegration.Utils;
using Xunit;

namespace iDyCoin.Tests.ContractIntegrationTests;

public class TokenSaleTests
{
    [Fact]
     public async void BuyToken_ValidPUrchase_NewTokenAddedToBeneficiaryAccount()
    {
        var tokenSaleContract = new IDyTokenSale();
        var tokenContract = new IDyToken();
        
        var tokenBalanceBefore = await tokenContract.BalanceOf("0x3Ca0f53C2958cdEF168BBE874d16640DA38a2416");
        var moneyBalanceBefore = await ContractTools.GetBalance("0x3Ca0f53C2958cdEF168BBE874d16640DA38a2416");
        
        await tokenSaleContract.BuyToken();
        
        var tokenBalanceAfter = await tokenContract.BalanceOf("0x3Ca0f53C2958cdEF168BBE874d16640DA38a2416");
        var moneyBalanceAfter = await ContractTools.GetBalance("0x3Ca0f53C2958cdEF168BBE874d16640DA38a2416");
        
        Assert.Equal(tokenBalanceAfter, tokenBalanceBefore + 1);
        //Assert.Equal(moneyBalanceAfter, moneyBalanceBefore + 1);
        
    }
}