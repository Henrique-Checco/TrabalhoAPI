using Microsoft.AspNetCore.Mvc;
using SistemaDePedidos.Models;
using SistemaDePedidos.Repositorio.Interface;

namespace SistemaDePedidos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutosController(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProdutosModel>>> BuscarTodosProdutos()
        {
            List<ProdutosModel> produtos = await _produtoRepositorio.BuscarTodosProdutos();
            return Ok(produtos);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<ProdutosModel>> BuscarPorId(int id)
        {
            ProdutosModel produto = await _produtoRepositorio.BuscarPorId(id);
            return Ok(produto);
        }

        [HttpPost]

        public async Task<ActionResult<ProdutosModel>> Adicionar([FromBody] ProdutosModel produtosModel)
        {
            ProdutosModel produto = await _produtoRepositorio.Adicionar(produtosModel);
            return Ok(produto);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<ProdutosModel>> Atualizar(int id, [FromBody] ProdutosModel produtoModel)
        {
            produtoModel.Id = id;
            ProdutosModel produto = await _produtoRepositorio.Atualizar(produtoModel, id);
            return Ok(produto);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<ProdutosModel>> Apagar(int id)
        {
            bool apagado = await _produtoRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}