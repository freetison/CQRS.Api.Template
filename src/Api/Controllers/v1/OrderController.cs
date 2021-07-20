using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using $safeprojectname$.Models;
using Application.UseCases.CreateOrder;
using Application.UseCases.GetOrder;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace $safeprojectname$.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        OrderController(IMediator mediator, IMapper mapper)
        {
          _mediator = mediator;
          _mapper = mapper;
        }

        [HttpGet, Route("{id}"), Produces("application/json")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetOrder(string id)
        {
          var query = new GetOrderQuery(o=> o.OrderId == id);
          var queryResponse = await _mediator.Send(query);
          return new ApiResult<IEnumerable<GetOrderResponse>>(queryResponse);

        }

        [HttpPost, Route("create/qr"), Produces("application/json")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> CreateOrder ([FromBody] CreateOrderCommand request)
        {
            var cmdResult = await _mediator.Send(request);
            await _mediator.Publish(cmdResult);

          return new ApiResult<CreateOrderResponse>(cmdResult);
        }


  }
}


