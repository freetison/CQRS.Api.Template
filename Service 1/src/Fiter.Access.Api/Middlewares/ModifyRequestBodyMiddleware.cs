

// ReSharper disable IdentifierTypo


using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Api.Middlewares
{
    public class ModifyRequestBodyMiddleware
    {
        private readonly RequestDelegate _next;

        public ModifyRequestBodyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            var context = httpContext;
            var request = context.Request;
           
            request.EnableBuffering();
            string requestBodyContent = await new StreamReader(request.Body, Encoding.UTF8).ReadToEndAsync().ConfigureAwait(false);

            var newBodyContent = requestBodyContent.Replace("utf-16", "utf-8");

            request.ContentType = "application/xml; charset=utf-8";
            request.Body = new MemoryStream(Encoding.UTF8.GetBytes(newBodyContent));

            await _next.Invoke(context).ConfigureAwait(false);
        }
    }
}
