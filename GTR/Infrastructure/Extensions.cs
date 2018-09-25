using Microsoft.AspNetCore.Builder;

namespace GTR.Infrastructure
{
    public static class Extensions
    {
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyMiddleware>();
        }
    }
}