var IDyToken = artifacts.require("iDyToken.sol");
var IDyTokenSale = artifacts.require("IDyTokenSale");

module.exports = async function(deployer) {
    let addr = await web3.eth.getAccounts();
    await deployer.deploy(IDyToken, 1000000 );
    await deployer.deploy(IDyTokenSale, 1, addr[0], IDyToken.address);
    let instance = await IDyToken.deployed();
    await instance.transfer(IDyTokenSale.address, 1000000);
}