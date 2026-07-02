using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderInventory.Api.Data;
using OrderInventory.Api.Models;

namespace OrderInventory.Api.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly OrderInventoryDbContext _context;

        public OrdersController(OrderInventoryDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(CreateOrderRequest request)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == request.ProductId);

            if (product == null)
            {
                return NotFound("Product not found.");
            }

            if (product.QuantityInStock < request.Quantity)
            {
                return BadRequest("Insufficient stock.");
            }

            product.QuantityInStock -= request.Quantity;

            var order = new Order
            {
                Id = Guid.NewGuid(),
                ProductId = product.Id,
                Quantity = request.Quantity,
                UnitPrice = product.Price,
                OrderStatus = OrderStatus.Pending,
                CreatedDate = DateTime.UtcNow
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return Ok(order);
        }
        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetAllOrders()
        {
            var orders = await _context.Orders.ToListAsync();
            return Ok(orders);
        }

        [HttpPut("{id}/status")]
        public async Task<ActionResult<Order>> UpdateOrderStatus(Guid id, [FromBody] UpdateOrderStatusRequest request)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                return NotFound("Order not found.");
            }

            order.OrderStatus = request.OrderStatus;
            await _context.SaveChangesAsync();

            return Ok(order);
        }

         [HttpGet("by-product/{productId}")]
        public async Task<ActionResult<List<Order>>> GetOrdersByProduct(Guid productId)
         {
            var orders = await _context.Orders
                .Where(o => o.ProductId == productId)
                .ToListAsync();

            return Ok(orders);
         }
      
    }
}