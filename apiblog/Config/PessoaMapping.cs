using apiblog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiblog.Config
{
    public class PessoaMapping : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Pessoa>
    {

        public PessoaMapping()
        {
            ToTable("pessoa", "dbo");
            HasKey(p => p.IdPessoa);
            Property(p => p.IdPessoa).HasColumnName("idpessoa");
            Property(p => p.Nome).HasColumnName("nome");
            Property(p => p.NascimentoData).HasColumnName("nascimentodata");
            HasMany(p => p.Emails);
            HasMany(p => p.Enderecos);
        //    HasMany(p => p.Posts);
         //   HasMany(p => p.Comentarios);
        }

    }
}