using apiblog.Entities;

namespace apiblog.Config
{
    public class PostMapping : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Post>
    {
        public PostMapping()
        {
            ToTable("post", "dbo");
            HasKey(p => p.IdPost);
            Property(p => p.IdPost).HasColumnName("idpost");
            Property(p => p.Titulo).HasColumnName("titulo");
            Property(p => p.Conteudo).HasColumnName("conteudo");
            HasMany(p => p.Comentarios);
            HasRequired(p => p.PostStatus).WithMany().Map(p => p.MapKey("idpost_status"));            

            HasMany(u => u.Categorias).WithMany().Map(m =>{
                    m.MapLeftKey("idpost");  
                    m.MapRightKey("idcategoria"); 
                    m.ToTable("post_categoria");
                });

            HasRequired(p => p.Pessoa).WithMany().Map(p => p.MapKey("idpessoa"));
        }
    }
}