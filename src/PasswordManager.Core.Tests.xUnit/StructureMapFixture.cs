using System;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using PasswordManager.Core.ConfigurationSettings;
using PasswordManager.Core.Registry;
using StructureMap;

namespace PasswordManager.Core.Tests.xUnit
{
    public class StructureMapFixture : IDisposable
    {
        public StructureMapFixture()
        {
            var builder = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .AddEnvironmentVariables();

            IServiceCollection services = new ServiceCollection().AddOptions();
            services.Configure<AppSettingsConfiguration>(builder.Build().GetSection("AppSettings"));

            Container = new Container(new PasswordManagerRegistry(services));
        }

        public void Dispose()
        {
        }

        public IContainer Container { get; private set; }
    }
}


/*
            // Save for structuremap build up later
            For<IEnumerable<IConfigureOptions<AppSettingsConfiguration>>>().Use(new List<IConfigureOptions<AppSettingsConfiguration>>()
            {
                new ConfigureFromConfigurationOptions<AppSettingsConfiguration>(settings)
            });
            For<IOptions<AppSettingsConfiguration>>().Use(ctx => new OptionsManager<AppSettingsConfiguration>(ctx.GetInstance<IEnumerable<IConfigureOptions<AppSettingsConfiguration>>>()));

                IConfiguration settings = configuration?.GetSection("AppSettings");
            var settingsInstance = new AppSettingsConfiguration();

            //(new ConfigureFromConfigurationOptions<AppSettingsConfiguration>(settings)).Configure(settingsInstance);

*/
