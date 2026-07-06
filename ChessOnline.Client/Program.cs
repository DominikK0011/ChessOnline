using ChessOnline.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ChessOnline.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var baseAdress = builder.Configuration["ApiBaseAddress"] ?? "https://localhost:7152";

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAdress) });
builder.Services.AddScoped<SidebarService>();

await builder.Build().RunAsync();
