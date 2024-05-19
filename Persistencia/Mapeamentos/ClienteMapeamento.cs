using DaVinci.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DaVinci.Persistencia.Mapeamentos
{
    public class ClienteMapeamento : IEntityTypeConfiguration<Clientes>
    {
        public void Configure(EntityTypeBuilder<Clientes> builder)
        {
            builder.ToTable("TB_DV_CLIENTE");

            builder.HasKey(p => p.IdCliente);

            builder.Property(p => p.Nome)
               .IsRequired()
               .HasAnnotation("Nome", "Nome do cliente é obrigatorio");

            builder.Property(p => p.Email)
               .HasAnnotation("Email", "Email do cliente é obrigatorio");

            builder.Property(p => p.Sexo)
               .HasAnnotation("Sexo", "Sexo do cliente é obrigatorio");

            builder.Property(p => p.Cidade)
               .HasAnnotation("Cidade", "Cidade do cliente é obrigatorio");

            builder.Property(p => p.Cpf)
               .HasAnnotation("Cpf", "CPF do cliente é obrigatorio");
        }
    }
}