using CastGroup.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CastGroup.Infra.Data.Mapping
{
    class CategoriaMapping : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(ca => ca.Codigo);

            builder.Property(ca => ca.Descricao);
           
            builder.ToTable("CST_CATEGORIAS");
        }
    }
}
