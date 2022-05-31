using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Cs45.common.middlewares
{
    public class ValidateMiddleware
    {
        private readonly RequestDelegate _next;
        public ValidateMiddleware(RequestDelegate next) => _next = next;
        public async Task InvokeAsync(HttpContext context)
        {
            string dataOfMinh = (string)context.Items["dataOfMinh"];
            Console.WriteLine(dataOfMinh);
            await context.Response.WriteAsync("Xin Chao Minh");
            //await _next(context);
        }
    }
}
