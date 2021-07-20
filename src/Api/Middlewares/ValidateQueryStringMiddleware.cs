

// ReSharper disable StringLiteralTypo

using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Domain.Exceptions;
using Microsoft.AspNetCore.Http;

namespace $safeprojectname$.Middlewares
{
    public class ValidateQueryStringMiddleware
    {
        private readonly RequestDelegate _next;
        public ValidateQueryStringMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            string hostId = httpContext.Request.Query["hostId"].ToString();
            Regex regex = new Regex("^(?![0-9]{1,20}$)[a-zA-Z0-9-]{1,20}\\|([\\d]{1})\\|([\\d]{1})$");

            if (!regex.IsMatch(hostId)) { throw new DomainValidationException("Missing valid hostId"); }


            //string[] keys = { "host", "app", "cat" };
            //var missingKeys =  keys.Except(httpContext.Request.Query.Keys).ToList();
            //if (missingKeys.Any()) { throw new DomainValidationException($"Missing keys: {string.Join(",", missingKeys) }"); }

            Console.WriteLine("---------------------------------------------- 1");
            await _next(httpContext);
        }

    }
}
