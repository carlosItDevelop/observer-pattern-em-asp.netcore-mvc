using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Cooperchip.Observer.Mvc.Configurations.Environments
{
    public class ConfigEnvironment
    {
        public IConfiguration Configuration { get; }

        public ConfigEnvironment(IWebHostEnvironment env)
        {
            var builer = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            if (env.IsProduction() || env.IsStaging() || env.IsDevelopment())
            {
                builer.AddUserSecrets<ConfigEnvironment>();
            }
            Configuration = builer.Build();
        }
    }
}
