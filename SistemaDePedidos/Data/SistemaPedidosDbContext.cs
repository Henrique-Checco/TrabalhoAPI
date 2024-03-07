using Microsoft.EntityFrameworkCore;
using SistemaDePedidos.Data.Map;
using SistemaDePedidos.Models;

namespace SistemaDePedidos.Data
{
    public class SistemaPedidosDbContext : DbContext
    {
        public SistemaPedidosDbContext(DbContextOptions<SistemaPedidosDbContext> options) : base(options)
        {
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<PedidosModel> Pedidos { get; set; }
        public DbSet<CategoriasModel> Categorias { get; set; }
        public DbSet<ProdutosModel> Produtos { get; set; }
        public DbSet<PedidosProdutosModel> PedidosProdutos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new PedidosMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new PedidosProdutosMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
