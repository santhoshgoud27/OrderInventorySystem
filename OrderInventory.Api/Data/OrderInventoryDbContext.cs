using Microsoft.EntityFrameworkCore;
using OrderInventory.Api.Models;

namespace OrderInventory.Api.Data
{
    public class OrderInventoryDbContext : DbContext
    {
        public OrderInventoryDbContext(DbContextOptions<OrderInventoryDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}