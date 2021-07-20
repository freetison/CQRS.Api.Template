using System.Collections.Generic;

namespace $safeprojectname$.Enumeration
{
    public class OrderStatus : IntEnumeration
    {
        public static readonly OrderStatus IN_PROGRESS = new OrderStatus(0, "IN_PROGRESS");
        public static readonly OrderStatus COMPLETED = new OrderStatus(1, "COMPLETED");
        public static readonly OrderStatus REJECTED = new OrderStatus(2, "REJECTED");

        public OrderStatus(int id, string name) : base(id, name)
        {
        }

        public static IEnumerable<OrderStatus> List() => new[] { IN_PROGRESS, COMPLETED, REJECTED };

        public static implicit operator int(OrderStatus state) => state.Id;
        public static implicit operator string(OrderStatus state) => state.Name;
    }
}