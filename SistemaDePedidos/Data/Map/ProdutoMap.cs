using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SistemaDePedidos.Models;

namespace SistemaDePedidos.Data.Map
{
        public class ProdutoMap : IEntityTypeConfiguration<ProdutosModel>
        {
            public void Configure(EntityTypeBuilder<ProdutosModel> builder)
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.NomeProdutos).IsRequired().HasMaxLength(255);
                builder.Property(x => x.Descricao).IsRequired().HasMaxLength(255);
                builder.Property(x => x.Preco).IsRequired();
            }
        }
}
