namespace Domain.Model
{
    public class Product
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }

        public Product(string productId, string productName)
        {
            ProductId = productId;
            ProductName = productName;
        }
    }
}