using System;

namespace OrderInventory.Api.Models
{
    public class CreateOrderRequest
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}