using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SistemaDePedidos.Models;

namespace SistemaDePedidos.Data.Map
{
        public class CategoriaMap : IEntityTypeConfiguration<CategoriasModel>
        {
            public void Configure(EntityTypeBuilder<CategoriasModel> builder)
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.NomeCategoria).IsRequired().HasMaxLength(255);
                builder.Property(x => x.Status).IsRequired();
            }
        }
}
