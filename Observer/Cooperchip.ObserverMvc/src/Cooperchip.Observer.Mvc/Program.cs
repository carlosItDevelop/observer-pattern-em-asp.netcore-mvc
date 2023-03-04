using Cooperchip.Observer.Mvc.Configurations.Environments;
using Cooperchip.Observer.Mvc.Infra.Data;
using Cooperchip.Observer.Mvc.Infra.Repository;
using Cooperchip.Observer.Mvc.Services.Abstractions;
using Cooperchip.Observer.Mvc.Services.Concretes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Reflection;

namespace Cooperchip.Observer.Mvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var assembly = AppDomain.CurrentDomain.GetAssemblies()
                .Single(x => x.EntryPoint != null);

            var configEnv = new ConfigurationBuilder()
            .AddUserSecrets(assembly, optional: true, reloadOnChange: true)
                .AddJsonFile("appsettings.json", true, true);
                //.AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true)
                //.AddEnvironmentVariables();


            ConfigurationManager configuration = builder.Configuration;





            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // For Entity Framework
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IPedidoService, PedidoService>();
            builder.Services.AddScoped<IMensagemRepository, MensagemRepository>();
            builder.Services.AddScoped<IObserverRepository, ObserverRepository>();
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }

}