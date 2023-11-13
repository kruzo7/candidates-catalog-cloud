using CVGatorBeta.Commons.Validators;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using StaticWebApp.CVGatorBetaBlazorWasm;
using StaticWebApp.CVGatorBetaBlazorWasm.HttpClients;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMsalAuthentication(options =>
{
    options.ProviderOptions.LoginMode = "redirect";
    builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
});

builder.Services.AddCvGatorHttpClients(builder.Configuration, builder.HostEnvironment.IsDevelopment());
builder.Services.AddSingleton<FileContentExtensionValidator>();

var host = builder.Build();

await host.RunAsync();
