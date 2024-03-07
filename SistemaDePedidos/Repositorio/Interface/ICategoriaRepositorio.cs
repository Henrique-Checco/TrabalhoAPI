using SistemaDePedidos.Models;

namespace SistemaDePedidos.Repositorio.Interface
{
        public interface ICategoriaRepositorio
        {
            Task<List<CategoriasModel>> BuscarTodasCategorias();
            Task<CategoriasModel> BuscarPorId(int id);
            Task<CategoriasModel> Adicionar(CategoriasModel categoria);
            Task<CategoriasModel> Atualizar(CategoriasModel categoria, int id);
            Task<bool> Apagar(int id);
        }
}
