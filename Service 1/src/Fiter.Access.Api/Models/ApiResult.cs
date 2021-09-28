using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Api.Models
{
    public class ApiResult<T> : ActionResult
    {
        private readonly T detailsData;

        public ApiResult()
        {
        }

        public ApiResult(T detailsData) => this.detailsData = detailsData;

        public override async Task ExecuteResultAsync(ActionContext context)
        {
            DetailsResponse<T> resp = null;
            resp = detailsData == null ? DetailsResponse<T>.Failed() : DetailsResponse<T>.Ok(detailsData);

            var result = new JsonResult(resp);

            await result.ExecuteResultAsync(context);
        }
    }
}
