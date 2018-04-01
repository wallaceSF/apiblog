using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using apiblog.Config;
using apiblog.Entities;

namespace apiblog.Context
{
    public class ContextData: DbContext
    {        
       
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        public DbSet<Post> Posts { get; set; }
        public DbSet<PostStatus> PostStatus { get; set; }
        public DbSet<Comentario> Comentario { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Usuario> Usuario { get; set; }       

        public ContextData() : base("name=Connection")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {            

            base.OnModelCreating(modelBuilder);            

            modelBuilder.Configurations.Add(new PessoaMapping());            
            modelBuilder.Configurations.Add(new EmailMapping());
            modelBuilder.Configurations.Add(new EnderecoMapping());            

            modelBuilder.Configurations.Add(new PostMapping());
            modelBuilder.Configurations.Add(new PostStatusMapping());
            modelBuilder.Configurations.Add(new ComentarioMapping());
            modelBuilder.Configurations.Add(new CategoriaMapping());

            modelBuilder.Configurations.Add(new UsuarioMapping());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();


        }

    }
}