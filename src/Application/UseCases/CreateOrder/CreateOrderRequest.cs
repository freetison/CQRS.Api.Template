namespace $safeprojectname$.UseCases.CreateOrder
{
    public class CreateOrderRequest
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }
    }
}
