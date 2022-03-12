using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using iDyCoin.Client.BlazorWasm;
using iDyCoin.Metamask.Blazor;
using iDyCoin.Metamask.Ethereum;
using iDyCoin.Metamask.Metamask;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<IMetamaskInterop, MetamaskBlazorInterop>();
builder.Services.AddSingleton<MetamaskInterceptor>();
builder.Services.AddSingleton<MetamaskHostProvider>();
builder.Services.AddSingleton<IEthereumHostProvider>(serviceProvider => serviceProvider
    .GetService<MetamaskHostProvider>() ?? throw new InvalidOperationException());
builder.Services.AddSingleton<NethereumAuthenticator>();

await builder.Build().RunAsync();