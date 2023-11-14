using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace APIGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddOcelot();

            builder.Host.ConfigureAppConfiguration((ctx, config) =>
            {
                config.AddJsonFile("ocelot.json");
            });
            //builder.Host.ConfigureHostConfiguration(config =>
            //{
            //    // Configure the host configuration here
            //    config.AddJsonFile("ocelot.json");
            //});
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseOcelot();
            app.MapRazorPages();

            app.Run();
        }
    }
}