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
        Assert.Equal("0x6423f396a2d13FdBEc44CC76beD3F4f55f145aC4", address);
    }
}