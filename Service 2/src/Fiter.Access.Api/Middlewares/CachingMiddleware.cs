

// ReSharper disable StringLiteralTypo

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Api.Middlewares
{
    public class CachingMiddleware
    {
        private readonly RequestDelegate _next;
        public CachingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {

            //string[] keys = { "host", "app", "cat" };
            //var missingKeys =  keys.Except(httpContext.Request.Query.Keys).ToList();
            //if (missingKeys.Any()) { throw new DomainValidationException($"Missing keys: {string.Join(",", missingKeys) }"); }

            Console.WriteLine("---------------------------------------------- 2");
            await _next(httpContext);
        }

    }
}
