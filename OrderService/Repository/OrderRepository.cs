using OrderService.Models;
using System.Net.Http.Headers;

namespace OrderService.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private static int _next = 1;
        private static List<Order> _orders = new List<Order>();
        private readonly HttpClient _httpClient;

        public IEnumerable<Order> GetAllOrders()
        {
            return _orders;
        }
        public void AddOrder(Order order)
        {
            order.Id = _next++;
            _orders.Add(order);
        }

    }
}
