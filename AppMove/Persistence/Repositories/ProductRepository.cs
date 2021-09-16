using System.Collections.Generic;
using System.Threading.Tasks;
using AppMove.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppMove.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly ProdutoContext _dbContext;

        public ProductRepository(ProdutoContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
        }
        public async Task AddCompra(Compra compra)
        {
            await _dbContext.Vendas.AddAsync(compra);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DarBaixa(int id)
        {
            Product product = await _dbContext.Products.SingleOrDefaultAsync(p => p.Id == id);
            product.Estoque--;
            await _dbContext.SaveChangesAsync();

        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }



        public async Task<Product> GetByIdAsync(int id)
        {
            return await _dbContext.Products.SingleOrDefaultAsync(p => p.Id == id);
        }
        public async Task RemoveAsync(int id)
        {
            var p = await _dbContext.Products.SingleOrDefaultAsync(p => p.Id == id);

            _dbContext.Products.Remove(p);
            await _dbContext.SaveChangesAsync();
        }
    }

}