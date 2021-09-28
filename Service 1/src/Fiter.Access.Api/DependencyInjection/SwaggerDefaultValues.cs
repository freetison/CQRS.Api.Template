using System.Linq;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Api.DependencyInjection
{
  public class SwaggerDefaultValues : IOperationFilter
    {

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
			if (operation.Parameters == null) { return; }

            foreach (var parameter in operation.Parameters)
            {
                var description = context.ApiDescription.ParameterDescriptions.First(p => p.Name == parameter.Name);
                var routeInfo = description.RouteInfo;

                if (string.IsNullOrEmpty(parameter.Name)) { parameter.Name = description.ModelMetadata?.Name; }

                if (parameter.Description == null) { parameter.Description = description.ModelMetadata?.Description; }

                if (routeInfo == null) { continue; }

                parameter.Required |= !routeInfo.IsOptional;
            }

            // Overwrite description for shared response code
            operation.Responses["400"].Description = "Invalid query parameter(s). Read the response description";
            operation.Responses["401"].Description = "Authorization has been denied for this request";
		}
    }
}
