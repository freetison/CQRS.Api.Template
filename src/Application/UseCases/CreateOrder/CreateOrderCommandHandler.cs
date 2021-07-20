using System.Threading;
using System.Threading.Tasks;
using $safeprojectname$.UseCases.GetOrder;
using AutoMapper;

using Domain.Entities.Tables;
using Domain.Enumeration;
using Domain.Services;
using MediatR;

namespace $safeprojectname$.UseCases.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;

        public CreateOrderCommandHandler(IMapper mapper, IOrderService orderService)
        {
            _mapper = mapper;
            _orderService = orderService;
        }


        public async Task<CreateOrderResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<CreateOrderRequest, Orders>(request.CreateOrderRequest);
            var result = await _orderService.CreateOrder(order);

            return new CreateOrderResponse(request.CreateOrderRequest.Id, OrderStatus.IN_PROGRESS.Name);
        }
    }


}

