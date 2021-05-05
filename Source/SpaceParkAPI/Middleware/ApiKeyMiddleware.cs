using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceParkAPI.Middleware
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;

        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        //public async Task InvokeAsync(HttpContext context, IConfiguration configuration)
        public async Task InvokeAsync(HttpContext context)
        {
            var ApiKeys = context.RequestServices.GetRequiredService<IConfiguration>().GetSection("ApiKeys").GetChildren().ToDictionary(c => c.Key, c => c.Value);
            string apiKeyVisitor;
            string apiKeyAdmin;
            StringValues headerApiKey;


            if (ApiKeys.Count == 0
                || !ApiKeys.TryGetValue("Visitor", out apiKeyVisitor)
                || !ApiKeys.TryGetValue("Admin", out apiKeyAdmin))
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("(500 - Internal Server Error)" +
                    "\nSo the bad news is that the server might be on fire." +
                    "\nThe good news? I guess you could try again later!");
                return;
            }

            //if (context.Request.Headers.TryGetValue("apikey", out headerApiKey) && headerApiKey == "secret1234")
            if (!context.Request.Headers.TryGetValue("apikey", out headerApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("(401 - Unauthorized)\nAn API key is required.");
                return;
            }

            if (headerApiKey == apiKeyVisitor)
            {
                if (context.Request.Path.StartsWithSegments("/api/spaceports") && context.Request.Method == "GET"
                    || context.Request.Path.StartsWithSegments("/api/parkings")
                    || context.Request.Path.StartsWithSegments("/api/people")
                    || context.Request.Path.StartsWithSegments("/api/starships"))
                {
                    await _next(context);
                    return;
                }
            }
            else if (headerApiKey == apiKeyAdmin)
            {
                // No need to check anything, an admin has access to all methods on all endpoints.
                await _next(context);
                return;
            }

            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("(401 - Unauthorized)\nBad API key.");
            return;
        }
    }

    public static class ApiKeyMiddlewareExtension
    {
        //public static IApplicationBuilder UseApiKeyMiddleware(this IApplicationBuilder builder, IConfiguration configuration)
        public static IApplicationBuilder UseApiKeyMiddleware(this IApplicationBuilder builder)
        {
            //return builder.UseMiddleware<ApiKeyMiddleware>(configuration);
            return builder.UseMiddleware<ApiKeyMiddleware>();
        }
    }
}