using System.Collections.Generic;

namespace apiblog.Entities
{
    public class Post
    {
        public int IdPost { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public virtual List<Comentario> Comentarios { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public virtual PostStatus PostStatus { get; set; }
        public virtual List<Categoria> Categorias { get; set; }

    }
}