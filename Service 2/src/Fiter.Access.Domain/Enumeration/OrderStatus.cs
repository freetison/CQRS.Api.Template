using System.Collections.Generic;

namespace Domain.Enumeration
{
    public class OrderStatus : IntEnumeration
    {
        public static readonly OrderStatus InProgress = new OrderStatus(0, "IN_PROGRESS");
        public static readonly OrderStatus Completed = new OrderStatus(1, "COMPLETED");
        public static readonly OrderStatus Rejected = new OrderStatus(2, "REJECTED");

        public OrderStatus(int id, string name) : base(id, name)
        {
        }

        public static IEnumerable<OrderStatus> List() => new[] { InProgress, Completed, Rejected };

        public static implicit operator int(OrderStatus state) => state.Id;
        public static implicit operator string(OrderStatus state) => state.Name;
    }
}