using $safeprojectname$.UseCases.GetOrder;
using MediatR;

namespace $safeprojectname$.UseCases.CreateOrder
{
    public class CreatedOrderEvent: INotification
    {
        public GetOrderResponse CreateOrderResponse { get; set; }

        public CreatedOrderEvent(GetOrderResponse createOrderResponse) => CreateOrderResponse = createOrderResponse;
    }
}
