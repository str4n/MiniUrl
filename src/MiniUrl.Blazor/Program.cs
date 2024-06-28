using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MiniUrl.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var options = builder.Configuration.BindOptions<BlazorOptions>("Blazor");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(options.BaseAddress) });

await builder.Build().RunAsync();
