using System;
using System.IO;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Synigo.DemoApi.Model;
using Synigo.OneApi.Clients;
using Synigo.OneApi.Clients.Notifications;

[assembly: FunctionsStartup(typeof(Synigo.DemoApi.Startup))]
namespace Synigo.DemoApi
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var adSettings = new AzureAdSettings();
            var synigoSettings = new SynigoSettings();

            builder.GetContext().Configuration.Bind("synigo", synigoSettings);
            builder.GetContext().Configuration.Bind("azureAd", adSettings);

            builder.Services.AddSingleton<TokenProvider>((factory) => {
                return new TokenProvider(adSettings, synigoSettings);
            });

            builder.Services.AddSingleton<INotificationsClient>((factory) => {
                builder.GetContext().Configuration.Bind("synigo", synigoSettings);
                builder.GetContext().Configuration.Bind("azureAd",adSettings);

                return new NotificationsClient(adSettings.ClientId, adSettings.ClientSecret, adSettings.TenantId, synigoSettings.SynigoApiUrl);
            });
        }

        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        {
            var context = builder.GetContext();
            builder.ConfigurationBuilder.AddJsonFile(Path.Combine(context.ApplicationRootPath, "appsettings.json"), optional: true, reloadOnChange: false);            
        }
    }
}