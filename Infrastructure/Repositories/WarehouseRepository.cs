using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly ApplicationDbContext context;

        public WarehouseRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IList<Warehouse>> GetAll()
        {
            return await context.Warehouses.ToListAsync();
        }
    }
}
