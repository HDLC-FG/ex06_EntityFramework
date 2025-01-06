using ApplicationCore.Models;

namespace ApplicationCore.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task<Order?> Get(int id);
        Task<int> Add(Order order);
        Task<int> Delete(int orderId);
        Task<IList<Order>> GetAllOrdersByCustomer(int customerId);
        Task<IDictionary<int, double>> GetAverageArticlePerOrder();
        Task<double> GetAverageOrderValue();
    }
}
