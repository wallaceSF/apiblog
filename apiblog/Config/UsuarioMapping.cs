using apiblog.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;

namespace apiblog.Config
{
    public class UsuarioMapping : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Usuario>
    {
        public UsuarioMapping()
        {
            ToTable("usuario", "dbo");
            HasKey(p => p.IdUsuario);
            Property(p => p.IdUsuario).HasColumnName("idusuario");
          //  Property(p => p.Pessoa.IdPessoa).HasColumnName("idpessoa");

           // HasRequired(p => p.Pessoa).WithMany().Map(p => p.MapKey("idpessoa"));

            HasRequired(p => p.Pessoa).WithMany().Map(p => p.MapKey("idpessoa"));
            //HasRequired(p => p.Pessoa).WithMany().Map(p => p.MapKey("idpessoa"));

           //   HasOptional(p => p.Pessoa).WithRequired().Map(p => p.MapKey("idpessoa"));



           //  HasRequired(a => a.Pessoa).WithRequiredPrincipal(b => b.Usuario); 
            Property(p => p.Login).HasColumnName("login").HasColumnAnnotation(
                 IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                     new IndexAttribute("IX_Login", 1) { IsUnique = true })
                );
            Property(p => p.Senha).HasColumnName("senha");            
        }
    }
}