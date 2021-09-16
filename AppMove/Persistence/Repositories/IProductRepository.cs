using System.Collections.Generic;
using System.Threading.Tasks;
using AppMove.Entities;

namespace AppMove.Persistence.Repositories
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);
        Task AddCompra(Compra compra);
        Task<Product> GetByIdAsync(int id);
        Task<List<Product>> GetAllAsync();
        Task DarBaixa(int id);
        Task RemoveAsync(int id);
    }
}