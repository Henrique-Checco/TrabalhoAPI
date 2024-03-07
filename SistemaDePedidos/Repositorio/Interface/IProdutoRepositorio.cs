using SistemaDePedidos.Models;

namespace SistemaDePedidos.Repositorio.Interface
{
        public interface IProdutoRepositorio
        {
            Task<List<ProdutosModel>> BuscarTodosProdutos();
            Task<ProdutosModel> BuscarPorId(int id);
            Task<ProdutosModel> Adicionar(ProdutosModel produto);
            Task<ProdutosModel> Atualizar(ProdutosModel produto, int id);
            Task<bool> Apagar(int id);
        }
}
