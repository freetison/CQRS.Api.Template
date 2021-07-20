using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace $safeprojectname$.Middlewares
{
  public class ExternalTurnValidatorMiddleware
  {
    private readonly RequestDelegate _next;
    public ExternalTurnValidatorMiddleware(RequestDelegate next)
    {
      _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {


      //Console.WriteLine("---------------------------------------------- 1 -- IN");

      await _next(httpContext);

      //Console.WriteLine("---------------------------------------------- 1 -- OUT");
    }

  }
}
