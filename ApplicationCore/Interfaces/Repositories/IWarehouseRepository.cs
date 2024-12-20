using ApplicationCore.Models;

namespace ApplicationCore.Interfaces.Repositories
{
    public interface IWarehouseRepository
    {
        Task<IList<Warehouse>> GetAll();
    }
}
