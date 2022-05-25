using Microsoft.Extensions.Options;
using Minh.DependencyInjection.Interfaces;

namespace Minh.DependencyInjection.Services
{
    public class MyService : IMyService
    {
        public MyService(IOptions<MyServiceOptions> myServiceOptions)
        {
            Console.WriteLine($"{myServiceOptions.Value.Name}");
        }

        public class MyServiceOptions
        {
            public string Name { get; set; }
        }
    }
}