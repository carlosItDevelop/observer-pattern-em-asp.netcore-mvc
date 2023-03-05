using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Cooperchip.Observer.Mvc.Configurations.Environments
{
    public static class ConfigEnvironment
    {
        public static void Config(WebApplicationBuilder builder)
        {
            var assembly = AppDomain.CurrentDomain.GetAssemblies().Single(x => x.EntryPoint != null);

            var configEnv = new ConfigurationBuilder()
                .AddUserSecrets(assembly, optional: true, reloadOnChange: true)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            Console.WriteLine("");
            Console.WriteLine($"Variável de Execução: {builder.Environment.EnvironmentName}");
            Console.WriteLine("");

        }

    }
}