using Cs45.common.middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cs45
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ShowPathMiddleware, ShowPathMiddleware>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            //app.UseMiddleware<ShowPathMiddleware>();

            ////app.UseMiddleware<ValidateMiddleware>();
            //app.ValidateMiddleware(); // Đây là extension method

            app.Map("/user", (app_1) => {
                app_1.UseRouting();
                app_1.UseEndpoints(endpoint =>
                {
                    endpoint.Map("/minh", async (context) => {
                        await context.Response.WriteAsync("<h1>User -> minh</h1>");
                    });
                });
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World");
            });

        }
    }
}
