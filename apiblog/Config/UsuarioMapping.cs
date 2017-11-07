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
            HasRequired(p => p.Pessoa).WithMany().Map(p => p.MapKey("idpessoa"));
            Property(p => p.Login).HasColumnName("login").HasColumnAnnotation(
                 IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                     new IndexAttribute("IX_Login", 1) { IsUnique = true })
                );
            Property(p => p.Senha).HasColumnName("senha");            
        }
    }
}