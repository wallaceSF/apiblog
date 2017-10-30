using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiblog.Entities
{
    public class Categoria
    {       
        public int IdCategoria { get; set; }
        public string Nome { get; set; }
        public int? IdPai { get; set; }
        public virtual Categoria Pai { get; set; }
        public virtual ICollection<Categoria> Filho { get; set; }


       // public virtual List<Post> Posts { get; set; }

    }
}