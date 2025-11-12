using OrderService.Models;

namespace OrderService.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAllOrders();
        void AddOrder(Order order);
    }
}
