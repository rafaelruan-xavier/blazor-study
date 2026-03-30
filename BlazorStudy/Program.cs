using BlazorStudy.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BlazorStudy;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);

        builder.Services.AddTransient<ArtistAPI>();
        builder.Services.AddTransient<MusicAPI>();        
        builder.Services.AddHttpClient("API", hc =>
        {
            hc.BaseAddress = new Uri(builder.Configuration["APIServer"]);
            hc.DefaultRequestHeaders.Add("Accept", "application/json");
        });

        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

        await builder.Build().RunAsync();
    }
}
