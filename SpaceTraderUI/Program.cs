using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SpaceTraderUI;
using MudBlazor.Services;
using SpaceTraderUI.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(SpaceTraderAPI.BaseURL) });
builder.Services.AddMudServices();

builder.Services.AddSingleton<AccountService>();
builder.Services.AddSingleton<FactionService>();

await builder.Build().RunAsync();
