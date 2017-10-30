using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiblog.Entities
{
    public class Comentario
    {       
        public int IdComentario { get; set; }
        public string Conteudo { get; set; }
        public int? IdPai { get; set; }
        public virtual Comentario Pai { get; set; }
        public virtual ICollection<Comentario> Filho { get; set; }
        public virtual Post Post { get; set; }
        public virtual Pessoa Pessoa { get; set; }

    }
}