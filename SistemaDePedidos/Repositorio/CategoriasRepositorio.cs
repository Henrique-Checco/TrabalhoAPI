using Microsoft.EntityFrameworkCore;
using SistemaDePedidos.Data;
using SistemaDePedidos.Models;
using SistemaDePedidos.Repositorio.Interface;

namespace SistemaDePedidos.Repositorio
{
    public class CategoriasRepositorio : ICategoriaRepositorio
    {
        private readonly SistemaPedidosDbContext _dbContext;

        public CategoriasRepositorio(SistemaPedidosDbContext sistemaPedidosDbContext)
        {
            _dbContext = sistemaPedidosDbContext;
        }

        public async Task<CategoriasModel> BuscarPorId(int id)
        {
            return await _dbContext.Categorias.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<CategoriasModel>> BuscarTodasCategorias()
        {
            return await _dbContext.Categorias.ToListAsync();
        }
        public async Task<CategoriasModel> Adicionar(CategoriasModel categoria)
        {
            await _dbContext.Categorias.AddAsync(categoria);
            await _dbContext.SaveChangesAsync();
            return categoria;
        }

        public async Task<bool> Apagar(int id)
        {
            CategoriasModel categoriaPorId = await BuscarPorId(id);
            if (categoriaPorId == null)
            {
                throw new Exception($"Categoria do ID: {id} não encontrada");
            }

            _dbContext.Categorias.Remove(categoriaPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<CategoriasModel> Atualizar(CategoriasModel categoria, int id)
        {
            CategoriasModel categoriaPorId = await BuscarPorId(id);
            if (categoriaPorId == null)
            {
                throw new Exception($"Categoria do ID: {id} não encontrada");
            }

            categoriaPorId.NomeCategoria = categoria.NomeCategoria;
            categoriaPorId.Status = categoria.Status;

            _dbContext.Categorias.Update(categoriaPorId);
            await _dbContext.SaveChangesAsync();

            return categoria;
        }


    }
}
