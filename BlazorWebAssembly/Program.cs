using BlazorWebAssembly;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Configurar HttpClient para apuntar a la API
var apiBaseUrl = builder.Configuration["ApiBaseUrl"] ?? "http://localhost:5077";
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiBaseUrl) });

await builder.Build().RunAsync();


