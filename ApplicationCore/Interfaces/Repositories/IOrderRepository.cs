using ApplicationCore.Models;

namespace ApplicationCore.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task<int> Add(Order order);
        Task<int> DeleteOrder(int orderId);
        Task<IList<Order>> GetAllOrdersByCustomer(int customerId);
        Task<double> GetAverageArticlePerOrder();
        Task<double> GetAverageOrderValue();
    }
}
