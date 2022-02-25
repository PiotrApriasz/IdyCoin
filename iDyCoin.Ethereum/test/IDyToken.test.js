const Token = artifacts.require("IDyToken");

const chai = require("./setupchai.js");
const BN = web3.utils.BN;
const expect = chai.expect;

require("dotenv").config({path: "../.env"});

contract("Token Test", async (accounts) => {

    const [deployerAccount, recipient, anotherAccount] = accounts;

    beforeEach(async () => {
        this.iDyToken = await Token.new(process.env.INITIAL_TOKENS);
    })

    it("all tokens should be in my account", async () => {
        let instance = this.iDyToken;
        let totalSupply = await instance.totalSupply();
        return expect(instance.balanceOf(accounts[0])).to.eventually.be.a.bignumber.equal(totalSupply);
    })

    it("is possible to send tokens between accounts", async () => {
        const tokensAmount = 1;
        let instance = this.iDyToken;
        let totalSupply = await instance.totalSupply();
        expect(instance.balanceOf(deployerAccount)).to.eventually.be.a.bignumber.equal(totalSupply);
        expect(instance.transfer(recipient, tokensAmount)).to.eventually.be.fulfilled;
        expect(instance.balanceOf(deployerAccount)).to.eventually.be.a.bignumber.equal(totalSupply.sub(new BN(tokensAmount)));
        return expect(instance.balanceOf(recipient)).to.eventually.be.a.bignumber.equal(new BN(tokensAmount));
    })

    it("is not possible to send more tokens than available in total", async () => {
        let instance = this.iDyToken;
        let balanceOfDeployer = await instance.balanceOf(deployerAccount);
        expect(instance.transfer(recipient, new BN(balanceOfDeployer + 1))).to.eventually.be.fulfilled;
        return expect(instance.balanceOf(deployerAccount)).to.eventually.be.a.bignumber.equal(balanceOfDeployer);
    })
    
});