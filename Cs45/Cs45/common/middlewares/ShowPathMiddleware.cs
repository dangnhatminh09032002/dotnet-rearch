using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace Cs45.common.middlewares
{
    public class ShowPathMiddleware : IMiddleware // Để dùng được định dạng này ta phải add nó vào service (addSingleton, addScopde, ...)
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if(context.Request.Path.ToString().Contains("minh"))
            {
                Console.WriteLine("Chao Minh");
                context.Items.Add("dataOfMinh", "age=12,add=kyanh");
                next(context);
                return;
            } else
            {
                Console.WriteLine("You are not Minh ....");
                await context.Response.WriteAsync("You are not Minh ....");
            }
        }
    }
}
