using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Minh.DependencyInjection.Interfaces;
using Minh.DependencyInjection.Services;
namespace Minh.DependencyInjection
{
    class Program
    {
        public static void Main(string[] args)
        {
            ConfigurationRoot configurationRoot;
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddConfiguration();
            ServiceCollection services = new ServiceCollection();
            services.AddScoped<IMyService, MyService>();
            ServiceProvider mainProvider = services.BuildServiceProvider();
            IMyService myService = mainProvider.GetService<IMyService>();
        }
    }
}