using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Models;

namespace ApplicationCore.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task<Order?> Get(int id)
        {
            return await orderRepository.Get(id);
        }

        public async Task<int> Add(Order order)
        {
            return await orderRepository.Add(order);
        }

        public Task<int> Delete(int orderId)
        {
            return orderRepository.Delete(orderId);
        }

        public async Task<IList<Order>> GetAllOrdersByCustomer(int customerId)
        {
            return await orderRepository.GetAllOrdersByCustomer(customerId);
        }

        public async Task<IDictionary<int, double>> GetAverageArticlePerOrder()
        {
            return await orderRepository.GetAverageArticlePerOrder();
        }

        public async Task<double> GetAverageOrderValue()
        {
            return await orderRepository.GetAverageOrderValue();
        }
    }
}
