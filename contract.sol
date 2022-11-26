// SPDX-License-Identifier: MIT
pragma solidity ^0.8.9;

import "@openzeppelin/contracts@4.8.0/token/ERC1155/ERC1155.sol";
import "@openzeppelin/contracts@4.8.0/access/Ownable.sol";
import "@openzeppelin/contracts/utils/Strings.sol";

contract MyToken is ERC1155, Ownable {
    // we will fix the id of each token  for nft0 -> id =0 , ....
    // suplies containt the Number of each NFT 
    uint256[] supplies =[5,6,7,8,3]; 
    // how much is the NFT minted 
    uint256[] minted=[0,0,0,0,0];
    // keys
    
    uint256 minRate=0.01 ether;
    struct NFT { 
            uint256 supplie;
            uint256 minted;
    }
    mapping(uint256 => mapping(address => uint256)) private _NftTimeClaim;
    NFT[] NFTS;
    NFT x;
    uint N=supplies.length;
    string ipfsUri;
    function createNft() public {
        for (uint j=0; j<N; j++){
            x=NFT(supplies[j],0);
            NFTS.push(x);
        }
    }
    uint256 dateInSecs;
    uint256 DateSale;
    uint256 DurationOfHavingTheNft;



    constructor(string memory Uri)
        ERC1155("")
    {
        createNft();
        ipfsUri=Uri;
    }
    function setURI(string memory newuri) public onlyOwner {
        ipfsUri=newuri;
    }
    function uri(uint256 token_ID) public view override returns (string memory ){
        return string(abi.encodePacked(ipfsUri,Strings.toString(token_ID), ".json") ); 
    }
    function mint(uint256 id,bytes memory data)
        public
    {
        //those functions are just for security
        require(id<=supplies.length,"Token dosent exist !");

        require(id >= 0 , "Token dosent exist");

        // we should not depasse the limite number of our NFT !
        require(NFTS[id].minted+1 <= NFTS[id].supplie,"SORRY THIS NFT IS LIMITED !");

        // User can ONLY have one NFT !
        // the function balanceof return how much the user have this NFT ! 
        require(balanceOf(msg.sender,id)==0,"You can have only one copy of this NFT ! ");
        
        // the 1 refere the amount ( as we said user can have only one nft ) 
        _mint(msg.sender, id, 1, data);

        NFTS[id].minted++;
        // save The time when when the user has claimed the NFT HE WILL pay tax when he sold it ! 
        dateInSecs = block.timestamp;
        _NftTimeClaim[id][msg.sender]=dateInSecs;
    }
    /**
    function Time(address add,uint256 id) public {
                    DateSale=block.timestamp;
                    DurationOfHavingTheNft=DateSale-_NftTimeClaim[id][add];
    }
    function SeeTime() public view virtual  returns (uint256) {
        return DurationOfHavingTheNft ;
    } 
    **/  
     //Transfer NFT with Money !
    
    function withdraw() public onlyOwner{
        require(address(this).balance>0,"Balance is 0");
        payable(owner()).transfer(address(this).balance);
    }

}
