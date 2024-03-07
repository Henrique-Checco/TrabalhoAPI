using Microsoft.EntityFrameworkCore;
using SistemaDePedidos.Data;
using SistemaDePedidos.Models;
using SistemaDePedidos.Repositorio.Interface;

namespace SistemaDePedidos.Repositorio
{
    public class ProdutosRepositorio : IProdutoRepositorio
    {
        private readonly SistemaPedidosDbContext _dbContext;

        public ProdutosRepositorio(SistemaPedidosDbContext sistemaPedidosDbContext)
        {
            _dbContext = sistemaPedidosDbContext;
        }

        public async Task<ProdutosModel> BuscarPorId(int id)
        {
            return await _dbContext.Produtos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ProdutosModel>> BuscarTodosProdutos()
        {
            return await _dbContext.Produtos.ToListAsync();
        }
        public async Task<ProdutosModel> Adicionar(ProdutosModel produto)
        {
            await _dbContext.Produtos.AddAsync(produto);
            await _dbContext.SaveChangesAsync();
            return produto;
        }

        public async Task<bool> Apagar(int id)
        {
            ProdutosModel produtoPorId = await BuscarPorId(id);
            if (produtoPorId == null)
            {
                throw new Exception($"Produto do ID: {id} não encontrado");
            }

            _dbContext.Produtos.Remove(produtoPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ProdutosModel> Atualizar(ProdutosModel produto, int id)
        {
            ProdutosModel produtoPorId = await BuscarPorId(id);
            if (produtoPorId == null)
            {
                throw new Exception($"Produto do ID: {id} não encontrado");
            }

            produtoPorId.NomeProdutos = produto.NomeProdutos;
            produtoPorId.Descricao = produto.Descricao;
            produtoPorId.Preco = produto.Preco;

            _dbContext.Produtos.Update(produtoPorId);
            await _dbContext.SaveChangesAsync();

            return produto;
        }


    }
}
