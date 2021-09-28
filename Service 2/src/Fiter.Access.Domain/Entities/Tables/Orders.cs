using Domain.Entities.Base;
using Domain.Enumeration;
using Domain.Model;

namespace Domain.Entities.Tables
{
    public class Orders: AppEntity
    {
        public string OrderId { get; set; }
        public Product Product { get; set; }
        public decimal Quantity { get; set; }
        public OrderStatus Status { get; set; }

        public Orders(string orderId, Product product, decimal quantity)
        {
            OrderId = orderId;
            Product = product;
            Quantity = quantity;
            Status = OrderStatus.InProgress;
        }
    }
}
