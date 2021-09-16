using AppMove.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppMove.Persistence
{
    public class ProdutoContext : DbContext
    {
        public ProdutoContext(DbContextOptions<ProdutoContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Compra> Vendas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(p =>
            {
                p.ToTable("tb_Product");
                p.HasKey(p => p.Id);

            });

            modelBuilder.Entity<Compra>(c =>
            {
                c.ToTable("tb_Compras");
                c.HasKey(x => x.ID);

            });

        }

    }
}