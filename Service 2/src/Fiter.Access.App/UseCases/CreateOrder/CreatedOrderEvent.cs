using Application.UseCases.GetOrder;
using MediatR;

namespace Application.UseCases.CreateOrder
{
    public class CreatedOrderEvent: INotification
    {
        public GetOrderResponse CreateOrderResponse { get; set; }

        public CreatedOrderEvent(GetOrderResponse createOrderResponse) => CreateOrderResponse = createOrderResponse;
    }
}
