using apiblog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiblog.Config
{
    public class CategoriaMapping : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Categoria>
    {

        public CategoriaMapping()
        {

            ToTable("categoria", "dbo");
            HasKey(x => x.IdCategoria);

            Property(x => x.IdCategoria)
                .HasColumnName("idcategoria")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome)
                .HasColumnName("nome")
                .IsRequired()
                .HasMaxLength(255);

            Property(x => x.IdPai).HasColumnName("idpai");


            HasOptional(x => x.Pai)
                .WithMany(x => x.Filho)
                .HasForeignKey(x => x.IdPai)
                .WillCascadeOnDelete(false);

        }

    }
}