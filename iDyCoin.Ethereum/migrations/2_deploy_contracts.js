var IDyToken = artifacts.require("iDyToken.sol");

module.exports = async function(deployer) {
    await deployer.deploy(IDyToken, 1000000);
}