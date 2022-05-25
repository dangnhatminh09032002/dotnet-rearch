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
            ServiceProvider mainProvider = services.BuildServiceProvider();
            IMyService myService = mainProvider.GetService<IMyService>();
        }
    }
}