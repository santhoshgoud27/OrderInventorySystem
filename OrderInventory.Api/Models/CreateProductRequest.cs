namespace OrderInventory.Api.Models
{
    public class CreateProductRequest
    {
        public string Name { get; set; } = string.Empty;
        public Category Category { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
    }
}