using System;

namespace OrderInventory.Api.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        public OrderStatus OrderStatus { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}