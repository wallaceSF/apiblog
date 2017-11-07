using apiblog.Entities;

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
        }
    }
}