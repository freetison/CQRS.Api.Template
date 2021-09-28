using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities.Tables;
using Domain.Services;
using MediatR;

namespace Application.UseCases.GetOrder
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, IEnumerable<GetOrderResponse>>
    {
        private readonly IOrderService _orderService;

        public GetOrderQueryHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IEnumerable<GetOrderResponse>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Orders> orders = await _orderService.GetOrderBy(request.Predicate);
            return orders.Select(o => new GetOrderResponse
            {
                Id = o.Id,
                ProductId = o.Product.ProductId,
                ProductName = o.Product.ProductName,
                Quantity = o.Quantity,
                Status = o.Status.Name
            });
        }

    }
}