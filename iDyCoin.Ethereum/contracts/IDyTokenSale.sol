// SPDX-License-Identifier: UNLICENSED

pragma solidity >=0.8.0;

import "./Crowdsale.sol";
import "./KycContract.sol";

contract IDyTokenSale is Crowdsale { 

    KycContract kyc;

    constructor(
        uint256 rate,
        address payable wallet,
        IERC20 token,
        KycContract _kyc
    ) Crowdsale(rate, wallet, token) {
        kyc = _kyc;
    }

    function _preValidatePurchase(address beneficiary, uint256 weiAmount) internal view override {
        super._preValidatePurchase(beneficiary, weiAmount);
        require(kyc.kycCompleted(msg.sender), "KYC Not completed, purchase not allowed");
    }
}