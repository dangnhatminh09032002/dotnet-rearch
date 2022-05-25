using System;
using Microsoft.Extensions.DependencyInjection;
using Minh.DependencyInjection.Interfaces;
using Minh.DependencyInjection.Services;
namespace Minh.DependencyInjection
{
    class Program
    {
        public static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();
            services.AddScoped<IMyService, MyService>();
            services.Configure<MyServiceOptions>((MyServiceOptions options) =>
            {
                options.data_1 = "Hello World";
                options.data_2 = "HIi";
            });
            ServiceProvider mainProvider = services.BuildServiceProvider();
            IMyService myService = mainProvider.GetService<IMyService>();
        }
    }
}