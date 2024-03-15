using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaDePedidos.Models;
using SistemaDePedidos.Repositorio.Interface;

namespace SistemaDePedidos.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public CategoriasController(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoriasModel>>> BuscarTodasCategorias()
        {
            List<CategoriasModel> categorias = await _categoriaRepositorio.BuscarTodasCategorias();
            return Ok(categorias);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<CategoriasModel>> BuscarPorId(int id)
        {
            CategoriasModel categoria = await _categoriaRepositorio.BuscarPorId(id);
            return Ok(categoria);
        }

        [HttpPost]

        public async Task<ActionResult<CategoriasModel>> Adicionar([FromBody] CategoriasModel categoriaModel)
        {
            CategoriasModel categoria = await _categoriaRepositorio.Adicionar(categoriaModel);
            return Ok(categoria);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<CategoriasModel>> Atualizar(int id, [FromBody] CategoriasModel categoriaModel)
        {
            categoriaModel.Id = id;
            CategoriasModel categoria = await _categoriaRepositorio.Atualizar(categoriaModel, id);
            return Ok(categoria);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<CategoriasModel>> Apagar(int id)
        {
            bool apagado = await _categoriaRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
