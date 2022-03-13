using FluentValidation;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using iDyCoin.Client.BlazorWasm;
using iDyCoin.Client.BlazorWasm.Components;
using iDyCoin.Client.BlazorWasm.Models;
using iDyCoin.Client.BlazorWasm.Validators;
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
builder.Services.AddValidatorsFromAssemblyContaining<KycWhitelisting>();
builder.Services.AddScoped<IValidator<KycWhitelistingModel>, KycWhiteListingValidator>();

await builder.Build().RunAsync();