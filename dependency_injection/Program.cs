using System;
using Microsoft.Extensions.DependencyInjection;
using Minh.DependencyInjection.InveredtDependency;

namespace Minh.DependencyInjection.DirectDependency
{
    class Program
    {
        public static void Main(string[] args)
        {
            // singletonTest();
            // transientTest();
            // scopedTest();
            var services = new ServiceCollection();
            services.AddSingleton<IClassC, ClassC>();
            services.AddSingleton<IClassB, ClassB>();
            services.AddSingleton<ClassA, ClassA>();
            services.AddSingleton<ClassD>((provider) => { return new ClassD(provider.GetService<ClassA>(), ""); });
            var provider_1 = services.BuildServiceProvider();
            ClassA classA_1 = provider_1.GetService<ClassA>();
            ClassD classD_1 = provider_1.GetService<ClassD>();
            classA_1.Action();
        }

        #region scoped
        public static void scopedTest()
        {
            var services = new ServiceCollection();
            services.AddScoped<IClassC, ClassC>();
            var provider = services.BuildServiceProvider();
            var classC = provider.GetService<IClassC>();
            for (int i = 0; i < 5; i++)
            {
                IClassC c = provider.GetService<IClassC>();
                Console.WriteLine(c.GetHashCode()); // Giống hệt nhau vì đang cùng một scoped
            }

            // Create new scope
            using (IServiceScope newScope = provider.CreateScope())
            {
                IServiceProvider newProvider = newScope.ServiceProvider;
                for (int i = 0; i < 5; i++)
                {
                    IClassC c = newProvider.GetService<IClassC>();
                    Console.WriteLine(c.GetHashCode()); // Những cái trong vòng for này sẽ giống nhau nhưng khắc vòng for ở trên
                }
            }

        }
        #endregion

        #region transient
        public static void transientTest()
        {
            var services = new ServiceCollection();
            services.AddTransient<IClassC, ClassC>();
            var provider = services.BuildServiceProvider();
            var classC = provider.GetService<IClassC>();
            for (int i = 0; i < 5; i++)
            {
                IClassC c = provider.GetService<IClassC>(); // Tất cả các Add thì chỉ khi gọi GetService thì constructor mới dc gọi
                Console.WriteLine(c.GetHashCode()); // Mỗi lần gọi GetService sẽ tạo một cái mới
            }
        }
        #endregion

        #region singleton
        public static void singletonTest()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IClassC, ClassC>();
            var provider = services.BuildServiceProvider();
            var classC = provider.GetService<IClassC>();
            for (int i = 0; i < 5; i++)
            {
                IClassC c = provider.GetService<IClassC>();
                Console.WriteLine(c.GetHashCode()); // Mã hash giống hệt nhau vì nó lấy từ một cái duy nhất
            }
        }
        #endregion
    }
}