using SistemaDePedidos.Enums;

namespace SistemaDePedidos.Models
{
    public class CategoriasModel
    {
        public int Id { get; set; }
        public string NomeCategoria {  get; set; }
        public StatusCategoria Status { get; set; }
    }
}
