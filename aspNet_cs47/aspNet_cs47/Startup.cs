using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using aspNet_cs47.options;
using Microsoft.Extensions.Options;
using aspNet_cs47.common.middleware;

namespace aspNet_cs47
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration) { _configuration = configuration; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ValidateMiddleware, ValidateMiddleware>();
            var userOp = _configuration.GetSection("User");
            services.Configure<UserOption>(userOp);
            // IOptions<UserOption>

            //services.AddOptions();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseMiddleware<ValidateMiddleware>();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });

                endpoints.Map("/user-in-configuration", async context =>
                {
                    IConfiguration configuration = context.RequestServices.GetService<IConfiguration>();

                    // Cách 1: Tự gọi Select
                    //UserOption user = configuration.GetSection("User").Get<UserOption>();
                    // Cách 2: Để dung được cách này ta cần phải Inject nó vào 
                    // Không có services.AddOptions(); vẫn dùng được
                    IOptions<UserOption> userOption = context.RequestServices.GetService<IOptions<UserOption>>();
                    UserOption user = userOption.Value;
                    context.Response.ContentType = "application/json";
                    string json = JsonConvert.SerializeObject(user);
                    context.Response.WriteAsync(json);
                });
            });
        }
    }
}
