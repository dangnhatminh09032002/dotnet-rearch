using Microsoft.AspNetCore.Builder;

namespace Cs45.common.middlewares
{
    public static class ValidateMiddlewareExtensionMethod
    {
        public static void ValidateMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ValidateMiddleware>();
        }
    }
}