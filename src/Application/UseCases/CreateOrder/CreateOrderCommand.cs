using MediatR;

namespace $safeprojectname$.UseCases.CreateOrder
{
    public class CreateOrderCommand : IRequest<CreateOrderResponse>
    {
        public CreateOrderRequest CreateOrderRequest { get; set; }

        public CreateOrderCommand(CreateOrderRequest createOrderRequest) => CreateOrderRequest = createOrderRequest;
    }
}