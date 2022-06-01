using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/*
    cài đặt package Microsoft.AspNetCore.Session and Microsoft.Extensions.Caching.Memory
 */


namespace aspnetcore_Cs48
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            // ngoài việc lưu ở cache ta có thể thể lưu ở database, redis, ...
            services.AddSession((SessionOptions options) =>
            {
                options.Cookie.Name = "sid";
                options.IdleTimeout = new TimeSpan(1, 0, 0); // 1h 0p 0s
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSession();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    //context.Session
                    await context.Response.WriteAsync("Hello World!");
                });

                endpoints.MapGet("/ ", async context =>
                {
                    int count = context.Session.GetInt32("count") ?? 0;
                    count += 1;
                    context.Session.SetInt32("count", count);
                    context.Response.WriteAsync("So lan truy cap la " + count);
                });
            });
        }
    }
}
