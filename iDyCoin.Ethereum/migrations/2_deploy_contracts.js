var IDyToken = artifacts.require("iDyToken.sol");
var IDyTokenSale = artifacts.require("IDyTokenSale");
require("dotenv").config({path: "../.env"});

module.exports = async function(deployer) {
    let addr = await web3.eth.getAccounts();
    await deployer.deploy(IDyToken, process.env.INITIAL_TOKENS );
    await deployer.deploy(IDyTokenSale, 1, addr[0], IDyToken.address);
    let instance = await IDyToken.deployed();
    await instance.transfer(IDyTokenSale.address, process.env.INITIAL_TOKENS);
}