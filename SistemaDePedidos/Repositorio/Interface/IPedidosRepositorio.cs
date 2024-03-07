using SistemaDePedidos.Models;

namespace SistemaDePedidos.Repositorio.Interface
{
        public interface IPedidosRepositorio
        {
            Task<List<PedidosModel>> BuscarTodosPedidos();
            Task<PedidosModel> BuscarPorId(int id);
            Task<PedidosModel> Adicionar(PedidosModel pedido);
            Task<PedidosModel> Atualizar(PedidosModel pedido, int id);
            Task<bool> Apagar(int id);
        }
}
