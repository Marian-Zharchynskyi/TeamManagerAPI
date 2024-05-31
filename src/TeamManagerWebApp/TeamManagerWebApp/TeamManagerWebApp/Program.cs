using Microsoft.EntityFrameworkCore;
using TeamManagerWeb.Core.Context;
using TeamManagerWeb.Repository.Common;
using TeamManagerWebApp.Components;

namespace TeamManagerWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorComponents()
               .AddInteractiveServerComponents()
               .AddInteractiveWebAssemblyComponents();

            builder.Services.AddControllers();

            builder.Services.AddScoped(http => new HttpClient
            {
                BaseAddress = new Uri(builder.Configuration.GetSection("BaseUri").Value!),
            });

            builder.Services.AddDbContext<ProjectContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("ProjectConnection")));

            builder.Services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

            // Add services to the container.
           
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.MapControllers();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode()
                .AddInteractiveWebAssemblyRenderMode()
                .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

            app.Run();
        }
    }
}
