using CastGroup.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CastGroup.Infra.Data.Mapping
{
    public class CursoMapping : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Descricao)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder.Property(c => c.DataInicio)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(c => c.DataFim)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(c => c.QuantidadeAlunos)
                .HasColumnType("int");

            builder.HasOne(ca => ca.Categoria)
               .WithMany(c => c.Curso)
               .HasForeignKey(c => c.CodigoCategoria);


            //1 : N => Categoria : Curso
            //builder.HasMany(c => c.Curso)
            //builder.HasOne(ca => ca.Curso)
            //    .WithMany(c => c.Categoria);

            builder.ToTable("CST_CURSOS");
        }
    }
}
