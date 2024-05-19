using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DaVinci.Models;

namespace DaVinci.Persistencia.Mapeamentos
{
    public class ProdutoMapeamento : IEntityTypeConfiguration<Produtos>
    {
        public void Configure(EntityTypeBuilder<Produtos> builder)
        {
            builder.ToTable("TB_DV_PRODUTO");

            builder.HasKey(p => p.IdProduto);

            builder.Property(p => p.Nome)
               .IsRequired()
               .HasAnnotation("Nome", "Nome do produto é obrigatorio");

            builder.Property(p => p.Valor)
               .HasAnnotation("Valor", "Valor do produto é obrigatorio");

            builder.Property(p => p.Categoria)
               .HasAnnotation("Categoria", "Categoria do produto é obrigatorio");

            builder.Property(p => p.Modelo)
               .HasAnnotation("Modelo", "Modelo do produto é obrigatorio");
        }
    }
}