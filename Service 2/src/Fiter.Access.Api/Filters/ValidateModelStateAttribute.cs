using System.Collections.Generic;
using System.Linq;
using Api.Models;
using Domain.Model.Validations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filters
{
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        private IDictionary<string, string[]> Failures { get; }
        public List<ValidationError> Errors { get; set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                Errors = context.ModelState.Keys
                    .SelectMany(key => context.ModelState[key].Errors.Select(x => new ValidationError(key, x.ErrorMessage)))
                    .ToList();

                //return new ApiResult<DragonflyResponse>(pushDragonFlyTransactionCommandResponse);
                var apiResult = new ApiResult<List<ValidationError>>();
                context.Result = new BadRequestObjectResult(apiResult);

                // Notificar el error a la queue
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            // our code after action executes
        }
    }
}
