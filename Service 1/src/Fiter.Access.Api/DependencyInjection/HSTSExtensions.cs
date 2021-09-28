using System;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Api.DependencyInjection
{
    public static class HstsExtensions
  {
        public static IServiceCollection AddHSTS(this IServiceCollection services, int port, TimeSpan maxAge)
        {
          services.AddHsts(options =>
          {
            options.Preload = true;
            options.IncludeSubDomains = true;
            options.MaxAge = maxAge;
            //options.ExcludedHosts.Add("example.com");
            //options.ExcludedHosts.Add("www.example.com");
          });

          services.AddHttpsRedirection(options =>
          {
            options.RedirectStatusCode = (int)HttpStatusCode.TemporaryRedirect;
            options.HttpsPort = port;
          });

          return services;
        }

    }
}
