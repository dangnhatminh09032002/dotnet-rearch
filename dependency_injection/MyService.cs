using Minh.DependencyInjection.Interfaces;
namespace Minh.DependencyInjection.Services
{
    public class MyService : IMyService
    {
        public MyService()
        {
        }
    }

    public class MyServiceOptions : IMyServiceOptions
    {
        public string str;
        public int count;

    }
}