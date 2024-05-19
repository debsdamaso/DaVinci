using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DaVinci.Models;

namespace DaVinci.Persistencia.Mapeamentos

{
    public class FeedbackMapeamento : IEntityTypeConfiguration<Feedbacks>
    {
        public void Configure(EntityTypeBuilder<Feedbacks> builder)
        {
            builder.ToTable("TB_DV_FEEDBACK");

            builder.HasKey(p => p.IdFeedback);

            builder.Property(p => p.Comentario)
               .HasAnnotation("Comentario", "Comentario do feedback é obrigatorio");

            builder.Property(p => p.DataFeedback)
               .HasAnnotation("DataFeedback", "Data do feedback é obrigatorio");

            builder.Property(p => p.Avaliacao)
               .HasAnnotation("Avaliacao", "Avaliação do feedback é obrigatorio");
        }
    }
}