using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Minh.DependencyInjection.Interfaces;
using Minh.DependencyInjection.Services;
using static Minh.DependencyInjection.Services.MyService;

namespace Minh.DependencyInjection
{
    class Program
    {
        public static void Main(string[] args)
        {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory()); // Cần có Microsoft.Extensions.Configuration.Json để dùng module này;
            configurationBuilder.AddJsonFile("appSettings.json");

            ConfigurationRoot configurationRoot = (ConfigurationRoot)configurationBuilder.Build();

            // string name = configurationRoot.GetSection("UserInfo:Name").Value.ToString(); // ~ configurationRoot.GetSection("UserInfo").GetSection("Name").Value.ToString();
            // Console.WriteLine(name); 


            ServiceCollection services = new ServiceCollection();
            services.AddScoped<IMyService, MyService>();
            services.Configure<MyServiceOptions>(configurationRoot.GetSection("UserInfo"));

            ServiceProvider mainProvider = services.BuildServiceProvider();

            IMyService myService = mainProvider.GetService<IMyService>();
        }
    }
}