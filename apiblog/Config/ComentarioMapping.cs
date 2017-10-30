using apiblog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiblog.Config
{
    public class ComentarioMapping : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Comentario>
    {

        public ComentarioMapping()
        {

            ToTable("comentario", "dbo");
            HasKey(x => x.IdComentario);

            Property(x => x.IdComentario)
                .HasColumnName("idcomentario")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Conteudo)
                .HasColumnName("conteudo")
                .IsRequired()
                .HasMaxLength(255);

            Property(x => x.IdPai).HasColumnName("idpai");


            HasOptional(x => x.Pai)
                .WithMany(x => x.Filho)
                .HasForeignKey(x => x.IdPai)
                .WillCascadeOnDelete(false);

            HasRequired(p => p.Post).WithMany(c => c.Comentarios).Map(p => p.MapKey("idpost"));

            HasRequired(p => p.Pessoa).WithMany().Map(p => p.MapKey("idpessoa"));

        }

    }
}