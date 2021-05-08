using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
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

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/api/teapot"))
            {
                await _next(context);
                return;
            }

            // Read the API keys from appsettings.json.
            var ApiKeys = context.RequestServices.GetRequiredService<IConfiguration>().GetSection("ApiKeys").GetChildren().ToDictionary(c => c.Key, c => c.Value);

            // If either of the API keys can't be read from appsettings.json return with the status code 500 (Internal Server Error).
            if (ApiKeys.Count == 0
                || !ApiKeys.TryGetValue("Visitor", out string apiKeyVisitor)
                || !ApiKeys.TryGetValue("Admin", out string apiKeyAdmin))
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("(500 - Internal Server Error)" +
                    "\nSo the bad news is that the server might be on fire." +
                    "\nThe good news? I guess you could try again later!");
                return;
            }

            // Read the apikey from the header and if it doesn't exist exit with the status code 401 (unauthorized).
            //if (context.Request.Headers.TryGetValue("apikey", out headerApiKey) && headerApiKey == "secret1234")
            var header = context.Request.Headers;
            if (!context.Request.Headers.TryGetValue("apikey", out StringValues headerApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("(401 - Unauthorized)\nAn API key is required.");
                return;
            }

            // Authenticate the api key we read from the header, and if the header key is valid call the request delegate "_next" and return.
            if (headerApiKey == apiKeyVisitor)
            {
                if ((context.Request.Path.StartsWithSegments("/api/spaceports") && context.Request.Method == "GET")
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

            // The apikey from the header wasn't valid, exit with 401 (Unauthorized).
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("(401 - Unauthorized)\nBad API key.");
            return;
        }
    }
}