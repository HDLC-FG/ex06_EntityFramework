using ApplicationCore.Models;

namespace ApplicationCore.Interfaces.Services
{
    public interface IOrderService
    {
        // Method to add new Order
        Task<int> Add(Order order);

        // Method to delete an order
        Task<int> DeleteOrder(int orderId);

        // Method to fetch all orders made by a specific customer
        Task<IList<Order>> GetAllOrdersByCustomer(int customerId);

        // Method to get average order value
        Task<double> GetAverageArticlePerOrder();

        // Method to get average number article by order
        Task<double> GetAverageOrderValue();
    }
}
