using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SistemaDePedidos.Models;

namespace SistemaDePedidos.Data.Map
{
        public class PedidosMap : IEntityTypeConfiguration<PedidosModel>
        {
            public void Configure(EntityTypeBuilder<PedidosModel> builder)
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.UsuarioId);
                builder.HasOne(x => x.Usuario);
                builder.Property(x => x.EnderecoEntrega).IsRequired().HasMaxLength(255);
            }
        }
}
