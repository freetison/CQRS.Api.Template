namespace $safeprojectname$.UseCases.GetOrder
{
    public class GetOrderResponse
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }
        public string Status { get; set; }
    }
}
