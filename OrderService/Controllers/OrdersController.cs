using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Models;
using OrderService.Repository;
using OrderService.Services;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _repo;
        private readonly ProductApiClient _productApiClient;
        public OrdersController(IOrderRepository repo, ProductApiClient productApiClient)
        {
            _repo = repo;
            _productApiClient = productApiClient;
        }

        [HttpGet]
        public IActionResult GetAllOrders()
        {
            return Ok(_repo.GetAllOrders());
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(int productId, int quantity)
        {
            var product = await _productApiClient.GetProduct(productId);
            if (product == null)
            {
                return BadRequest("Product Not Found");
            }

            Order order = new Order()
            {
                ProductId = productId,
                Quantity = quantity,
                TotalPrice = quantity * product.Price
            };

            _repo.AddOrder(order);
            return Ok(order);
        }
    }
}
