using Microsoft.Extensions.Options;
using Minh.DependencyInjection.Interfaces;

namespace Minh.DependencyInjection.Services
{
    public class MyService : IMyService
    {
        public MyService(IOptions<MyServiceOptions> options)
        {
            var _options = options.Value;
            var data_1 = _options.data_1;
            var data_2 = _options.data_2;
            Console.WriteLine("data 1: " + data_1 + "\ndata 2: " + data_2);
        }
    }

    public class MyServiceOptions
    {
        public string data_1;
        public string data_2;

    }
}