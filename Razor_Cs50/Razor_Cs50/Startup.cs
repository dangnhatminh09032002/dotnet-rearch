using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razor_Cs50
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddRazorPages();

            services.AddRazorPages().AddRazorPagesOptions((RazorPagesOptions options) => //AddRazorPagesOptions dùng để cấu hình lại
            {
                //options.RootDirectory = "/MyPages"; // Vị trí lưu page (mặc định là /Pages)
                //options.Conventions.AddPageRoute("/Index", "/abc"); // Nếu nhập /abc thì nó sẽ vào Index.html, nhâp index nó vẫn vao index
            });

            services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
                // tự động chuyển thành chữ thường
                //ví dụ khi dùng taghelper asp-page thì nó sẽ để nguyên như thư mục -> thư mục có thể chữ hoa nên khi dùng options.LowercaseUrls thì xem lại trên google dev thì nó đã được đổi thành lower
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages(); // Nó sẽ tìm file cshtml trong Pages (đây là folder mặc định)
                endpoints.MapGet("/", async context =>
                {
                    context.Response.Redirect("/index");
                });
            });
        }
    }
}
