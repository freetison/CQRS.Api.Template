using System;

namespace Application.UseCases.CreateOrder
{
    public class CreateOrderResponse
    {
        public int Id { get; set; }
        public string Status { get; set; }

        public CreateOrderResponse(int id, string status)
        {
            Id = id;
            Status = status;
        }

    }
}
