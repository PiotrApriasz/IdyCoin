using Nethereum.Web3;

namespace iDyCoin.Metamask.Ethereum;

public interface IEthereumHostProvider
{
    public string Name { get; }
    public bool Available { get; }
    public string SelectedAccount { get; }
    public int SelectedNetwork { get; }
    public bool Enabled { get; }

    event Func<string, Task> SelectedAccountChanged;
    event Func<bool, Task> AvailabilityChanged;
    
    Task<bool> CheckProviderAvailabilityAsync();
    Task<Web3> GetWeb3Async();
    Task<string> EnableProviderAsync();
    Task<string> GetProviderSelectedAccountAsync();
    Task<int> GetProviderSelectedNetworkAsync();
    Task<string> SignMessageAsync(string message);
}