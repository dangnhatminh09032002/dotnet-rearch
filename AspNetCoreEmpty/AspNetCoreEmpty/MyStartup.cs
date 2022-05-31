using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Text;

namespace AspNetCoreEmpty
{
    public class MyStartup
    {
        public void ConfigureServics(IServiceCollection services)
        {
            // Add services.AddScope
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            // cho phép truy cập các file trong wwwroot
            // đặt ở vị trí khác sẽ có kết quả khác
            app.UseStaticFiles();

            // StatusCodePages
            app.UseStatusCodePages(); // Sẻ vào đây nếu không có middleware nào khớp bên dưới, có thể đặt ở bắt kỳ đâu
            // EndpointRoutingMiddleware
            app.UseRouting();

            /*
             Sử dụng endpoint sẽ chính xác hơn dùng app.Run
             ví dụ get: /home/asdff/1321asf
             thì app.Map thường (Không ở trong endpoint) sẽ vào hết còn endpoint chỉ dúng /home mới vào
             */
            app.UseEndpoints((IEndpointRouteBuilder endpointRouteBuilder) =>
            {
                endpointRouteBuilder.MapGet("/home", async (HttpContext context) =>
                {
                    context.Response.StatusCode = 200;
                    context.Response.WriteAsync("Home page");
                });

                endpointRouteBuilder.MapGet("/about", async (HttpContext context) =>
                {
                    context.Response.StatusCode = 200;
                    context.Response.WriteAsync("About page");
                });

                endpointRouteBuilder.MapGet("/contact", async (HttpContext context) =>
                {
                    context.Response.StatusCode = 200;
                    context.Response.WriteAsync("Contact page");
                });

                //endpointRouteBuilder.Map("/", async (HttpContext context) => { context.Response.Redirect("/home"); });
            });

            //app.Map("", (IApplicationBuilder appBuilder) =>
            //{
            //    appBuilder.Run(async (HttpContext context) =>
            //    {
            //        context.Response.Redirect("/home");
            //    });
            //});

            //// Terminate Middleware
            ///*
            //    Nó sẽ chạy từ trên xuống bất kể trường hợp gì (k nhảy theo endpoint)
            // */
            //app.Map("/minh", (IApplicationBuilder appBuilder) => {
            //    appBuilder.Run(async (HttpContext context) =>
            //    {
            //        await context.Response.WriteAsync("<h1>Minh Page</h1>");
            //        Console.WriteLine("Matching Minh Page");
            //    });
            //});

            //app.UseEndpoints((IEndpointRouteBuilder endpointRouteBuilder) => {
            //    endpointRouteBuilder.Map("/minh", async (HttpContext context) =>
            //    {
            //        await context.Response.WriteAsync("<h1>NhatMinh Page</h1>");
            //        Console.WriteLine("Matching Minh Page");
            //    });
            //});

            // Terminate Middleware
            // Map voi all
            //app.Run(async (HttpContext context) =>
            //{
            //    context.Response.Redirect("xxxx");
            //});
        }
    }
}
