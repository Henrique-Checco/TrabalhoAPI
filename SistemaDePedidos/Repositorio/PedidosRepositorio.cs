using Microsoft.EntityFrameworkCore;
using SistemaDePedidos.Data;
using SistemaDePedidos.Models;
using SistemaDePedidos.Repositorio.Interface;

namespace SistemaDePedidos.Repositorio
{
    public class PedidosRepositorio : IPedidosRepositorio
    {
        private readonly SistemaPedidosDbContext _dbContext;

        public PedidosRepositorio(SistemaPedidosDbContext sistemaPedidosDbContext)
        {
            _dbContext = sistemaPedidosDbContext;
        }

        public async Task<PedidosModel> BuscarPorId(int id)
        {
            return await _dbContext.Pedidos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<PedidosModel>> BuscarTodosPedidos()
        {
            return await _dbContext.Pedidos.ToListAsync();
        }
        public async Task<PedidosModel> Adicionar(PedidosModel pedido)
        {
            await _dbContext.Pedidos.AddAsync(pedido);
            await _dbContext.SaveChangesAsync();
            return pedido;
        }

        public async Task<bool> Apagar(int id)
        {
            PedidosModel pedidoPorId = await BuscarPorId(id);
            if (pedidoPorId == null)
            {
                throw new Exception($"Pedido do ID: {id} não encontrado");
            }

            _dbContext.Pedidos.Remove(pedidoPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<PedidosModel> Atualizar(PedidosModel pedido, int id)
        {
            PedidosModel pedidoPorId = await BuscarPorId(id);
            if (pedidoPorId == null)
            {
                throw new Exception($"Pedido do ID: {id} não encontrado");
            }

            pedidoPorId.UsuarioId = pedido.UsuarioId;
            pedidoPorId.EnderecoEntrega = pedido.EnderecoEntrega;

            _dbContext.Pedidos.Update(pedidoPorId);
            await _dbContext.SaveChangesAsync();

            return pedido;
        }


    }
}