using iDyCoin.ContractIntegration.Contracts;
using iDyCoin.ContractIntegration.Utils;
using Xunit;

namespace iDyCoin.Tests.ContractIntegrationTests;

public class ContractToolsTests
{
    [Fact]
    public void GetContractAddress_ValidPath_ReturnsDploymentAddress()
    {
        var address = ContractTools.GetContracAddress<IDyToken>("5777");
        Assert.Equal("0x88Ee2A6A5692a486D8a3775365F03fb0Fa990712", address);
    }
}