using $safeprojectname$.Entities.Base;
using $safeprojectname$.Enumeration;

namespace $safeprojectname$.Entities.Tables
{
    public class Orders: AppEntity
    {
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }

        public OrderStatus Status { get; set; }
    }
}
