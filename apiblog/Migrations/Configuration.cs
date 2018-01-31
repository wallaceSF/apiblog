namespace apiblog.Migrations
{
    using apiblog.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<apiblog.Context.ContextData>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(apiblog.Context.ContextData context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //  
            var _context = context;

            var transaction = context.Database.BeginTransaction();
            try
            {
                var ObjectPessoa = context.Pessoas.Where(u => u.Nome == "Fulano 4 migration").FirstOrDefault();

                if (ObjectPessoa != null)
                {
                    return;
                }

                var Pessoa = new Pessoa
                {
                    Nome = "Fulano 4 migration",
                    NascimentoData = DateTime.Parse("11-10-1989"),
                };

                context.Pessoas.AddOrUpdate(
                    p => p.Nome,
                        Pessoa
                   );

                context.Usuario.AddOrUpdate(
                  u => u.Login,
                  new Usuario
                  {
                      Login = "fulano4",
                      Pessoa = Pessoa,
                      Senha = "123456",
                  }
                   );

                context.Emails.AddOrUpdate(
                   new Email
                   {
                       Pessoa = Pessoa,
                       Endereco = "fulano4@gmail.com"
                   }
                    );


                var PostStatusObject = new PostStatus
                {
                    Status = "Disponivel"
                };

                context.PostStatus.AddOrUpdate(PostStatusObject);

                var CategoriaObject = new Categoria
                {
                    IdPai = null,
                    Nome = "Base"
                };

                context.Categorias.AddOrUpdate(CategoriaObject);

                var PostObject = new Post
                {
                    Titulo = "Migration Post",
                    Conteudo = "How to Post a Thread on a Forum. Posting on a forum is good way to get your questions answered by the forum's community. A topic relevant to the forum will help get people to reply to your post.",
                    Pessoa = Pessoa,
                    PostStatus = PostStatusObject,
                    Categorias = new List<Categoria> { CategoriaObject }
                };

                context.Posts.AddOrUpdate(
                 PostObject
                );

                context.Comentario.AddOrUpdate(
                new Comentario()
                {
                    Conteudo = "Comentário conteudo teste pai",
                    IdPai = null,
                    Pessoa = Pessoa,
                    Post = PostObject,

                }
               );
            }catch(Exception e)
            {
                transaction.Rollback();
                return;
            }
            _context.SaveChanges();
            transaction.Commit();

        }
    }
}
