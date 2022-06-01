using aspNet_cs47.options;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace aspNet_cs47.common.middleware
{
    public class ValidateMiddleware : IMiddleware
    {
        private UserOption _userOption { set; get; }
        public ValidateMiddleware(IOptions<UserOption> userOption)
        {
            _userOption = userOption.Value;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            string name = context.Request.Cookies["name"];
            Console.WriteLine(name);
            if (name == _userOption.Name)
            {
                await next(context);
                return;
            }
            //context.Response.Cookies.Append("name", "Dang Nhat Minh");
            context.Response.WriteAsync("You are unauthorized");
        }
    }
}
