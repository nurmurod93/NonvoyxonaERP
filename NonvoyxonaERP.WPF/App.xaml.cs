using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace NonvoyxonaERP.WPF
{
    public partial class App : System.Windows.Application
    {
        public static IServiceProvider ServiceProvider { get; private set; } = null;

        protected override void OnStartup(StartupEventArgs e)
        {
            var services = new ServiceCollection();
            services.AddHttpClient("API", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7187/api/");
            });

            ServiceProvider = services.BuildServiceProvider();
                base.OnStartup(e);
        }
    }

}
