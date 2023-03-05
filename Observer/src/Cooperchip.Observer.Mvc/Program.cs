using Cooperchip.Observer.Domain.Repositories;
using Cooperchip.Observer.Domain.Services.Abstractions;
using Cooperchip.Observer.Domain.Services.Concretes;
using Cooperchip.Observer.Infra.Data;
using Cooperchip.Observer.Infra.Repository;
using Cooperchip.Observer.Mvc.Configurations.Environments;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Cooperchip.Observer.Mvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region: Services and Config Environment
            var builder = WebApplication.CreateBuilder(args);
            ConfigurationManager configuration = builder.Configuration;

            ConfigEnvironment.Config(builder);

            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IPedidoService, PedidoService>();
            builder.Services.AddScoped<IMensagemRepository, MensagemRepository>();
            builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
            builder.Services.AddScoped<IObserverRepository, ObserverRepository>();
            #endregion

            #region: Pipiline
            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            #endregion

            app.Run();
        }
    }

}