using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TeamManagerWeb.Repository.Services;

namespace TeamManagerWebApp.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services.AddScoped(http => new HttpClient
            {
                BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
            });

            builder.Services.AddScoped<ClientLanguageService>();

            await builder.Build().RunAsync();
        }
    }
}
