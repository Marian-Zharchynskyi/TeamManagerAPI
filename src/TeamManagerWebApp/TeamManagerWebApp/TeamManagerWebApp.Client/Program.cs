using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using TeamManagerWeb.Core.Context;
using TeamManagerWeb.Core.Entities;
using TeamManagerWeb.Repository.Common;
using TeamManagerWeb.Repository.Services;

namespace TeamManagerWebApp.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            /*builder.RootComponents.Add<App>("#app");*/
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            // ������������ Entity Framework Core
            builder.Services.AddDbContext<ProjectContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // ��������� ����������
            builder.Services.AddScoped<IRepository<Language, Guid>, Repository<Language, Guid>>();

            await builder.Build().RunAsync();
        }
    }
}
