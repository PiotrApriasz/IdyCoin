// SPDX-License-Identifier: UNLICENSED

pragma solidity >=0.8.0;

import "@openzeppelin/contracts/token/ERC20/ERC20.sol";
import "@openzeppelin/contracts/token/ERC20/ERC20Detailed.sol";

contract IDyToken is ERC20, ERC20Detailed {
    constructor(uint256 initialSupply) ERC20Detailed("iDy Identification Service Token", "IDY", 0) {
        _mint(msg.sender, initialSupply);
    }
}
