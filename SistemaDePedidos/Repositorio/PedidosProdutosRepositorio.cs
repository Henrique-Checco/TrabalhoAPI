using Microsoft.EntityFrameworkCore;
using SistemaDePedidos.Data;
using SistemaDePedidos.Models;
using SistemaDePedidos.Repositorio.Interface;

namespace SistemaDePedidos.Repositorio
{
    public class PedidosProdutosRepositorio : IPedidosProdutosRepositorio
    {
        private readonly SistemaPedidosDbContext _dbContext;

        public PedidosProdutosRepositorio(SistemaPedidosDbContext sistemaPedidosDbContext)
        {
            _dbContext = sistemaPedidosDbContext;
        }

        public async Task<PedidosProdutosModel> BuscarPorId(int id)
        {
            return await _dbContext.PedidosProdutos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<PedidosProdutosModel>> BuscarTodosPedidosProdutos()
        {
            return await _dbContext.PedidosProdutos.ToListAsync();
        }
        public async Task<PedidosProdutosModel> Adicionar(PedidosProdutosModel pedidosProdutos)
        {
            await _dbContext.PedidosProdutos.AddAsync(pedidosProdutos);
            await _dbContext.SaveChangesAsync();
            return pedidosProdutos;
        }

        public async Task<bool> Apagar(int id)
        {
            PedidosProdutosModel pedidosProdutosPorId = await BuscarPorId(id);
            if (pedidosProdutosPorId == null)
            {
                throw new Exception($"Pedido Produto do ID: {id} não encontrado");
            }

            _dbContext.PedidosProdutos.Remove(pedidosProdutosPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<PedidosProdutosModel> Atualizar(PedidosProdutosModel pedidosProdutos, int id)
        {
            PedidosProdutosModel pedidosProdutosPorId = await BuscarPorId(id);
            if (pedidosProdutosPorId == null)
            {
                throw new Exception($"Pedido Produto do ID: {id} não encontrado");
            }

            pedidosProdutosPorId.ProdutoId = pedidosProdutos.ProdutoId;
            pedidosProdutosPorId.CategoriaId = pedidosProdutos.CategoriaId;
            pedidosProdutosPorId.Quantidade = pedidosProdutos.Quantidade;

            _dbContext.PedidosProdutos.Update(pedidosProdutosPorId);
            await _dbContext.SaveChangesAsync();

            return pedidosProdutos;
        }


    }
}
